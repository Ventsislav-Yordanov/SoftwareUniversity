using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : People
    {
        private IList<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines) // details = null test!
            : this(name)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, List<Discipline> disciplines, string details)
            : this(name, disciplines)
        {
            this.Details = details;
        }

        public IList<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Disciplines", "Disciplines cannot be null!");
                }
                this.disciplines = value;
            }
        }
    }
}
