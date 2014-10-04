namespace _02.HumanStudentAndWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;
    public class TestHumanSystem
    {
        static void Main(string[] args)
        {
            Student mitko = new Student("Dimitar", "Obretenov", "102030");
            Student alex = new Student("Alexander", "Dimitrov", "199930");
            Student pesho = new Student("Pesho", "Konstantinov", "123450");
            Student ivan = new Student("Ivan", "Petrov", "142239");
            Student georgi = new Student("Georgi", "Yordanov", "198037");
            Student stani = new Student("Stanislav", "Petrov", "202056");
            Student mariq = new Student("Mariq", "Obretenova", "392310");
            Student sonq = new Student("Sonq", "Alexandrova", "398884");
            Student uli = new Student("Uliq", "Gankova", "452210");
            Student stanka = new Student("Stanka", "Petrova", "332310");

            List<Student> students = new List<Student>()
            {
                mitko,
                alex,
                pesho,
                ivan,
                georgi,
                stani,
                mariq,
                sonq,
                uli,
                stanka
            };

            Worker rosko = new Worker("Rostislav", "Savov", 1000m, 12F);
            Worker venci = new Worker("Ventsislav", "Kadiev", 500m, 8F);
            Worker mario = new Worker("Mario", "Zlatanov", 330m, 5F);
            Worker martin = new Worker("Martin", "Mitev", 400m, 10F);
            Worker bella = new Worker("Bella", "Borisova", 500m, 7F);
            Worker valentin = new Worker("Valentin", "Stefanov", 850m, 10.5F);
            Worker borko = new Worker("Borislav", "Mitev", 999m, 12F);
            Worker radi = new Worker("Radostina", "Petrova", 550m, 5.5F);
            Worker bobi = new Worker("Boqna", "Savova", 450m, 6.5F);
            Worker adi = new Worker("Adelina", "Koleva", 2000m, 12F);

            List<Worker> workers = new List<Worker>() 
            {
                rosko,
                venci,
                mario,
                martin,
                bella,
                valentin,
                borko,
                radi,
                bobi,
                adi
            };

            var sortedStudents =
                from student in students
                orderby student.FacultyNumber ascending
                select student;
            Console.WriteLine("----- Sorted students by faculty number in ascending order -----");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            var sortedWokers =
                from worker in workers
                orderby worker.MoneyPerHour(5) descending
                select worker;
            Console.WriteLine("----- Sorted workers by payment per hours -----");
            foreach (var worker in sortedWokers)
            {
                Console.WriteLine(worker + string.Format(", money per hour: {0:F2}", worker.MoneyPerHour(5)));
            }

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans =
                from human in humans
                orderby human.FirstName, human.LastName
                select human;
            Console.WriteLine("----- Sorted humnas by first name and last name -----");
            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human);
            }
        }
    }
}
