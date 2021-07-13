using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Shapes.Interfaces
{
    public interface IFileSerializable
    {
        public string Path { get; set; } 
        public void SaveToFile(string fileName);
        public void LoadFromFile(string fileName);
    }
}
