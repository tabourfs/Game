public class Shield: Stat
{
    private float _regenerationAmount;
    public Cooldown Cooldown;
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
        if (this._current > 0)
        {
            this._current -= damage;
            this.Cooldown.Current = this.Cooldown.Value;

            if (this._current < 0)
            {
                damage = -this._current;
                this._current = 0;
                return damage;
            }
            return 0;
        }
        else
        {
            return -damage;
        }
        
    }

    public void Regeneration(bool full = false)
    {
        if (this.Cooldown.Current == 0)
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
        else
        {
            this.Cooldown.Current -= 1;
        }
        
    }

    public Shield(
        float value = 100, 
        float regeneration = 4, 
        Cooldown? cooldown = null, 
        float? current = null
        ) : base (value, current)
    {
        float _regenerationAmount = regeneration;

        if (cooldown != null)
        {
            this.Cooldown = cooldown;
        }
        else
        {
            this.Cooldown = new Cooldown();
        }
    }
}