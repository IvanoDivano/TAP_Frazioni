using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Xml.Schema;

namespace Frazioni_IvanoDivano;

public class Fraction
{
    public Fraction(int n, int d)
    {
        if (d == 0) throw new ArgumentException("Denominator cannot be zero");
        if (d < 0)
        {
            n *= -1;
            d *= -1;
        }
        
        Simplyfy(ref n, ref d);

        this.Numerator = n;
        this.Denominator = d;
    }

    public Fraction(int n)
    {
        this.Numerator = n;
        this.Denominator = 1;
    }

    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return f1.Equals(f2);
    }

    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !f1.Equals(f2);
    }

    public override bool Equals(object o)
    {
        Fraction f = o as Fraction;
        return this.Numerator * f.Denominator == this.Denominator * f.Numerator;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int n = (f1.Numerator*f2.Denominator) + (f2.Numerator*f1.Denominator);
        int d = (f1.Denominator * f2.Denominator);

        return new Fraction(n, d);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int n = (f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator);
        int d = (f1.Denominator * f2.Denominator);

        return new Fraction(n, d);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int n = f1.Numerator * f2.Numerator;
        int d = f1.Denominator * f2.Denominator;

        return new Fraction(n, d);
    }

    public static Fraction operator *(Fraction f, int n)
    {
        return new Fraction(f.Numerator * n, f.Denominator);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int n = f1.Numerator * f2.Denominator;
        int d = f1.Denominator * f2.Numerator;

        return new Fraction(n, d);
    }

    public static Fraction operator /(Fraction f, int n)
    {
        if (n == 0){ throw new ArgumentException("Cannot divide by 0"); }
        
        return new Fraction(f.Numerator, f.Denominator * n);
    }

    public void Simplyfy(ref int n, ref int d)
    {

        if (n == d)
        {
            n = 1;
            d = 1;
            return;
        }

        int mcd;
        if (n < 0)
        {
            mcd = MCD(-n, d);

        }
        else
        {
            mcd = MCD(n, d);
        }
        
        n /= mcd;
        d /= mcd;
    }

    private static int MCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b) a %= b;
            else b %= a;
        }

        return a == 0 ? b : a;
    }



    public int ToInt()
    {
        if (Denominator != 1) { throw new ArgumentException("Cannot convert to int, denominator is not 1"); }
        
        return Numerator;
    }

    public override string ToString()
    {
        if (Denominator == 1) { return Numerator.ToString(); }
        
        return Numerator.ToString() + "/" + Denominator.ToString();
    }
    public int Numerator { get; }
    public int Denominator { get; }
}