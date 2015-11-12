namespace EgyptianFractions
{
    using System;

    public class Fraction : IComparable<Fraction>
    {
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator { get; set; }

        public int Denominator { get; set; }

        public int CompareTo(Fraction other)
        {
            return (this.Numerator * other.Denominator).CompareTo(other.Numerator * this.Denominator);
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            int nominator = first.Numerator * second.Denominator - second.Numerator * first.Denominator;
            int denominator = first.Denominator * second.Denominator;
            return new Fraction(nominator, denominator);
        }

        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }
    }
}
