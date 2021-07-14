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


        public override async Task LoadFromFileAsync(string fileName)
        {
            Console.WriteLine($"Loading Circle Data from {fileName} ...");

            try
            {
                using StreamReader reader = File.OpenText($"C:\\Temp\\Saves\\{fileName}.sha");

                string date = await reader.ReadLineAsync();

                // @values:My Circle;12;10;4.5
                // [ "@values", "My Circle;12;10;4.5" ] => "My Circle;12;10;4.5" - Riga 38
                // [ "My Circle", "12", "10", "4.5" ] - Riga 39

                string instanceData = (await reader.ReadLineAsync()).Split(':')[1];
                string[] values = instanceData.Split(';');

                // TryParse
                //try
                //{
                //    X = int.Parse(values[1]);
                //}
                //catch(Exception)
                //{
                //    X = 0;
                //}

                Name = values[0];
                int.TryParse(values[1], out int x);
                X = x;
                int.TryParse(values[2], out int y);
                Y = y;
                double.TryParse(values[3], out double r);
                Radius = r;
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"ERRORE (IO): {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRORE: {ex.Message}");
            }
        }

        public override async Task SaveToFileAsync(string fileName)
        {
            Console.WriteLine($"Saving \"{Name}\" Circle Data to {fileName} ...");

            try
            {
                using StreamWriter writer = File.CreateText($"C:\\Temp\\Saves\\{fileName}.sha");

                // @date:2021-02-17 09:19
                // @values:My Circle;12;10;4.5

                string instanceData = $"@values:{Name};{X};{Y};{Radius}";

                await writer.WriteLineAsync("@date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                await writer.WriteLineAsync(instanceData);

                await writer.FlushAsync();
                writer.Close();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"ERRORE (IO): {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRORE: {ex.Message}");
            }
        }

    }
}
