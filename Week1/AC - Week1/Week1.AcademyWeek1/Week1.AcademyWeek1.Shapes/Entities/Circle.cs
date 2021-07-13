using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Shapes.Entities
{
    public class Circle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Radius { get; set; }

        public override double Area()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override void Draw()
        {
            Console.WriteLine($"This is the {Name} Circle. X = {X}, Y = {Y}, Radius = {Radius}");
            Console.WriteLine($"My Area is {Area()}");
        }

        public override void LoadFromFile(string fileName)
        {
            try
            {
                using(StreamReader reader = File.OpenText(Path + fileName))
                {
                    string data = reader.ReadLine();
                    string instanceData = reader.ReadLine();
                    string[] values = instanceData.Split(":");

                    string[] dataCircle = values[1].Split(";");

                    Name = dataCircle[0];
                    int.TryParse(dataCircle[1], out int x);
                    X = x;

                    int.TryParse(dataCircle[2], out int y);
                    Y = y;

                    double.TryParse(dataCircle[3], out double radius);
                    Radius = radius;
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Formato del file cerchio
        //data:2021-07-13
        //values:My Circle;10;12;4.6
        public override void SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(Path + fileName))
                {
                    writer.WriteLine("data:" + DateTime.Today.ToShortDateString());
                    writer.WriteLine("values:" + Name + ";" + X + ";" + Y + ";" + Radius);
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
