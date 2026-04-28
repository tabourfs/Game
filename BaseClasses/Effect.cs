public class Effect(char type, char stat, float value, bool affectCurrent = true)
{
    private char _type = type; 
    private char _stat = stat;
    private bool _affectCurrent = affectCurrent;
    private float _value = value;

    /*Explainations
    For _type And _stat, char Was Used To Save Memory Usage (Given How Many Will Be Created)
    
    Rules For _type:
    - '+' For Addition
    - '-' For Substraction
    - 'x' For Multiplication
    - '/' For Division

    Rules For _stat:
    - 'P' For Strength, "S" Used By Shield So Strength Is Considered As "Power", Hence The "P"
    - 'R' For Resistance
    - 'H' For Max Health
    - 'C' For Current Health
    - 'S' For Max Shield
    - 'L' For Max Life
    - 'U' For Current Life, "C" Being Already Taken By "Current Health"

    _affectCurrent Is Created To Know If The Current Value Will Be Updated After Increasing The Max Value
    (Applies To: Health, Shield, Life)
    */

    public char Type
    {
        get{return _type;}
    } 
    public char Stat
    {
        get{return _stat;}
    }
    public float Value
    {
        get{return _value;}
    }
    public bool AffectCurrent
    {
        get{return _affectCurrent;}
    }

}