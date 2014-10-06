using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class TestSchoolSystem
    {
        static void Main(string[] args)
        {
            Student mitko = new Student("Dimitar", "201401#17", "Dimitar likes physics.");
            Student alex = new Student("Alex", "201401#01");
            //Student radi = new Student("Radostina", "201401#01"); // this row throw exception because the ID is busy
            Student gosho = new Student("Georgi", "201402#20", "Georgi hates math.");
            Student dancho = new Student("Yordan", "201402#27", "Dancho hates english.");

            Discipline physics = new Discipline("Physics", new List<Student>() { mitko, alex, dancho }, 20,
                "Physics is one of the oldest academic disciplines");
            Discipline maths = new Discipline("Math", new List<Student>() { alex, gosho, dancho }, 17);
            Discipline english = new Discipline("English language", new List<Student>() { dancho, mitko, gosho }, 35);
            Discipline bulgarian = new Discipline("Bulgarian language", new List<Student>() { dancho, alex, gosho }, 55);


            Teacher rumi = new Teacher("Rumelina", new List<Discipline>() { bulgarian }, "The worst teacher in the world!");
            Teacher svetlio = new Teacher("Svetlozar", new List<Discipline>() { physics, maths }, "The best teacher in the school!");
            Teacher alexandrina = new Teacher("Alexandrina", new List<Discipline>() { english });

            SchoolClass class201401 = new SchoolClass("201401", new List<Student>() { alex, mitko }, new List<Teacher>() { rumi, svetlio },
                "class201401 is awesome!");
            //SchoolClass class201401dublicate = new SchoolClass("201401", new List<Student>() { alex, mitko }, new List<Teacher>() { rumi, svetlio },
            //    "class201401 is awesome!"); // this 2 rows throw exception because the uniqueID is busy
            SchoolClass class201402 = new SchoolClass("201402", new List<Student>() { gosho, dancho },
                new List<Teacher>() { rumi, svetlio, alexandrina });

            School mg = new School(new List<SchoolClass>() { class201401, class201402 });
        }
    }
}
