using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : People
    {
        private static IList<string> busyClassNumbers;
        private string uniqueClassNumber;

        static Student()
        {
            Student.busyClassNumbers = new List<string>();
        }

        public Student(string name, string uniqueClassNumber)
            : base(name)
        {
            this.UniqueClassNumber = uniqueClassNumber;
            Student.busyClassNumbers.Add(uniqueClassNumber);
        }

        public Student(string name, string uniqueClassNumber, string details = null) // details = null
            : this(name, uniqueClassNumber)
        {
            this.Details = details;
        }

        public string UniqueClassNumber
        {
            get { return this.uniqueClassNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("UniqueClassNumber", "UniqueClassNumber cannot be emtpy or null!");
                }
                if (busyClassNumbers.Contains(value))
                {
                    throw new ArgumentException("UniqueClassNumber", "Unique class number is busy!");
                }
                this.uniqueClassNumber = value;
            }
        }
    }
}
