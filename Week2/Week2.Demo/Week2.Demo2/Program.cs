using System;
using System.IO;

namespace Week2.Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass(); //COSTRUTTORE NO-ARG

            BaseClass bc2 = new BaseClass
            {
                Value = 1,
                //Stringa = "ciao"
            };

            BaseClass bc3 = new BaseClass();

            ConcreteClass cc = new ConcreteClass();

            using (FileStream writer = File.Create(@"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1")) ;

            DisposableClass dc = new DisposableClass(); //RISORSA COSTOSA
            //operazioni su risorsa dc

            dc.Dispose();

            

        }
    }
}
