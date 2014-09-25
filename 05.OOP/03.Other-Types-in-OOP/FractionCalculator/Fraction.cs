using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) 
            :this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set
            {
                if (value < long.MinValue || value > long.MaxValue)
                {
                    throw new OverflowException("The numerator is outside the range, allowed for long integers");
                }
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero!");
                }
                if (value < long.MinValue || value > long.MaxValue)
                {
                    throw new OverflowException("The denominator is outside the range, allowed for long integers");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            checked // http://www.dotnetperls.com/checked
            {
                long numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
                long denominator = f1.Denominator * f2.Denominator;
                return new Fraction(numerator, denominator);
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            checked
            {
                long numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
                long denominator = f1.Denominator * f2.Denominator;
                return new Fraction(numerator, denominator);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", (decimal)this.Numerator / this.Denominator);
        }
    }
}
