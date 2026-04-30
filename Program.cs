// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

GameClock gameClock = new GameClock();
Map map = new Map();
Keyboard keyboard = new Keyboard();

void Menu(string type = "Main")
{
    if(type == "Main")
    {
        Console.WriteLine(" ╔══════════════════════════════════════════════╗");
        if(map.PlayerType == null)
        {
            Console.Write(" ║ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Please Select A Character");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    ║");
        }
        Console.WriteLine(" ║ Press C For Character Selection              ║");
        Console.WriteLine(" ║ Press W For Weapon Selection                 ║");
        Console.WriteLine($" ║ Press L For Layout (Current Is {keyboard.Layout})       ║");
        Console.WriteLine(" ║ Press F For FPS (Will Change The Game Speed) ║");
        Console.WriteLine(" ╠══════════════════════════════════════════════╣");
        Console.WriteLine(" ║ Press Enter To Play                          ║");
        Console.WriteLine(" ╚══════════════════════════════════════════════╝");
    }
    else if(type == "Character")
    {
        if(map.PlayerType != null)
        {
            string dash = "";
            string space = "";
            for(int i = 1; i < map.PlayerType.Length; i++)
            {
                dash += "═";
                space += " ";
            }
            Console.WriteLine($" ╔═════════════════════════════{dash}╗");
            Console.Write(" ║ Your Current Character Is ");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(map.PlayerType);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ║");
            Console.Write(" ║ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Warning");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"                     {space}║");
            Console.Write(" ║ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Changing Will Reset The Game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{space}║");
            Console.WriteLine($" ╠═════════════════════════════{dash}╣");
            Console.WriteLine($" ║ Press K For Knight          {space}║");
            Console.WriteLine($" ║ Press B For Berserker       {space}║");
            Console.WriteLine($" ╠═════════════════════════════{dash}╣");
            Console.WriteLine($" ║ Press Enter To Return       {space}║");
            Console.WriteLine($" ╚═════════════════════════════{dash}╝");
        }
        else
        {
            Console.WriteLine(" ╔═══════════════════════════╗");
            Console.WriteLine(" ║ No Character Selected     ║");
            Console.WriteLine(" ║ Please Select A Character ║");
            Console.WriteLine(" ╠═══════════════════════════╣");
            Console.WriteLine(" ║ Press K For Knight        ║");
            Console.WriteLine(" ║ Press B For Berserker     ║");
            Console.WriteLine(" ╠═══════════════════════════╣");
            Console.WriteLine(" ║ Press Enter To Return     ║");
            Console.WriteLine(" ╚═══════════════════════════╝");

        }
        
    }
    else if(type == "Weapon")
    {
        Console.WriteLine(" ╔══════════════════════════════╗");
        Console.WriteLine(" ║ Only Sword Available For Now ║");
        Console.WriteLine(" ╠══════════════════════════════╣");
        Console.WriteLine(" ║ Press S For Sword            ║");
        Console.WriteLine(" ╠══════════════════════════════╣");
        Console.WriteLine(" ║ Press Enter To Return        ║");
        Console.WriteLine(" ╚══════════════════════════════╝");
    }
    else if(type == "FPS")
    {
        Console.WriteLine(" ╔══════════════════════════════════════════╗");
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Warning, This Will Change The Game Speed");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" ║");
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("Default Is 60 FPS");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                        ║");
        Console.WriteLine(" ╠══════════════════════════════════════════╣");
        Console.WriteLine(" ║ Press F To Type New FPS Value            ║");
        Console.WriteLine(" ╠══════════════════════════════════════════╣");
        Console.WriteLine(" ║ Press Enter To Return                    ║");
        Console.WriteLine(" ╚══════════════════════════════════════════╝");
    }
    else if(type == "Layout")
    {
        Console.WriteLine(" ╔════════════════════════╗");
        Console.WriteLine($" ║ Current Layout: {keyboard.Layout} ║");
        Console.WriteLine(" ╠════════════════════════╣");
        Console.WriteLine(" ║ Press A For AZERTY     ║");
        Console.WriteLine(" ║ Press Z For QWERTZ     ║");
        Console.WriteLine(" ║ Press Y For QWERTY     ║");
        Console.WriteLine(" ╠════════════════════════╣");
        Console.WriteLine(" ║ Press Enter To Return  ║");
        Console.WriteLine(" ╚════════════════════════╝");
    }    

}
string? menu = "Main";
bool running = true;
int ticks = 0;
gameClock.FPS = 30;
Sword sword = new Sword("Sword", 10);
Sword swordLD = new Sword("Claw", 10);
bool enemyUpdate = false;



