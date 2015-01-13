using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name, string teacherName = null, IList<string> students = null)
            :base(name, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value != null && value.Length < 2)
                {
                    throw new ArgumentException("Lab cannot be less thna two characters");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return base.ToString() + result.ToString();
        }
    }
}
