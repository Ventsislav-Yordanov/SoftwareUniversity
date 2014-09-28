using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class InterestCalculator
    {
        private decimal moneySum;
        private decimal interest;
        private int years;
        private decimal result;

        public InterestCalculator(decimal moneySum, decimal interest, int years, CalculateInterest simpleOrCompound)
        {
            this.MoneySum = moneySum;
            this.Interest = interest;
            this.Years = years;
            this.Result = simpleOrCompound(moneySum, interest, years);
        }

        public delegate decimal CalculateInterest(decimal moneySum, decimal interest, int years);

        public decimal MoneySum
        {
            get { return this.moneySum; }
            set { this.moneySum = value; }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Interest cannot be negative!");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Years cannot be negaite!");
                }
                this.years = value;
            }
        }

        public decimal Result
        {
            get { return this.result; }
            set { this.result = value; }
        }
    }
}
