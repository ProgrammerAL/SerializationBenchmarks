using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.JSON
{
    public enum MySimpleEnum
    {
        Unknown,
        One,
        Two,
        Three
    }

    public class SimplePocoJSON
    {
        public int Id { get; set; }
        public int OtherId { get; set; }
        public string Name { get; set; }
        public MySimpleEnum EnumValue { get; set; }
    }
}
