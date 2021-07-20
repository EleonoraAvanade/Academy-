using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CastEOperator
{
    public class Quadrato : Rettangolo
    {
        public Quadrato(double lato) : base(lato, lato)
        {
            
        }

        //TIPO DI PARTENZA: ROMBO -> TIPO DI ARRIVO: QUADRATO
        //
        public static explicit operator Quadrato(Rombo r)
        {
            if(r.DiagonaleMaggiore == r.DiagonaleMinore)
            {
                return new Quadrato(r.Lato);
            }
            return null;
        }

        //public static implicit operator Quadrato(Rombo r)
        //{
        //    if(r.DiagonaleMaggiore == r.DiagonaleMinore)
        //    {
        //        return new Quadrato(r.Lato);
        //    }
        //    return null;
        //}

    }
}
