using System.Diagnostics.Metrics;
using System.Runtime.InteropServices.Marshalling;

public class Berserker : Character
{
    private Health BasicHealth; private Health Shield;
    public float ManaToResistance; public float ManaToStrength; public float ShieldToHealth;
    public void ComputeTotalHealth()
    {
        this.Health.Max = this.BasicHealth.Max + this.Shield.Max * ShieldToHealth;
        this.Health.Current = this.BasicHealth.Current + this.Shield.Current * ShieldToHealth; 
    }

    protected override float ComputeIncomingDamage(float damage)
    {
        return damage * (this.Resistance.CurrentValue + this.Mana.Current * this.ManaToResistance);
    }

    protected override float ComputeDamage()
    {
        if(this.SelectedWeapon == -1)
        {
            return this.Strength.CurrentValue;
        }
        else
        {
            return  this.weapons[this.SelectedWeapon].OutputDamage() * (this.Strength.CurrentValue + this.Mana.Current * this.ManaToStrength);
        }
    }

    public override void Damaged(float damage)
    {
        this.Shield.Current -= this.ComputeIncomingDamage(damage) / ShieldToHealth ;
        if(this.Shield.Current < 0)
        {
            this.Life.Substract(
                this.BasicHealth.Damage(
                    -this.Shield.Current
                    )
                );
            this.Shield.Current = 0;
        }
    }

    public override void Attack(Character target)
    {
        target.Damaged(this.ComputeDamage());
    }

    public override void EndTurn()
    {
        this.Health.Regeneration();
        this.Shield.Regeneration();
    }


    public Berserker(
        string name, 
        string description = "The Berserker Abandonned Magic And Shield For Pure Strength, Resistance And Health (Strength And Resistance Increase By 60% Of Mana, Health Increased By 120% Of Shield)", 
        Health? health = null, 
        Health? shield = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        ) : base(name, description, health, life, strength, resistance, mana)
    {
        ManaToResistance = 6 / 10; ManaToStrength = 6 / 10;
        ShieldToHealth = 12 / 10;

        if(health != null)
        {
            this.BasicHealth = health;
        }
        else
        {
            this.BasicHealth = new Health();
        }

                if(shield != null)
        {
            this.Shield = shield;
        }
        else
        {
            this.Shield = new Health();
        }
    
    }
}