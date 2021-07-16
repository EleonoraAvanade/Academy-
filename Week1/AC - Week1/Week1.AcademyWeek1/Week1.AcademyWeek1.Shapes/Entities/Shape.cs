using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.AcademyWeek1.Shapes.Interfaces;

namespace Week1.AcademyWeek1.Shapes.Entities
{
    
    public class Shape : IFileSerializable
    {
        public string Name { get; set; }
        public string Path { get; set; } = @"..\\";

        public double ShapeArea { get { return Area(); } }

        public virtual double Area()
        {
            return 0;
        }

        public virtual void Draw()
        {
            Console.WriteLine("This is a generic Shape.");
        }

        public virtual void LoadFromFile(string fileName)
        {
            Console.WriteLine($"Loading Shape Data from {fileName} ... Not implemented for Base class");
        }

        public virtual async Task LoadFromFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveToFile(string fileName)
        {
            Console.WriteLine($"Saving Shape Data to {fileName} ... Not implemented for Base class");
        }

        public virtual async Task SaveToFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
