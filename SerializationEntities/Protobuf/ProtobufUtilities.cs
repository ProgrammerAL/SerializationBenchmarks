using Google.Protobuf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.Protobuf
{
    public static class ProtobufUtilities
    {
        public static TinyPocoProtobuf GenerateTiny()
            => GenerateTiny(otherId: 123);

        public static TinyPocoProtobuf GenerateTiny(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId
            };

        public static byte[] GenerateSerializedTiny()
        {
            var poco = GenerateTiny();
            return poco.ToByteArray();
        }

        public static byte[] GenerateSerializedTiny(int otherId)
        {
            var poco = GenerateTiny(otherId);
            return poco.ToByteArray();
        }

        public static SimplePocoProtobuf GenerateSimple()
            => new()
            {
                Id = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyProtoEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
        {
            var poco = GenerateSimple();
            return poco.ToByteArray();
        }
    }
}
