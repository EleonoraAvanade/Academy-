using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.ChainPattern.Handler
{
    public class ZebraHandler : AbstractHandler
    {

        public override string Handle(string request)
        {
            if (request.Equals("Insalata"))
            {
                return $"Ottima {request}";
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
