using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace FRACT;

public class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0) throw new ArgumentException();
        this.Numerator = numerator;
        this.Denominator = denominator;
        if (denominator < 0)
        {
            this.Numerator *= -1;
            this.Denominator *= -1;
        }
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
        return (this.Numerator / this.Denominator == f.Numerator / f.Denominator);
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

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int n = f1.Numerator * f2.Denominator;
        int d = f1.Denominator * f2.Numerator;

        return new Fraction(n, d);
    }

    public static void Normalize(int n, int d)
    {

    }
    public int Numerator { get; }
    public int Denominator { get; }

}