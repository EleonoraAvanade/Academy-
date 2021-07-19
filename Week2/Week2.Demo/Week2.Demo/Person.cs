using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class Person
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == "") //VALIDAZIONE
                {
                    _firstName = "Jhon";
                }
                else
                {
                    _firstName = value;
                }

            }
        }

        public string Name { get; set; } = "Jhon";

        public string FullName
        {
            get
            {
                return Name + " " + FirstName;
            }
        }

        public DateTime DateBirth { get; }

        public int Age
        {
            get
            {
                return CalculateAge();
            }
        }

        public Document Document { get; set; }

        private int CalculateAge()
        {
            return DateTime.Today.Year - DateBirth.Year;
        }

        #region OBJECT METHODS

        public override string ToString()
        {
            return $"{FullName} - {Age}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return this.FullName.Equals(p.FullName);
            }
        }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepClone()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Document = new Document(this.Document.IdNumber);
            return other;
        }

        #endregion

        #region METHODS

        public string Description(string prefix = "Mr.")
        {
            return $"{prefix} {FullName}";
        }

        public void PrintFamily(string title, params Person[] family)
        {
            Console.WriteLine($"== {title} ==");
            foreach (Person p in family)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine(FamilySecret());
        }

        private string FamilySecret()
        {
            return "Questo è un segreto di famiglia";
        }

        public PersonResponse CheckAgePerson(PersonRequest pr)
        {
            if (pr.Age < 0)
            {
                return new PersonResponse
                {
                    Success = false,
                    Errore = "Età minore di zero",
                    ReturnedValue = null
                };
            }
            return new PersonResponse
            {
                Success = true,
                Errore = "",
                ReturnedValue = new Person
                {
                    Name = pr.Name,
                    FirstName = pr.Surname
                }
            };
        }

        //TUPLA
        public (bool Success, string Errore, Person ReturnedValue)
            CheckAgePersonTupla(PersonRequest request)
        {
            if (request.Age < 0)
            {
                return (false, "Età minore di zero", null);
            }
            return (
                true, 
                "",
                new Person
                {
                    Name = request.Name,
                    FirstName = request.Surname
                });
        }

        public bool CheckAgePersonOut(PersonRequest pr, out string errore, out Person value)
        {
            if(pr.Age < 0)
            {
                errore = "Età minore di zero";
                value = null;
                return false;
            }
            else
            {
                errore = "";
                value = new Person
                {
                    Name = pr.Name,
                    FirstName = pr.Surname
                };
                return true;
            }
        }

        #endregion

    }
}
