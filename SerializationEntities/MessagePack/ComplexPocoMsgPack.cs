using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace ProgrammerAl.Serialization.Entities.MessagePack
{
    public enum MyMsgPackComplexEnum
    {
        Unknown,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
    }

    [MessagePackObject]
    public class ComplexPocoMsgPack
    {
        [Key(1)]
        public int Id { get; set; }
        [Key(2)]
        public int OtherId { get; set; }
        [Key(3)]
        public string Name { get; set; }
        [Key(4)]
        public MyMsgPackComplexEnum EnumValue { get; set; }
        [Key(5)]
        public double Percentage { get; set; }
        [Key(6)]
        public decimal Cost { get; set; }
        [Key(7)]
        public List<ComplexChildPocoMsgPack> Children { get; set; }
    }

    [MessagePackObject]
    public class ComplexChildPocoMsgPack
    {
        [Key(1)]
        public Guid Id { get; set; }
        [Key(2)]
        public DateTime Created { get; set; }
        [Key(3)]
        public DateTime LastEdit { get; set; }
        [Key(4)]
        public string Name { get; set; }
        [Key(5)]
        public float Percentage { get; set; }
    }
}
