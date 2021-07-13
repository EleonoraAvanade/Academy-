using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Shapes.Entities
{
    public class Rectangle : Shape
    {
        public double Base { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Base * Width;
        }

        public override void Draw()
        {
            Console.WriteLine($"This is the {Name} Rectangle. Base = {Base}, Width = {Width}");
            Console.WriteLine($"My Area is {Area()}");
        }

        public override void LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = File.OpenText(Path + fileName))
                {
                    string line = reader.ReadLine();
                    Name = line;

                    line = reader.ReadLine();
                    double.TryParse(line, out double b);
                    Base = b;

                    line = reader.ReadLine();
                    double.TryParse(line, out double w);
                    Width = w;
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Formato file
        //Rettangolo1
        //10
        //5
        public override void SaveToFile(string fileName)
        {
            try
            {
                using(StreamWriter writer = File.CreateText(Path + fileName))
                {
                    writer.WriteLine(Name);
                    writer.WriteLine(Base);
                    writer.WriteLine(Width);
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
