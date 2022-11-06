using FRACT;
using NuGet.Frameworks;

namespace Test_Frazioni
{
    public class Tests
    {
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
        public void TestFractionConstructorWithDenominatorZero()
        {
            Assert.That(() => new Fraction(35, 0), Throws.ArgumentException);
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

        public void TestFractionSub()
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
                Assert.That(result.Numerator, Is.EqualTo(11));
                Assert.That(result.Denominator, Is.EqualTo(11));
            });
        }

        [Test]

        public void TestFractionEquals()
        {
            var f1 = new Fraction(0, 1);
            var f2 = new Fraction(0, 22);

            Assert.That(f1.Equals(f2), Is.True);
        }


    }
}