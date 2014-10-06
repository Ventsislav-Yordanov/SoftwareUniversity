using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentAndWorker
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("facultyNumber", "facultyNumber cannot be empty or null");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("facultyNumber",
                        "facultyNumber must have faculty number with 5-10digits/letters");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("First name : {0}, Last name : {1}, Faculty Number : {2}",
                this.FirstName, this.LastName, this.facultyNumber);
        }
    }
}
