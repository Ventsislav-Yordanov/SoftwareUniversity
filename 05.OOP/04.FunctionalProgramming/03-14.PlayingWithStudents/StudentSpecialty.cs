using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_14.PlayingWithStudents
{
    public class StudentSpecialty
    {
        public string SpecialtyName { get; set; }
        public int FacNum { get; set; }

        public StudentSpecialty(string specialtyName, int facNum)
        {
            this.SpecialtyName = specialtyName;
            this.FacNum = facNum;
        }
    }
}
