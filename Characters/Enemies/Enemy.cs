public abstract class Enemy : Character
{
    public Enemy(
        string name, 
        string description = "", 
        Health? health = null, 
        Life? life = null,
        Strength? strength = null,
        Resistance? resistance = null,
        Mana? mana = null
        ) : base(name, description, health, life, strength, resistance, mana)
    {
        
    }
    
}