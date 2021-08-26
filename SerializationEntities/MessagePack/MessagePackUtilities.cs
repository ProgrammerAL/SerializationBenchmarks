using MessagePack;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.MessagePack
{
    public static class MessagePackUtilities
    {
        public static TinyPocoMsgPack GenerateTiny()
            => GenerateTiny(otherId: 123);

        public static TinyPocoMsgPack GenerateTiny(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId
            };


        public static byte[] GenerateSerializedTiny()
        {
            var poco = GenerateTiny();
            return MessagePackSerializer.Serialize(poco);
        }

        public static byte[] GenerateSerializedTiny(int otherId)
        {
            var poco = GenerateTiny(otherId);
            return MessagePackSerializer.Serialize(poco);
        }

        public static SimplePocoMsgPack GenerateSimple()
            => new()
            {
                Id = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyMsgPackObjectEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
        {
            var poco = GenerateSimple();
            return MessagePackSerializer.Serialize(poco);
        }
    }
}
