using System.Diagnostics;
using System.IO.Compression;

public class BasicCard: Card
{
    public List<Effect> Effects;

    
    public BasicCard(List<Effect>? effects = null)
    {
        if(effects != null)
        {
            this.Effects = effects;
        }
        else
        {
            this.Effects = new List<Effect>();
        }
    }
}