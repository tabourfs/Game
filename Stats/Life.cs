public class Life(float value = 1, float regeneration = 0, float? current = null) : Stat(value, current), IRegeneration
{
    private float _regenerationAmount = regeneration;
    private bool _dead = false;

    public bool Dead
    {
        get{return this._dead;}
    }
    public float Current
    {
        get{return this._current;}
    }
    public float Max
    {
        get{return _max;}
        set
        {
            if (value >= 1)
            {
                this._max = value;
            }
        }
    }
    public void Add(float number = 1)
    {
        this._current += number;
    }
    public void Substract(float number = 1)
    {
        this._current -= number;
        if(this._current < 0)
        {
            this._dead = true;
        }
    }
    public float RegenerationAmount
    {
        get{return _regenerationAmount;}
        set{_regenerationAmount = value;}
    }

    public void Regeneration(bool full = false)
    {
        if (full)
        {
            this._current = this._max;
        }
        else
        {
            this._current += this._regenerationAmount;
            if (this._current > this._max)
            {
                this._current = this._max;
            }
        }
    }
}