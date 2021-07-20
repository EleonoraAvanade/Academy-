using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CastEOperator
{
    public class Rombo : IShape
    {
        public double Lato { get; set; }
        public double DiagonaleMaggiore { get; set; }
        public double DiagonaleMinore { get; set; }

        public Rombo(double l, double dM, double dm)
        {
            Lato = l;
            DiagonaleMaggiore = dM;
            DiagonaleMinore = dm;
        }

        public double Area()
        {
            return DiagonaleMaggiore * DiagonaleMinore * 0.5;
        }

        public bool IsQuadrilatero()
        {
            return true;
        }

        public double Perimetro()
        {
            return 4 * Lato;
        }

        //TIPO DI PARTENZA : QUADRATO -> TIPO DI ARRIVO: ROMBO
        public static implicit operator Rombo(Quadrato q)
        {
            double lato = q.Base;
            double dM = q.Base * Math.Sqrt(2);
            double dm = dM;
            return new Rombo(lato, dM, dm);
        }
    }
}