while (running)
{
    gameClock.StartFrame();

    
    if(menu == null)
    {
        map.Display(enemyUpdate);
        enemyUpdate = false;
        if(Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.X )
            {  
                menu = "Main";
            }
            else if(key.Key == keyboard.Right)
            {
                map.PlayerX += 1;
            }
            else if(key.Key == keyboard.Left)
            {
                map.PlayerX -= 1;                
            }
            else if(key.Key == keyboard.Up)
            {
                map.PlayerY -= 1;
            }                
            else if(key.Key == keyboard.Down)
            {
                map.PlayerY += 1;
            }
            else if(key.Key == ConsoleKey.X)
            {
                menu = "Main";
            }
            else if(key.Key == ConsoleKey.Spacebar)
            {
                map.PlayerAttack();
            }        
        }

        ticks += 1;
        if(ticks == gameClock.FPS)
        {
            map.EndTurn();
            ticks = 0;
            enemyUpdate = true;
            LesserDemon lesserDemon = new LesserDemon("E");
            map.AddEnemy(lesserDemon);
        }


    }
    else
    {
        Menu(menu);

        if(menu == "Main")
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter && map.PlayerType != null)
                {
                    menu = null;
                }
                else if(key.Key == ConsoleKey.C)
                {
                    menu = "Character";
                }
                else if(key.Key == ConsoleKey.W)
                {
                    menu = "Weapon";
                }
                else if(key.Key == ConsoleKey.F)
                {
                    menu = "FPS";
                }
                else if(key.Key == ConsoleKey.L)
                {
                    menu = "Layout";
                }
            }
        }
        else if(menu == "Character")
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter)
                {
                    menu = "Main";
                }
                else if(key.Key == ConsoleKey.K)
                {
                    Knight player = new Knight("Player");
                    player.weapons.Add(sword);
                    player.ChangeSelectedWeapon(0);
                    map.Reset();
                    map.AddPlayer(player);
                }
                else if(key.Key == ConsoleKey.B)
                {
                    Berserker player = new Berserker("Player");
                    player.weapons.Add(sword);
                    player.ChangeSelectedWeapon(0);
                    map.Reset();
                    map.AddPlayer(player);
                }
            }
        }
        else if(menu == "Weapon")
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter)
                {
                    menu = "Main";
                }
            }
        }
        else if(menu == "FPS")
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter)
                {
                    menu = "Main";
                }
                else if(key.Key == ConsoleKey.F)
                {
                    string? tempString = Console.ReadLine();
                    if(tempString != null)
                    {
                        float tempFloat = Convert.ToSingle(tempString);
                        if(tempFloat > 0)
                        {
                            gameClock.FPS = tempFloat;
                        }
                    }
                }
            }
        }
        else if(menu == "Layout")
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter)
                {
                    menu = "Main";
                }
                else if(key.Key == ConsoleKey.A)
                {
                    keyboard.SetLayout("AZERTY");
                }
                else if(key.Key == ConsoleKey.Z)
                {
                    keyboard.SetLayout("QWERTZ");
                }
                else if(key.Key == ConsoleKey.Y)
                {
                   keyboard.SetLayout("QWERTY");
                }
            }
        }

    }

    await gameClock.EndFrame();
}