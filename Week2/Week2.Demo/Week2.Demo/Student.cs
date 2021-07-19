using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class Student
    {
        public static int SeedMatricola = 2000;

        //PROPRIETA' READONLY
        //public readonly int Matricola;
        public int Matricola { get; }

        public Student()
        {
            Matricola = SeedMatricola++;

        }

    }
}
