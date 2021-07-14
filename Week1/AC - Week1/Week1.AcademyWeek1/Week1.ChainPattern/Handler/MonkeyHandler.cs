using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.ChainPattern.Handler
{
    public class MonkeyHandler : AbstractHandler
    {

        public override string Handle(string request)
        {
            if (request.Equals("Banana"))
            {
                return $"Gnam {request}";
            }
            else
            {
                return base.Handle(request);
            }           
        }

    }
}
