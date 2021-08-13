using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark_Serilizations.Entities
{
    public enum MyObjectEnum
    {
        Unknown,
        One,
        Two,
        Three
    }

    public class SimplePoco_JSON
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MyObjectEnum EnumValue { get; set; }
    }
}
