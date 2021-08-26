using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace ProgrammerAl.Serialization.Entities.MessagePack
{
    public enum MyMsgPackObjectEnum
    {
        Unknown,
        One,
        Two,
        Three
    }

    [MessagePackObject]
    public class SimplePocoMsgPack
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int OtherId { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public MyMsgPackObjectEnum EnumValue { get; set; }
    }
}
