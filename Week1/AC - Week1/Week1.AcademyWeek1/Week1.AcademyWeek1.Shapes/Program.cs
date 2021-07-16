using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1.AcademyWeek1.Shapes.Entities;

namespace Week1.AcademyWeek1.Shapes
{
    class Program
    {
        static List<Shape> forme = new List<Shape>
        {
            new Circle { Name = "A", X = 0, Y = 0, Radius = 2 },
            new Circle { Name = "B", X = 2, Y = 5, Radius = 4.5 },
            new Circle { Name = "C", X = 7, Y = 3, Radius = 6 },
            new Rectangle { Name = "A", Base = 10, Width = 10 },
            new Rectangle { Name = "B", Base = 3, Width = 11 },
            new Rectangle { Name = "C", Base = 2, Width = 2 },
            new Triangle { Name = "A", Base = 10, Height = 10 },
            new Triangle { Name = "B", Base = 3, Height = 7 },
            new Triangle { Name = "C", Base = 1, Height = 8 },
            new Triangle { Name = "D", Base = 13, Height = 3 }
        };

        static async Task Main(string[] args)
        {
            #region SAVE-LOAD FILE
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
            #endregion
            #region FILE ASYNC
            await circle.LoadFromFileAsync("circle.txt");
            Circle newCircle = new Circle()
            {
                X = 14,
                Y = 23,
                Radius = 4.7
            };
            await circle.SaveToFileAsync("circle.txt");

            #endregion

            #region LINQ
            var shapeOrdered = forme
                .OrderBy(x => x.Name)
                .ThenByDescending(a => a.Area())
                .Select(s => new ShapeDetail { 
                    Name = s.Name,
                    Area = s.Area()
                });

            var shapeOrderedQE =
                from figure in forme
                orderby figure.Name, figure.Area() descending
                select new ShapeDetail
                {
                    Name = figure.Name,
                    Area = figure.Area()
                };

            var greatShape = forme.Where(f => f.ShapeArea > 20);

            var formeWithA = forme.Where(f => f.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            
            #endregion

        }
    }
}
