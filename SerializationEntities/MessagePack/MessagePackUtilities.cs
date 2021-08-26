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
            => GenerateSimple(otherId: 123);

        public static SimplePocoMsgPack GenerateSimple(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyMsgPackObjectEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
            => GenerateSerializedSimple(otherId: 123);

        public static byte[] GenerateSerializedSimple(int otherId)
        {
            var poco = GenerateSimple(otherId);
            return MessagePackSerializer.Serialize(poco);
        }
    }
}
