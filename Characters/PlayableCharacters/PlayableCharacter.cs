public abstract class PlayableCharacter : Character, IPlayer
{
    public override char GetSymbol()
    {
        return 'P';
    }
    public virtual string GetPlayerType()
    {
        return "Player";
    }

    public virtual void ShowStatus()
    {
        Console.WriteLine($"Health: {this.Health.Current} / {this.Health.Max}");
        Console.WriteLine($"Life: {this.Life.Current} / {this.Life.Max}");
        Console.WriteLine($"Level: {this.leveling.Level}");
        Console.WriteLine($"XP: {this.leveling.XP}");
    }

    public PlayableCharacter(
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