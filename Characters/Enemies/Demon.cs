public class Demon : Enemy
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

    public Demon(
        string name, 
        string description = "The Most Basic Enemy", 
        Health? health = null, 
        Shield? shield = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        ) : base (name, description, health, life, strength, resistance, mana)
    {
        
    }
}