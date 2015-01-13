using System;

namespace Abstraction
{
    public abstract class Figure
    {
        public abstract double CalcPerimeter();
        public abstract double CalcArea();
        public override string ToString()
        {
            return string.Format("Figure type name : {0}. Perimeter: {1:f2}. Surface: {2:f2}.",
                this.GetType().Name, this.CalcPerimeter(), this.CalcArea());
        }
    }
}
