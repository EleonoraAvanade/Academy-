using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.FactoryPattern.Vehicles
{
    public interface IVehicle
    {
        public string Name { get; set; }

        void TravelTo(string destination);
    }
}
