using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SchoolClass : IDetail
    {
        private static IList<string> uniqueIDs;

        private string uniqueID;
        private IList<Teacher> teachers;
        private IList<Student> students;
        private string details;

        static SchoolClass()
        {
            SchoolClass.uniqueIDs = new List<string>();
        }

        public SchoolClass(string uniqueID, IList<Student> students, IList<Teacher> teachers)
        {
            this.UniqueID = uniqueID;
            this.Students = students;
            this.Teachers = teachers;
            //this.Details = details;
            SchoolClass.uniqueIDs.Add(UniqueID); // or uniqueId
        }

        public SchoolClass(string uniqueID, IList<Student> students, IList<Teacher> teachers, string details)
        {
            this.UniqueID = uniqueID;
            this.Students = students;
            this.Teachers = teachers;
            this.Details = details;
            SchoolClass.uniqueIDs.Add(UniqueID); // or uniqueId
        }

        public string UniqueID
        {
            get { return this.uniqueID; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UniqueID", "UniqueID cannot be empty or null");
                }
                if (uniqueIDs.Contains(value))
                {
                    throw new ArgumentException("uniqueId", "The uniqueId is busy");
                }
                this.uniqueID = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get { return this.teachers; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teachers", "Teachers cannot null");
                }
                this.teachers = value;
            }
        }

        public IList<Student> Students
        {
            get { return this.students; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students", "Students cannot be null");
                }
                this.students = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }
    }
}
