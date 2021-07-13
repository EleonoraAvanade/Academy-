using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Shapes.Entities
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return (Base * Height) / 2.0;
        }

        public override void Draw()
        {
            Console.WriteLine($"This is the {Name} Triangle. Base = {Base}, Height = {Height}");
            Console.WriteLine($"My Area is {Area()}");
        }
    }
}
