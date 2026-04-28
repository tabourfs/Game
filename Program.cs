// See https://aka.ms/new-console-template for more information

GameClock gameClock = new GameClock();

bool test = true;
int n = 0;
gameClock.FPS = 1;
while (test)
{
    gameClock.StartFrame();
    Console.WriteLine(n); n++;
    Console.WriteLine("test");
    
    await gameClock.EndFrame();
}