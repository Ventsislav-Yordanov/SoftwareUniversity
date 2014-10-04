using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Discipline : IDetail
    {
        private string name;
        private int NumberOfLecutres;
        private IList<Student> students;
        private string details;

        public Discipline(string name, IList<Student> students, int numberOfLectures, string details = null)
        {
            this.Name = name;
            this.Students = students;
            this.NumberOfLecutres = numberOfLectures;
            this.Details = details;
        }

        public IList<Student> Students
        {
            get { return this.students; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students list", "Students cannot be null");
                }
                this.students = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.NumberOfLectures; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of lectures", "Number of lectures cannot be negative or zero!");
                }
                this.NumberOfLectures = value;
            }
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
