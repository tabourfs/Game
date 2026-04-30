using System.ComponentModel;
using System.Diagnostics;

public class GameClock(float fps = 60)
{
    public float FPS = fps;
    public long TimeElasped = 0;

    public void StartFrame()
    {
        Console.Clear();
        this.TimeElasped = DateTime.Now.Ticks;
    }
    public async Task EndFrame()
    {
        this.TimeElasped = (DateTime.Now.Ticks - this.TimeElasped) / TimeSpan.TicksPerMillisecond;
        if((int)(1000/FPS - this.TimeElasped) > 0)
        {
            await Task.Delay(
                (int)(1000/FPS - this.TimeElasped)
            );
        }
        
    }
}