using System;
using Week1.FactoryPattern.Vehicles;

namespace Week1.FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new VehicleFactory();
            Console.WriteLine("Il tuo veicolo quante ruote ha?");
            int wheels = Convert.ToInt32(Console.ReadLine());

            IVehicle selectedVehicle = factory.GetVehicle(wheels);
            if(selectedVehicle != null)
            {
                selectedVehicle.TravelTo("Madrid");
            }
        }
    }
}
