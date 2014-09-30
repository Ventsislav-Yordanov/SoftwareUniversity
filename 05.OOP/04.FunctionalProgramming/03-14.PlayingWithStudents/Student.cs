using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_14.PlayingWithStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public string GroupName { get; set; }

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email,
            List<int> marks, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public override string ToString()
        {
            string marks = String.Join(", ", this.Marks);
            StringBuilder studentInfo = new StringBuilder();
            studentInfo.AppendLine(string.Format("Student: {0} {1}", this.FirstName, this.LastName));
            studentInfo.AppendLine(string.Format("Age: {0}", this.Age));
            studentInfo.AppendLine(string.Format("FacultyNumber: {0}", this.FacultyNumber));
            studentInfo.AppendLine(string.Format("Phone: {0}", this.Phone));
            studentInfo.AppendLine(string.Format("Email: {0}", this.Email));
            studentInfo.AppendLine(string.Format("Marks: {0}", marks));
            studentInfo.AppendLine(string.Format("GroupNumber: {0}", this.GroupNumber));
            studentInfo.AppendLine(string.Format("GroupName: {0}", this.GroupName));
            return studentInfo.ToString();
        }
    }
}
