public class LesserDemon : Enemy
{
    public override void Attack(Character target)
    {
        target.Damaged(this.ComputeDamage());
    }
    public override void Damaged(float damage)
    {
        this.Life.Substract(
            this.Health.Damage(
                    this.ComputeIncomingDamage(
                        damage
                        )
                )
            );
    }

    public override char GetSymbol()
    {
        return 'D';
    }

    public LesserDemon(
        string name, 
        string description = "The Most Basic Enemy", 
        Health? health = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        ) : base (name, description, health, life, strength, resistance, mana)
    {
        if(health == null)
        {
            this.Health.Max = 50;
            this.Health.Current = 50;
        } 
    }
}