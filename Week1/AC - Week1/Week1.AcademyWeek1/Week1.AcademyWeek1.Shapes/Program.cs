using System;
using Week1.AcademyWeek1.Shapes.Entities;

namespace Week1.AcademyWeek1.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle circle = new Circle() { 
                Name = "My circle",
                X = 4,
                Y = 5,
                Radius = 1.0
            };
            //circle.SaveToFile("circle.txt");
            circle.LoadFromFile("circle.txt");
            circle.X = 10;
            circle.SaveToFile("circle.txt");
            

        }
    }
}
