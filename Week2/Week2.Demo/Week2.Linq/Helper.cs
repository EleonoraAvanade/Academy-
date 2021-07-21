using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Linq
{
    public static class Helper
    {
        public static IEnumerable<Valutazione> GetValutazioniStudentiA(this IEnumerable<Valutazione> list)
        {
            return list.Where(v => v.NomeStudente.StartsWith('A'));
        }

        public static bool AnyValutazione(this IEnumerable<Valutazione> lista, int num)
        {
            return num == 0;
        }

    }
}
