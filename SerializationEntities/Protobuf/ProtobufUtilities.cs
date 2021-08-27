using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

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
            => GenerateSimple(otherId: 123);

        public static SimplePocoProtobuf GenerateSimple(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyProtoEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
            => GenerateSerializedSimple(otherId: 123);

        public static byte[] GenerateSerializedSimple(int otherId)
        {
            var poco = GenerateSimple();
            return poco.ToByteArray();
        }

        public static ComplexPocoProtobuf GenerateComplex()
            => GenerateComplex(otherId: 123);

        public static ComplexPocoProtobuf GenerateComplex(int otherId)
        {
            var obj = new ComplexPocoProtobuf()
            {
                Id = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyProtoEnum.Three,
                Cost = 456.78,
                Percentage = 0.5,
            };

            obj.Children.Add(new ComplexChildPocoProtobuf
            {
                GuidId = Guid.NewGuid().ToString(),
                Created = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                LastEdit = Timestamp.FromDateTime(DateTime.UtcNow),
                Name = "Child 1",
                Percentage = 0.1f
            });
            obj.Children.Add(new ComplexChildPocoProtobuf
            {
                GuidId = Guid.NewGuid().ToString(),
                Created = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                LastEdit = Timestamp.FromDateTime(DateTime.UtcNow),
                Name = "Child 2",
                Percentage = 0.2f
            });
            obj.Children.Add(new ComplexChildPocoProtobuf
            {
                GuidId = Guid.NewGuid().ToString(),
                Created = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                LastEdit = Timestamp.FromDateTime(DateTime.UtcNow),
                Name = "Child 3",
                Percentage = 0.3f
            });

            return obj;
        }

        public static byte[] GenerateSerializedComplex()
            => GenerateSerializedComplex(otherId: 123);

        public static byte[] GenerateSerializedComplex(int otherId)
        {
            var poco = GenerateComplex();
            return poco.ToByteArray();
        }
    }
}
