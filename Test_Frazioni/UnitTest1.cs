using Frazioni;

namespace Test_Frazioni;

public class Tests
{
    [Test]
    public void TestFractionConstructorWithDenominatorZero()
    {
        Assert.That(() => new Fraction(35, 0), Throws.ArgumentException);
    }

    [Test]
    public void TestFractionSimplyfyFunction()
    {

        var f = new Fraction(2, 4);

        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(1));
            Assert.That(f.Denominator, Is.EqualTo(2));
        });
    }


    [Test]
    public void TestFractionConstructorWithNegativeDenominator()
    {
        var actual = new Fraction(1, -1);
        Assert.Multiple(() =>
        {
            Assert.That(actual.Numerator, Is.EqualTo(-1));
            Assert.That(actual.Denominator, Is.EqualTo(1));
        });
    }
    
    

    [Test]
    public void TestFractionSum()
    {
        var operand1 = new Fraction(1, 2);
        var operand2 = new Fraction(2, 5);

        var result = operand1 + operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(9));
            Assert.That(result.Denominator, Is.EqualTo(10));
        });
    }

    [Test]
    public void TestFractionSubtraction()
    {

        var operand1 = new Fraction(4, 1);
        var operand2 = new Fraction(33, 7);

        var result = operand1 - operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(-5));
            Assert.That(result.Denominator, Is.EqualTo(7));
        });
    }

    [Test]
    public void TestFractionMultiplication()
    {
        var operand1 = new Fraction(1, 11);
        var operand2 = new Fraction(11, 1);

        var result = operand1 * operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(1));
            Assert.That(result.Denominator, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestFractionDivision()
    {
        var f1 = new Fraction(33, 42);
        var f2 = new Fraction(111, 8);

        var result = f1 / f2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(44));
            Assert.That(result.Denominator, Is.EqualTo(777));
        });
    }

    [Test]
    public void TestFractionMultiplicationWithZero()
    {
        var operand1 = new Fraction(42, 1);
        var operand2 = 0;

        var result = operand1 * operand2;
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(0));
            Assert.That(result.Denominator, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestFractionDivisionWithZero()
    {
        var operand = new Fraction(42, 1);

        Assert.That(() => operand / 0, Throws.ArgumentException);
    }

    [Test]
    public void TestFractionMethodEqualsWithNoSimplification()
    {
        var f1 = new Fraction(0, 1);
        var f2 = new Fraction(0, 22);

        Assert.That(f1.Equals(f2), Is.True);
    }

    [Test]
    public void TestFractionMethodEqualsWithSimplification()
    {
        var f1 = new Fraction(1, 2);
        var f2 = new Fraction(2, 4);

        Assert.That(f1.Equals(f2), Is.True);
    }
    [Test]
    public void TestFractionToString()
    {
        var f = new Fraction(11, 5);

        Assert.That(f.ToString(), Is.EqualTo("11/5"));
    }
    [Test]
    public void TestFractionToStringWithDenominator1()
    {
        var f = new Fraction(22, 11);

        Assert.That(f.ToString(), Is.EqualTo("2"));
    }
    [Test]
    public void TestFractionToStringWithDenominatorNegative1()
    {
        var f = new Fraction(22, -11);

        Assert.That(f.ToString(), Is.EqualTo("-2"));
    }
    [Test]
    public void TestIntToFraction()
    {
        var f = new Fraction(42);

        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(42));
            Assert.That(f.Denominator, Is.EqualTo(1));
        });
    }
    [Test]
    public void TestZeroToFraction()
    {
        var f = new Fraction(0);
        
        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(0));
            Assert.That(f.Denominator, Is.EqualTo(1));
        });
    }
    [Test]
    public void TestFractionToInt()
    {
        var f = new Fraction(42, 1);

        Assert.That(f.ToInt(), Is.EqualTo(42));
    }
    [Test]
    public void TestFractionToIntException()
    {
        var f = new Fraction(42, 11);

        Assert.That( () => f.ToInt(), Throws.ArgumentException);
    }

}