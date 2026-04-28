public class Health(float value = 100, float regeneration = 0, float? current = null) : Stat(value, current), IRegeneration
{
    private float _regenerationAmount = regeneration;
    public float Current
    {
        get{return this._current;}
        set{_current = value;}
    }
    public float Max
    {
        get{return _max;}
        set
        {
            if (value > 0)
            {
                this._max = value;
            }
        }
    }
    public float RegenerationAmount
    {
        get{return _regenerationAmount;}
        set{_regenerationAmount = value;}
    }
    public float Damage(float damage)
    {
        this._current -= damage;
        if (this._current < 0)
        {
            this._current = this._max;
            return 1;
        }
        return 0;
    }

    public void Regeneration(bool full = false, float? specialValue = null)
    {
        if (full)
        {
            this._current = this._max;
        }
        else if (specialValue != null)
        {
            this._current += (float)specialValue;
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