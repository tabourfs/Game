public class Weapon : IUpgradable
{
    public string Name; public string Description;
    public int Quality;
    protected float _damage; public float Range;
    public Cooldown Cooldown;

    public virtual float OutputDamage()
    {
        return this._damage * (1 + this.Quality / 5);
    }

    public Weapon(
        string name, 
        float damage, 
        string description = "", 
        float range = 1, 
        Cooldown? cooldown = null, 
        int quality = 1
        )
    {
        Name = name; Description = description;
        Quality = quality;
        _damage = damage; Range = range;

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