public class Knight : PlayableCharacter
{
    public Shield Shield;
    public override void Attack(Character target)
    {
        target.Damaged(this.ComputeDamage());
    }
    public override void Damaged(float damage)
    {
        this.Life.Substract(
            this.Health.Damage(
                this.Shield.Damage(
                    this.ComputeIncomingDamage(
                        damage
                        )
                    )
                )
            );
    }
    public override void EndTurn()
    {
        this.Health.Regeneration();
        this.Shield.Regeneration();
    }

    public Knight(
        string name, 
        string description = "The Knight Is A Basic But Balanced Character", 
        Health? health = null, 
        Shield? shield = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        ) : base (name, description, health, life, strength, resistance, mana)
    {
        if (shield != null)
        {
            this.Shield = shield;
        }
        else
        {
            this.Shield = new Shield();
        }
    }
}