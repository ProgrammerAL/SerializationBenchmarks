using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.JSON
{
    public class SimplePocoJSON
    {
        public int Id { get; set; }
        public int OtherId { get; set; }
        public string Name { get; set; }
        public MyJsonEnum EnumValue { get; set; }
    }
}
