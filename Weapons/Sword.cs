public class Sword : Weapon
{
    public Sword(
        string name, 
        float damage, 
        string description = "", 
        float range = 1, 
        Cooldown? cooldown = null, 
        int quality = 1
        ) : base (name, damage, description, range, cooldown, quality)
    {
        
    }
}