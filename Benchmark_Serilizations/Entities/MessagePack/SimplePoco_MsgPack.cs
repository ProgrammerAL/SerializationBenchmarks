using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace Benchmark_Serilizations.Entities
{
    public enum MyMsgPackObjectEnum
    {
        Unknown,
        One,
        Two,
        Three
    }

    [MessagePackObject]
    public class SimplePoco_MsgPack
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public MyMsgPackObjectEnum EnumValue { get; set; }
    }
}
