using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CastEOperator
{
    public class Rettangolo : IShape
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public Rettangolo(double b, double h)
        {
            Base = b;
            Altezza = h;
        }

        public double Area()
        {
            return Base * Altezza;
        }

        public bool IsQuadrilatero()
        {
            return true;
        }

        public double Perimetro()
        {
            return 2 * (Base + Altezza);
        }


        public static explicit operator Rettangolo(Rombo r)
        {
            if(r.DiagonaleMaggiore == r.DiagonaleMinore)
            {
                return new Rettangolo(r.Lato, r.Lato);
            }
            return null;
        }
    }
}
