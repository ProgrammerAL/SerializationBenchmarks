using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerAl.Serialization.Entities.Bebop
{
    public static class BebobUtilities
    {
        public static TinyPocoBebop GenerateTiny()
            => GenerateTiny(otherId: 123);

        public static TinyPocoBebop GenerateTiny(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId
            };

        public static byte[] GenerateSerializedTiny()
            => GenerateSerializedTiny(otherId: 123);

        public static byte[] GenerateSerializedTiny(int otherId)
        {
            var poco = GenerateTiny(otherId);
            return TinyPocoBebop.Encode(poco);
        }

        public static SimplePocoBebop GenerateSimple()
            => GenerateSimple(otherId: 123);

        public static SimplePocoBebop GenerateSimple(int otherId)
            => new()
            {
                ID = 123_456,
                OtherId = otherId,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
            => GenerateSerializedSimple(otherId: 123);
    
        public static byte[] GenerateSerializedSimple(int otherId)
        {
            var poco = GenerateSimple(otherId);
            return SimplePocoBebop.Encode(poco);
        }
    }
}
