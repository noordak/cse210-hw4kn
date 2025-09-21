//Fration file

using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    //integers
    public Fraction()
    {
    
        _top = 1;
        _bottom = 1;
    }


    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    //integers
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    //String 
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }


}