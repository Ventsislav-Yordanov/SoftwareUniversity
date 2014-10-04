using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public abstract class People : IDetail
    {
        private string name;
        private string details;

        protected People(string name)
        {
            this.Name = name;
        }

        protected People(string name, string details) 
            : this(name)
        {
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty or null!");
                }
                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }
    }
}
