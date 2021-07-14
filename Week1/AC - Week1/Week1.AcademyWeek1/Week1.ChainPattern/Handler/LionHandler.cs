using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.ChainPattern.Handler
{
    public class LionHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request.Equals("Bistecca"))
            {
                return $"Sono un leone, amo la {request}";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
