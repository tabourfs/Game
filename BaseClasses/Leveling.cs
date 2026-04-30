using System.Xml.XPath;

public class Leveling(int level = 1, int xp = 0)
{
    private int _level = level;
    private float _xp = xp;

    public int Level
    {
        get{return _level;}
    }
    public float XP
    {
        get{return _xp;}
    }

    public void AddXP(float xp)
    {
        _xp += xp;
        if(_xp >= (_level ^ 2))
        {
            _xp -= _level ^ 2;
            _level += 1;
        }
    }

}