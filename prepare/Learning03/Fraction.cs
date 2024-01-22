using System;
using System.Globalization;

public class Fraction
{
    public int _top { get; set; }
    public int _bottom { get; set; }

    public Fraction()
    {
        _top = 1;
        _bottom =1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top/(double)_bottom;
    }
}