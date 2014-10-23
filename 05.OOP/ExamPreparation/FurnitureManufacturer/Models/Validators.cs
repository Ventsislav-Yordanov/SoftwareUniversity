using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public static class Validators
    {
        public static void AssertStringSize(string value, int minSize, string propName)
        {
            if (value.Length < minSize)
            {
                throw new ArgumentException(propName + " should be at least" + minSize + " characters!");
            }
        }

        public static void AssertNotEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propertyName, propertyName + " cannot be empty or null!");
            }
        }

        public static void AssertMinValue(dynamic value, int minSize, string propName)
        {
            if (value < minSize)
            {
                throw new ArgumentOutOfRangeException(propName + " cannot be less than " + minSize);
            }
        }
    }
}
