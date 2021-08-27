using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.JSON
{
    public class ComplexPocoJSON
    {
        public int Id { get; set; }
        public int OtherId { get; set; }
        public string Name { get; set; }
        public MyJsonEnum EnumValue { get; set; }
        public double Percentage { get; set; }
        public decimal Cost { get; set; }
        public List<ComplexChildPocoJSON> Children { get; set; }
    }

    public class ComplexChildPocoJSON
    { 
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdit { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }
    }
}
