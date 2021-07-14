using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.FactoryPattern.Vehicles;

namespace Week1.FactoryPattern
{
    public class VehicleFactory
    {
        public IVehicle GetVehicle(int numWheels)
        {
            IVehicle vehicle = null;

            switch (numWheels)
            {
                case 1:
                    Console.WriteLine("Per il circo vendono i monocicli, non qui");
                    break;
                case 2:
                    vehicle = new Bike();
                    break;
                case 4:
                    vehicle = new Car();
                    break;
                case 8:
                    vehicle = new Truck();
                    break;
                default:
                    Console.WriteLine($"Veicolo con {numWheels} ruote non disponibile");
                    break;
            }

            return vehicle;
        }
    }
}
