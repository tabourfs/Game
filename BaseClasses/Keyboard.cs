using System.Runtime.InteropServices;

public class Keyboard()
{
    private ConsoleKey _right = ConsoleKey.D;
    private ConsoleKey _left = ConsoleKey.A;
    private ConsoleKey _up = ConsoleKey.W;
    private ConsoleKey _down = ConsoleKey.S;
    private string _layout = "QWERTZ";
    public ConsoleKey Right
    {
        get{return _right;}
    }
    public ConsoleKey Left
    {
        get{return _left;}
    }
    public ConsoleKey Up
    {
        get{return _up;}
    }
    public ConsoleKey Down
    {
        get{return _down;}
    }
    public string Layout
    {
        get{return _layout;}
    }
    public void SetLayout(string layout)
    {
        switch (layout)
        {
            case "QWERTZ":
            _right = ConsoleKey.D;
            _left = ConsoleKey.A;
            _up = ConsoleKey.W;
            _down = ConsoleKey.S;
            _layout = "QWERTZ";
            break;
            case "QWERTY":
            _right = ConsoleKey.D;
            _left = ConsoleKey.A;
            _up = ConsoleKey.W;
            _down = ConsoleKey.S;
            _layout = "QWERTY";
            break;
            case "AZERTY":
            _right = ConsoleKey.D;
            _left = ConsoleKey.Q;
            _up = ConsoleKey.Z;
            _down = ConsoleKey.S;
            _layout = "AZERTY";
            break;
            default:
            break;
        }
    } 
    
}