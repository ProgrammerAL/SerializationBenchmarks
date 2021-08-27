using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.Bebop
{
    public static class BebobUtilities
    {
        public static TinyPocoBebopMessage GenerateTinyMessage()
            => GenerateTinyMessage(otherId: 123);

        public static TinyPocoBebopMessage GenerateTinyMessage(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId
            };

        public static byte[] GenerateSerializedTinyMessage()
            => GenerateSerializedTinyMessage(otherId: 123);

        public static byte[] GenerateSerializedTinyMessage(int otherId)
        {
            var poco = GenerateTinyMessage(otherId);
            return TinyPocoBebopMessage.Encode(poco);
        }

        public static TinyPocoBebopStruct GenerateTinyStruct()
            => GenerateTinyStruct(otherId: 123);

        public static TinyPocoBebopStruct GenerateTinyStruct(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId
            };

        public static byte[] GenerateSerializedTinyStruct()
            => GenerateSerializedTinyStruct(otherId: 123);

        public static byte[] GenerateSerializedTinyStruct(int otherId)
        {
            var poco = GenerateTinyStruct(otherId);
            return TinyPocoBebopStruct.Encode(poco);
        }

        public static SimplePocoBebopMessage GenerateSimpleMessage()
            => GenerateSimpleMessage(otherId: 123);

        public static SimplePocoBebopMessage GenerateSimpleMessage(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Two
            };

        public static byte[] GenerateSerializedSimpleMessage()
            => GenerateSerializedSimpleMessage(otherId: 123);
    
        public static byte[] GenerateSerializedSimpleMessage(int otherId)
        {
            var poco = GenerateSimpleMessage(otherId);
            return SimplePocoBebopMessage.Encode(poco);
        }

        public static SimplePocoBebopStruct GenerateSimpleStruct()
            => GenerateSimpleStruct(otherId: 123);

        public static SimplePocoBebopStruct GenerateSimpleStruct(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Two
            };

        public static byte[] GenerateSerializedSimpleStruct()
            => GenerateSerializedSimpleStruct(otherId: 123);

        public static byte[] GenerateSerializedSimpleStruct(int otherId)
        {
            var poco = GenerateSimpleStruct(otherId);
            return SimplePocoBebopStruct.Encode(poco);
        }
        public static ComplexPocoBebopStruct GenerateComplexStruct()
            => GenerateComplexStruct(otherId: 123);

        public static ComplexPocoBebopStruct GenerateComplexStruct(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Three,
                Cost = 456.78f,
                Percentage = 0.5f,
                Children = new ComplexChildPocoBebopStruct[]
                {
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 1",
                        Percentage = 0.1f
                    },
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 2",
                        Percentage = 0.2f
                    },
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 3",
                        Percentage = 0.3f
                    },
                }
            };

        public static byte[] GenerateSerializedComplexStruct()
            => GenerateSerializedComplexStruct(otherId: 123);

        public static byte[] GenerateSerializedComplexStruct(int otherId)
        {
            var poco = GenerateComplexStruct(otherId);
            return ComplexPocoBebopStruct.Encode(poco);
        }

        public static ComplexPocoBebopMessage GenerateComplexMessage()
            => GenerateComplexMessage(otherId: 123);

        public static ComplexPocoBebopMessage GenerateComplexMessage(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Three,
                Cost = 456.78f,
                Percentage = 0.5f,
                Children = new ComplexChildPocoBebopMessage[]
                {
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 1",
                        Percentage = 0.1f
                    },
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 2",
                        Percentage = 0.2f
                    },
                    new()
                    {
                        ID = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 3",
                        Percentage = 0.3f
                    },
                }
            };

        public static byte[] GenerateSerializedComplexMessage()
            => GenerateSerializedComplexMessage(otherId: 123);

        public static byte[] GenerateSerializedComplexMessage(int otherId)
        {
            var poco = GenerateComplexMessage(otherId);
            return ComplexPocoBebopMessage.Encode(poco);
        }
    }
}
