using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_14.PlayingWithStudents
{
    public class PlayWithStudents
    {
        static void Main(string[] args)
        {
            // FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber, GroupName
            Student mitko = new Student("Dimitar", "Obretenov", 33, 102014, "02/353-38-27",
                    "MitkoLudiq@abv.bg", new List<int>() { 6, 6, 5, 6, 4, 5, 6 }, 17, "Excellent");

            Student Alex = new Student("Alex", "Purvanov", 30, 192114, "+359899402793",
                    "AlexK@abv.bg", new List<int>() { 2, 2, 2, 2, 4, 3, 2 }, 2, "Weak");

            Student Gosho = new Student("Georgi", "Atanasov", 24, 102016, "+359883344355",
                    "Goshkata@abv.bg", new List<int>() { 4, 4, 4, 4, 3, 5, 4 }, 21, "Medium");

            Student Svetlio = new Student("Svetoslav", "Petrov", 22, 102010, "+359883665578",
                    "Svetlqzata@gmail.com", new List<int>() { 6, 6, 5, 6, 6, 6, 6 }, 2, "Excellent");

            Student Rosko = new Student("Rostislav", "Savov", 20, 333014, "+359889342655",
                    "RostislavSavov@abv.bg", new List<int>() { 2, 2, 3, 6, 6, 5, 4 }, 23, "Weak");

            List<Student> students = new List<Student>() { mitko, Alex, Gosho, Svetlio, Rosko };

            //04.Students by Group
            var studentsWithGroupNumber2 =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("----Students with group number = 2. Ordered by FirstName----- \n");
            foreach (var student in studentsWithGroupNumber2)
            {
                Console.WriteLine(student);
            }

            //05.Students by First and Last Name
            var studentsByFirstAndLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0 // http://www.dotnetperls.com/string-compare
                select student;

            Console.WriteLine("-----Students by First and Last Name----- \n");
            foreach (var student in studentsByFirstAndLastName)
            {
                Console.WriteLine(student);
            }

            //06.Students by Age
            var studentsByAge =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { student.FirstName, student.LastName, student.Age };

            Console.WriteLine("-----Students by Age----- \n");
            foreach (var student in studentsByAge)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //07.Sort Students
            var sortedStudents = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            Console.WriteLine("-----Sort Students in descending order with lambda expressions----- \n");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            var sortedStudentsWithLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine("-----Sort Students in descending order with LINQ query syntax----- \n");
            foreach (var student in sortedStudentsWithLINQ)
            {
                Console.WriteLine(student);
            }

            //08.Filter Students by Email Domain
            var filterByEmailDomain =
                from student in students
                where student.Email.EndsWith("@abv.bg")
                select student;

            Console.WriteLine("-----Filter Students by Email Domain----- \n");
            foreach (var student in filterByEmailDomain)
            {
                Console.WriteLine(student);
            }

            //09.Filter Students by Phone
            var filterByPhone =
                from student in students
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                select student;

            Console.WriteLine("-----Filter Students by Phone----- \n");
            foreach (var student in filterByPhone)
            {
                Console.WriteLine(student);
            }

            //10.Excellent Students
            var excellentStudents =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("-----Excellent Students----- \n");
            foreach (var student in excellentStudents)
            {
                string marks = string.Join(", ", student.Marks);
                Console.WriteLine("{0}: {1}", student.FullName, marks);
            }
            Console.WriteLine();

            //11.Weak Students
            var weakStudents = students
                .Where(student => student.Marks
                    .Where(mark => mark == 2).Count() == 2);

            Console.WriteLine("-----Weak Students----- \n");
            foreach (var student in weakStudents)
            {
                Console.WriteLine(student);
            }

            //12.Students Enrolled in 2014
            var enrolledIn2014 =
                from student in students
                where student.FacultyNumber % 100 == 14
                select new { Marks = student.Marks };

            Console.WriteLine("-----Marks of the students that enrolled in 2014----- \n");
            foreach (var student in enrolledIn2014)
            {
                string marks = string.Join(", ", student.Marks);
                Console.WriteLine(marks);
            }
            Console.WriteLine();

            //13.*Students by Groups
            // http://www.dotnetperls.com/groupby
            // http://www.dotnetperls.com/group for LINQ
            var groups =
                from student in students
                group student by student.GroupName into g
                orderby g.Key
                select g;

            int studentsByGroupCounter = 0;
            foreach (var group in groups)
            {
                var tempStudents = students.Where(student => student.GroupName == group.Key);
                Console.WriteLine("Group \"{0}\" \n", group.Key);
                foreach (var student in tempStudents)
                {
                    studentsByGroupCounter++;
                    Console.WriteLine(studentsByGroupCounter + ". \n" + student);
                }
                studentsByGroupCounter = 0;
            }

            //14.*Students Joined to Specialties
            StudentSpecialty MitkoSpeciality = new StudentSpecialty("Web Developer", 102014);
            StudentSpecialty AlexSpeciality = new StudentSpecialty("PHP Engineer", 192114);
            StudentSpecialty exampleSpecialty = new StudentSpecialty("C# Programmer", 123456);
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            specialties.Add(MitkoSpeciality);
            specialties.Add(AlexSpeciality);
            specialties.Add(exampleSpecialty);

            var studentsWithSpecialties =
                from specialty in specialties
                join student in students on specialty.FacNum equals student.FacultyNumber // http://www.dotnetperls.com/join
                select new { student, FacultyName = specialty.SpecialtyName };

            Console.WriteLine("-----Students Joined to Specialties------ \n");
            foreach (var student in studentsWithSpecialties)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }
    }
}
