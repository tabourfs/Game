public class Strength(float value = 10, float? current = null) : Stat(value, current)
{
    public float BaseValue
    {
        get{return _max;}
    }
    public float CurrentValue
    {
        get{return _current;}
    }
}