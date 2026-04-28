using System.Dynamic;
using System.Net;

public abstract class Character: IEndTurn
{   protected string _name; protected string _description;
    public Health Health;

    public Life Life;
    public Strength Strength;
    public Resistance Resistance;
    public Mana Mana;
    public List<Card> Cards = new List<Card>();
    

    public string Name
    {
        get{return _name;}
    }
    public string Description
    {
        get{return _description;}
    }

    public virtual void Attack(Character target)
    {
        
    }

    protected virtual float ComputeDamage(float damage)
    {
        return damage * this.Strength.CurrentValue;
    }
    protected virtual float ComputeIncomingDamage(float damage)
    {
        return damage * this.Resistance.CurrentValue;
    }
    public virtual void Damaged(float damage)
    {
        
    }

    public virtual void EndTurn()
    {
        
    }

    public Character(
        string name, 
        string description = "", 
        Health? health = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        )
    {
        _name = name; _description = description;

        if(health != null)
        {
            this.Health = health;
        }
        else
        {
            this.Health = new Health();
        }

        if(life != null)
        {
            this.Life = life;
        }
        else
        {
            this.Life = new Life();
        }

        if(strength != null)
        {
            this.Strength = strength;
        }
        else
        {
            this.Strength = new Strength();
        }

        if(resistance != null)
        {
            this.Resistance = resistance;
        }
        else
        {
            this.Resistance = new Resistance();
        }
        
        if(mana != null)
        {
            this.Mana = mana;
        }
        else
        {
            this.Mana = new Mana();
        }

    }
}