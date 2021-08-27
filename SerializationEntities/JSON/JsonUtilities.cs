using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ProgrammerAl.Serialization.Entities.JSON
{
    public static class JsonUtilities
    {
        public static TinyPocoJSON GenerateTiny()
            => GenerateTiny(otherId: 123);

        public static TinyPocoJSON GenerateTiny(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId
            };


        public static string GenerateSerializedTiny()
            => GenerateSerializedTiny(123);

        public static string GenerateSerializedTiny(int otherId)
        {
            var poco = GenerateTiny(otherId);
            return JsonConvert.SerializeObject(poco);
        }

        public static SimplePocoJSON GenerateSimple()
            => GenerateSimple(otherId: 123);

        public static SimplePocoJSON GenerateSimple(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyJsonEnum.Two
            };

        public static string GenerateSerializedSimple()
            => GenerateSerializedSimple(otherId: 123);

        public static string GenerateSerializedSimple(int otherId)
        {
            var poco = GenerateSimple(otherId);
            return JsonConvert.SerializeObject(poco);
        }

        public static ComplexPocoJSON GenerateComplex()
            => GenerateComplex(otherId: 123);

        public static ComplexPocoJSON GenerateComplex(int otherId)
            => new()
            {
                Id = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyJsonEnum.Three,
                Cost = 456.78M,
                Percentage = 0.5,
                Children = new List<ComplexChildPocoJSON>
                {
                    new()
                    { 
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 1",
                        Percentage = 0.1f
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 2",
                        Percentage = 0.2f
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow.AddDays(-1),
                        LastEdit = DateTime.UtcNow,
                        Name = "Child 3",
                        Percentage = 0.3f
                    },
                }
            };

        public static string GenerateSerializedComplex()
            => GenerateSerializedComplex(otherId: 123);

        public static string GenerateSerializedComplex(int otherId)
        {
            var poco = GenerateSimple(otherId);
            return JsonConvert.SerializeObject(poco);
        }
    }
}
