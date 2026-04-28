using System.Security;

public class Map(int displayedWidth = 50,  int displayedHeight = 40, int realWidth = 100, int realHeight = 100)
{
    public int displayedWidth = displayedWidth;
    public int displayedHeight = displayedHeight;
    public int realHeight = realHeight;
    public int realWidth = realWidth;
    private int _playerX = realWidth / 2;
    private int _playerY = realHeight / 2;
    public Random rng = new Random();

    private Character[,] _map = new Character[realWidth, realHeight];
    private List<Character> characters = new List<Character>();

    public void Display()
    {
        Console.Clear();
        for(int h = - displayedHeight / 2; h <= displayedHeight / 2; h++)
        {
            for(int w = - displayedWidth / 2; h <= displayedWidth /2; w++)
            {
                if(_map[_playerX + w, _playerY + h] != null)
                {
                    Console.Write(_map[_playerX + w, _playerY + h].GetSymbol());
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }

    public void Add(Character character, bool player = false)
    {
        if (player)
        {
            _map[_playerX, _playerY] = character;
            characters.Add(character);
        }
        else
        {
            bool error = true;
            while(error)
            {
                int x = rng.Next(realWidth + 1);
                int y = rng.Next(realHeight + 1);

                if(x > _playerX - displayedWidth / 2 && x < _playerX + displayedWidth)
                {
                    if(x < _playerX || _playerX + displayedWidth / 2 > realWidth)
                    {
                        x = _playerX - displayedWidth / 2; error = false;
                    }
                    else if(x >= _playerX || _playerX - displayedWidth / 2 < realWidth)
                    {
                        x = _playerX + displayedWidth / 2; error = false;
                    }
                }

                if(y > _playerY - displayedHeight / 2 && y < _playerY + displayedHeight)
                {
                    if(y < _playerY || _playerY + displayedHeight / 2 > realHeight)
                    {
                        y = _playerY - displayedHeight / 2; error = false;
                    }
                    else if(y >= _playerY || _playerY - displayedHeight / 2 < realHeight)
                    {
                        y = _playerY + displayedHeight / 2; error = false;
                    }
                    else
                    {
                        error = true;
                    }
                }

                if (!error)
                {
                    _map[x, y] = character;
                    characters.Add(character);
                }

            }
            
        }
    }
}