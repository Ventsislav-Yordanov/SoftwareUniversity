namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StudentsAndCoursesProgram
    {
        public static void Main()
        {
            var personsByCourses = new SortedDictionary<string, SortedSet<Person>>();

            string line;
            using (StreamReader reader = new StreamReader("../../students.txt"))
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    var lineParts = line.Split('|');
                    string firstName = lineParts[0].Trim();
                    string lastName = lineParts[1].Trim();
                    string courseName = lineParts[2].Trim();
                    var person = new Person(firstName, lastName);
                    bool courseExists = personsByCourses.ContainsKey(courseName);
                    if (!courseExists)
                    {
                        personsByCourses[courseName] = new SortedSet<Person>();
                    }

                    personsByCourses[courseName].Add(person);
                    line = reader.ReadLine();
                }
            }

            foreach (var pair in personsByCourses)
            {
                Console.Write("{0}: ", pair.Key);
                var personsByKey = string.Join(", ", pair.Value);
                Console.WriteLine(personsByKey);
            }
        }
    }
}
