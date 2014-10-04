using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentAndWorker
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName", "firstName cannot be empty or null!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName ; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName", "firstName cannot be empty or null!");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("First name : {0}, Last name : {1}", this.FirstName, this.LastName);
        }
    }
}
