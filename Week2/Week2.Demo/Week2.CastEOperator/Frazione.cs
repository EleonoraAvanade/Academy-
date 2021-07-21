using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CastEOperator
{
    public class Frazione : IComparable, IComparable<Frazione>
    {
        public int Numeratore { get; set; }
        public int Denominatore { get; set; }

        public Frazione(int num, int den)
        {
            Numeratore = num;
            Denominatore = den;
        }

        public Frazione Addizione(Frazione a)
        {
            return new Frazione(a.Numeratore * Denominatore + Numeratore * a.Denominatore,
                a.Denominatore * Denominatore);
        }

        public static Frazione operator +(Frazione a, Frazione b)
        {
            return a.Addizione(b);
        }

        public static Frazione operator +(Frazione a, int b)
        {
            var frazioneDaNum = new Frazione(b, 1);
            return a.Addizione(frazioneDaNum);
        }

        public static bool operator ==(Frazione a, Frazione b)
        {
            //Verifico che a e b non siano null
            if (object.ReferenceEquals(a, null)) //a punta a null?
            {
                if(object.ReferenceEquals(b, null))
                {
                    return true;
                }               
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Frazione a, Frazione b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if(object.ReferenceEquals(obj, null))
            {
                return false;
            }
            else
            {
                Frazione f = (Frazione)obj;
                //return (Numeratore == f.Numeratore && Denominatore == f.Denominatore);
                if(Numeratore == f.Numeratore && Denominatore == f.Denominatore)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool operator < (Frazione a, Frazione b)
        {
            return a.CompareTo(b) == -1;
        }

        public static bool operator > (Frazione a, Frazione b)
        {
            return a.CompareTo(b) == 1;
        }

        public static bool operator >=(Frazione a, Frazione b)
        {
            return a.CompareTo(b) == 1 || a.CompareTo(b) == 0;
        }

        public static bool operator <= (Frazione a, Frazione b)
        {
            return a.CompareTo(b) == -1 || a.CompareTo(b) == 0;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as Frazione);
        }

        public int CompareTo(Frazione other)
        {
            if(other == null)
            {
                return -2;
            }

            double otherValue = other.Numeratore / (double)other.Denominatore;
            double myValue = Numeratore / (double)Denominatore;
            if(myValue > otherValue)
            {
                return 1;
            }else if(myValue < otherValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }
}
