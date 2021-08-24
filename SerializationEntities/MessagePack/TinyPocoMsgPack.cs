using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace ProgrammerAl.Serialization.Entities.MessagePack
{
    [MessagePackObject]
    public class TinyPocoMsgPack
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int OtherId { get; set; }
    }
}
