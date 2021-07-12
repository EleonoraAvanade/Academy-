using System;

namespace Week1.AcademyWeek1
{
    class Program
    {
        enum Categorie
        {
            PRIMO = 4,
            SECONDO = 1,
            TERZO
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int primo = 3;
            double secondo = 3.45;
            float terzo = 5.6f;

            bool quarto = true;
            bool quinto = false;


            byte sesto = 23;

            DateTime dataOggi = new DateTime(2021, 7, 12);

            Categorie cat = Categorie.SECONDO;

            int primoClonato = primo;
            Console.WriteLine(primo);
            Console.WriteLine(primoClonato);
            primo = 56;
            Console.WriteLine(primo);
            Console.WriteLine(primoClonato);

            Person persona = new Person();
            persona.FirstName = "Mario";
            persona.LastName = "Rossi";
            persona.BirthDay = new DateTime(1980, 5, 4);

            Person personaClonata = persona;
            Console.WriteLine($"Nome: {persona.FirstName} - Cognome: {persona.LastName}" +
                $" Data di nascita: {persona.BirthDay}");
            Console.WriteLine($"Nome: {personaClonata.FirstName} - Cognome: {personaClonata.LastName}" +
                $" Data di nascita: {personaClonata.BirthDay}");

            persona.LastName = "Bianchi";

            Console.WriteLine($"Nome: {persona.FirstName} - Cognome: {persona.LastName}" +
                $" Data di nascita: {persona.BirthDay}");
            Console.WriteLine($"Nome: {personaClonata.FirstName} - Cognome: {personaClonata.LastName}" +
                $" Data di nascita: {personaClonata.BirthDay}");

            int a; // contenuto 0
            Person p; // contenuto null

            //p.FirstName;

            //persona.TaxCode = "";
            //persona.Stipendio = 1200.56; //set della proprietà
            //Console.WriteLine(persona.Stipendio); // get della proprietà
            
            Console.WriteLine(persona.GetInfoPersona());
            Console.WriteLine(persona.GetInfoPersona());

            Person p2 = new Employee();
            p2.FirstName = "Luca";
            p2.LastName = "Rossi";
            Console.WriteLine(p2.ToString());
            Console.WriteLine(persona.ToString());

            Person manager = new Manager();
            manager.FirstName = "Antonia";
            manager.LastName = "Sacchitella";
            manager.BirthDay = new DateTime(1999, 4, 5);
            
            Console.WriteLine(manager);

            Console.ReadKey();

            

        }
    }
}
