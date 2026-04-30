using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security;

public class Map(int displayedWidth = 16,  int displayedHeight = 10, int realWidth = 50, int realHeight = 50)
{
    public int DisplayedWidth = displayedWidth;
    public int DisplayedHeight = displayedHeight;
    public int RealHeight = realHeight;
    public int RealWidth = realWidth;
    private string? _playerType = null;
    private int _playerX = realWidth / 2;
    private int _playerY = realHeight / 2;
    public Random rng = new Random();

    private Character?[,] _map = new Character[realWidth, realHeight];
    private PlayableCharacter? _player = null;
    private List<Enemy> enemies = new List<Enemy>();
    public int PlayerX
    {
        get{return _playerX;}
        set{
            if(value >= 0 || value < RealWidth)
            {
                _playerX = value;
            }
            }
    }
    public int PlayerY
    {
        get{return _playerY;}
        set{
            if(value >= 0 || value < RealHeight)
            {
                _playerY = value;
            }
            }
    }


    public string? PlayerType
    {
        get{return _playerType;}
    }
    public void Display(bool enemyUpdate = false)
    {
        Console.Clear();
        for(int h = - DisplayedHeight / 2; h <= DisplayedHeight / 2 ; h++)
        {
            int height = _playerY + h;
            for(int w = - DisplayedWidth / 2; w <= DisplayedWidth / 2; w++)
            {
                int width = _playerX + w;
                if(width >= 0 && width < RealWidth && height >= 0 && height < RealHeight)
                {
                    if(_map[width, height] != null)
                    {
                        if(_map[width, height] is PlayableCharacter)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;   
                        }
                        else if(_map[width, height] is Enemy)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (enemyUpdate)
                            {
                                bool change = false;
                                int x = w; int y = h;
                                if(width < _playerX - 1)
                                {
                                    x += 1;
                                    change = true;
                                }
                                else if(width > _playerX + 1)
                                {
                                    x -= 1;
                                    change = true;
                                }
                                if(height < _playerY - 1)
                                {
                                    y += 1;
                                    change = true;
                                }
                                else if(height > _playerY + 1)
                                {
                                    y -= 1;
                                    change = true;
                                }

                                if (change)
                                {
                                    if(_map[_playerX + x, _playerY + y] == null)
                                    {
                                        _map[_playerX + x, _playerY + y] = _map[width, height];
                                        _map[width, height] = null;
                                    }
                                    else if(_map[_playerX + x, height] == null)
                                    {
                                        _map[_playerX + x, height] = _map[width, height];
                                        _map[width, height] = null;
                                    }
                                    else if(_map[width, _playerY + y] == null)
                                    {
                                        _map[width, _playerY + y] = _map[width, height];
                                        _map[width, height] = null;
                                    }
                                }
                            }
                        }
                        if(_map[_playerX + w, _playerY + h] != null)
                        {
                            Console.Write($"[{_map[_playerX + w, _playerY + h].GetSymbol()}]");
                        }
                        Console.ForegroundColor = ConsoleColor.White;  
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                else
                {
                    Console.Write(" x ");
                }
                
            }
            Console.WriteLine();
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        bool error = true;
        while(error)
        {
            int x = rng.Next(RealWidth + 1);
            int y = rng.Next(RealHeight + 1);

            if(x > _playerX - DisplayedWidth / 2 && x < _playerX + DisplayedWidth)
            {
                if(x < _playerX || _playerX + DisplayedWidth / 2 > RealWidth)
                {
                    x = _playerX - DisplayedWidth / 2; error = false;
                }
                else if(x >= _playerX || _playerX - DisplayedWidth / 2 < RealWidth)
                {
                    x = _playerX + DisplayedWidth / 2; error = false;
                }
            }

            if(y > _playerY - DisplayedHeight / 2 && y < _playerY + DisplayedHeight)
            {
                if(y < _playerY || _playerY + DisplayedHeight / 2 > RealHeight)
                {
                    y = _playerY - DisplayedHeight / 2; error = false;
                }
                else if(y >= _playerY || _playerY - DisplayedHeight / 2 < RealHeight)
                {
                    y = _playerY + DisplayedHeight / 2; error = false;
                }
                else
                {
                    error = true;
                }
            }
            if (!error)
            {
                _map[x, y] = enemy;
                enemies.Add(enemy);
            }
        }    
    }

    public void AddPlayer(PlayableCharacter playableCharacter)
    {
        _map[_playerX, _playerY] = playableCharacter;
        _player = playableCharacter;
        _playerType = playableCharacter.GetPlayerType();

    }

    public void PlayerAttack()
    {
        for(
            int h = (int) -_player.weapons[_player.GetSelectedWeapon].Range;
            h < (int) _player.weapons[_player.GetSelectedWeapon].Range;
            h++
        )
        {
            for(
            int w = (int) -_player.weapons[_player.GetSelectedWeapon].Range;
            w < (int) _player.weapons[_player.GetSelectedWeapon].Range;
            w++
        )
            {
                if(_map[_playerX + w, _playerY + h] is Enemy)
                {
                    _player.Attack(_map[_playerX + w, _playerY + h]);
                }
            }
        }
    }

    public void EndTurn()
    {
        _player.EndTurn();
        foreach(Enemy enemy in enemies)
        {
            enemy.EndTurn();
        }
    }

    public void Reset()
    {
        this.enemies = new List<Enemy>();
        this._map = new Character[RealWidth, RealHeight];
        this._playerType = null;
        this._playerY = RealHeight / 2;
        this._playerX = RealWidth/ 2;
    }
}