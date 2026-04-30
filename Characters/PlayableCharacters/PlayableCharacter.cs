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