﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.FactoryPattern.Vehicles
{
    public class Truck : IVehicle
    {
        public string Name { get; set; }

        public void TravelTo(string destination)
        {
            Console.WriteLine($"Travel on truck from origin to {destination}");
        }
    }
}
