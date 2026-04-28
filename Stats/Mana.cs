public class Mana(float value = 100, float regeneration = 0, float? current = null): Stat(value, current)
{
    private float _regenerationAmount = regeneration;
    public float Current
    {
        get{return this._current;}
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
        this._current += damage;
        if (this._current < 0)
        {
            damage = - this._current;
            this._current = 0;
            return damage;
        }
        return 0;
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