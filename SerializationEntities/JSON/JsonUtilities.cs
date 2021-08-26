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
                EnumValue = MyObjectEnum.Two
            };

        public static string GenerateSerializedSimple()
            => GenerateSerializedSimple(otherId: 123);

        public static string GenerateSerializedSimple(int otherId)
        {
            var poco = GenerateSimple(otherId);
            return JsonConvert.SerializeObject(poco);
        }
    }
}
