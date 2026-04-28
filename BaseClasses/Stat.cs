public abstract class Stat
{
    protected float _current;
    protected float _max;

    public Stat(
        float value,
        float? current
    )
    {
        _max = value;
        if (current == null)
        {
            _current = value;
        }
        else
        {
            _current = (float)current;
        }
    }
}