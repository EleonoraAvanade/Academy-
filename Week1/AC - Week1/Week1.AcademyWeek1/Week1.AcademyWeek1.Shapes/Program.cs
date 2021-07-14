using System;
using System.Threading.Tasks;
using Week1.AcademyWeek1.Shapes.Entities;

namespace Week1.AcademyWeek1.Shapes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle circle = new Circle()
            {
                Name = "My circle",
                X = 4,
                Y = 5,
                Radius = 1.0
            };
            //circle.SaveToFile("circle.txt");
            circle.LoadFromFile("circle.txt");
            circle.X = 10;
            circle.SaveToFile("circle.txt");

            #region
            await circle.LoadFromFileAsync("circle.txt");
            Circle newCircle = new Circle()
            {
                X = 14,
                Y = 23,
                Radius = 4.7
            };
            await circle.SaveToFileAsync("circle.txt");

            #endregion


        }
    }
}
