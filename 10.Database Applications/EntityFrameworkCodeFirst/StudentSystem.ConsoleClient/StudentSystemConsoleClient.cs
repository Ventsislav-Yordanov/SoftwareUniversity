namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Entities;
    using System.Text;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            var data = new StudentSystemData();

            AddCourse(
                data,
                "C# Basics",
                "C# IS AWESOMEEEEEEEEEEEE",
                new DateTime(2014, 2, 5),
                new DateTime(2014, 3, 6),
                0m);

            AddCourse(
                data,
                "Databases",
                "Databases ARE AWESOMEEEEEEEEEEEE",
                new DateTime(2014, 2, 5),
                new DateTime(2014, 3, 6),
                0m);

            AddCourse(
                data,
                "Database Apps",
                "Database Apps ARE AWESOMEEEEEEEEEEEE",
                new DateTime(2014, 2, 5),
                new DateTime(2014, 3, 6),
                0m);

            //AddCourseResource(
            //    data,
            //    "Entity-Framework-Code-First-Demos",
            //    "http://svn.softuni.org/admin/svn/db-apps/materials/Entity-Framework-Code-First-Demos.zip",
            //    TypeOfResource.Document,
            //    2);

            //AddStudent(
            //    data,
            //    "Pesho",
            //    new DateTime(2014, 12, 20),
            //    new DateTime(1994, 10, 5),
            //    "0883247910");

            //AddCourseWithResource(
            //    data,
            //    "JS Advanced",
            //    "JavaScript course for advanced programmers",
            //    new DateTime(2015, 02, 27),
            //    new DateTime(2015, 04, 21),
            //    0m,
            //    "JSAdvanced Function Expressions Demo",
            //    "https://github.com/SoftUni/Advanced-JavaScript/tree/master/1.%20Functions-and-Function-Expressions",
            //    TypeOfResource.CodeStubs,
            //    3);

            //AddHomework(data, "Sorry i have no homework", ContentType.txt, new DateTime(2015, 3, 2), 1, 5);

            ListCoursesWithResources(data);
            ListStudentsWithHomeworks(data);

        }

        private static int AddCourse(StudentSystemData data, string name, string description, DateTime startDate,
            DateTime endDate, decimal price)
        {
            Course course = new Course
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };

            data.Courses.Add(course);
            return data.SaveChanges();
        }

        private static int AddResource(StudentSystemData data, string name, string link, 
            TypeOfResource typeOfResource, int courseId)
        {
            Resource resource = new Resource
            {
                Name = name,
                Link = link,
                TypeOfResource = typeOfResource,
                CourseId = courseId
            };

            data.Resources.Add(resource);
            return data.SaveChanges();
        }

        private static int AddStudent(StudentSystemData data, string name, DateTime registrationDate,
            DateTime birthday, string phoneNumber)
        {
            Student student = new Student
            {
                Name = name,
                RegistrationDate = registrationDate,
                BirthDay = birthday,
                PhoneNumber = phoneNumber
            };

            data.Students.Add(student);
            return data.SaveChanges();
        }

        private static int AddHomework(StudentSystemData data, string content, ContentType contentType, DateTime dateSubmitted,
            int studentId, int courseId)
        {
            Homework homework = new Homework
            {
                Content = content,
                ContentType = contentType,
                DateSubmitted = dateSubmitted,
                StudentId = studentId,
                CourseId = courseId
            };

            data.Homeworks.Add(homework);
            return data.SaveChanges();
        }

        private static int AddCourseWithResource(StudentSystemData data, string courseName, string courseDescription,
            DateTime courseStartDate, DateTime courseEndDate, decimal coursePrice, string ResourceName,
            string resourceLink, TypeOfResource typeOfResource, int courseIdForResource)
        {
            Course course = new Course
            {
                Name = courseName,
                Description = courseDescription,
                StartDate = courseStartDate,
                EndDate = courseEndDate,
                Price = coursePrice
            };

            Resource resourse = new Resource
            {
                Name = ResourceName,
                Link = resourceLink,
                TypeOfResource = typeOfResource,
                CourseId = courseIdForResource
            };

            data.Resources.Add(resourse);
            course.Resources.Add(resourse);
            data.Courses.Add(course);
            return data.SaveChanges();
        }

        private static void ListCoursesWithResources(StudentSystemData data)
        {
            StringBuilder sb = new StringBuilder();
            var courses = data.Courses.All().ToList();
            foreach (Course course in courses.ToList())
            {
                sb.AppendFormat("Course {0}", course.Name);
                sb.Append("\n\tResources:");
                foreach (var resource in course.Resources)
                {
                    sb.AppendFormat("\n\t\tResource: {0}", resource.Name);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }

        private static void ListStudentsWithHomeworks(StudentSystemData data)
        {
            StringBuilder sb = new StringBuilder();
            var students = data.Students.All().ToList();
            foreach (Student student in students.ToList())
            {
                sb.AppendFormat("Student {0}", student.Name);
                sb.Append("\n\tHomeworks:");
                foreach (var hw in student.Homeworks)
                {
                    sb.AppendFormat("\n\t\tHomework Sent on:{0}, Course: {1}", hw.DateSubmitted.ToString(), hw.Course.Name);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
