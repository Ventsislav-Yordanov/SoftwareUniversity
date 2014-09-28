using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    class StudentClassTest
    {
        static void Main(string[] args)
        {
            var student = new Student("Pesho", 20);
            student.Name = "Pesho";
            student.Age = 21;

            var studen2 = new Student("Maria", 22);
            studen2.Name = "Adelina";
            studen2.Age = 23;
        }
    }
}
