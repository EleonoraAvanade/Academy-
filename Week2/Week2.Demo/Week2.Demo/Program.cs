using System;
using System.Collections.Generic;

namespace Week2.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student s = new Student();
            //s.Matricola = 2300;

            Person p = new Person();
            p.FirstName = "Pippo";

            Console.WriteLine(p);

            //Person p2 = p;
            Person p2 = new Person();
            p2.FirstName = "Pippo";
            Console.WriteLine(p2);
            Console.WriteLine(p2.Equals(p));

            p.Document = new Document(123);
            Person p3 = p.ShallowCopy();
            Console.WriteLine(p + " " + p.Document);
            Console.WriteLine(p3 + " " + p3.Document);

            p.Document.IdNumber = 456;
            p.FirstName = "Mario";
            Console.WriteLine(p + " " + p.Document);
            Console.WriteLine(p3 + " " + p3.Document);

            p3 = p.DeepClone();
            p.Document.IdNumber = 789;
            Console.WriteLine(p + " " + p.Document);
            Console.WriteLine(p3 + " " + p3.Document);

            Console.Clear();

            Console.WriteLine(p.Description());
            Console.WriteLine(p.Description("Miss"));

            p.PrintFamily("Famiglia poco numerosa", p2, p3);
            Console.WriteLine("Persona: {0} - {1}", p.Name, p.Age);

            (bool success, string error, Person value) r =
                p.CheckAgePersonTupla(new PersonRequest
                {
                    Age = 7,
                    Name = "Luca",
                    Surname = "Bianchi"
                });

            var chkResponseTupla = p.CheckAgePersonTupla(new PersonRequest
            {
                Age = -3,
                Name = "Mario",
                Surname = "Rossi"
            });
            if (!chkResponseTupla.Success)
            {
                Console.WriteLine(chkResponseTupla.Errore);
            }
            if (!r.success)
            {
                Console.WriteLine(r.error);
            }
            PersonRequest pr = new PersonRequest { Name = "Marco", Surname = "Gialli", Age = -5 };
            //bool result = p.CheckAgePersonOut(pr, out string errore, out Person value);
            string errore;
            Person value;
            bool result = p.CheckAgePersonOut(pr, out errore, out value);
            if (result)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine(errore);
            }
            bool success = int.TryParse("1", out int numConvertito);

            MySortedList<int> msi = new MySortedList<int>();
            MySortedList<Person> msp = new MySortedList<Person>();
            var people = new List<Person>();
            MySortedList<Person>.Max<Person>(people);
            //MySortedList<PersonRequest> mspr = new MySortedList<PersonRequest>();
            msi.Add(1);
            msp.Add(p);
            Console.Read();
        }
    }
}
