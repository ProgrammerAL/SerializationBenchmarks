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
            => new()
            {
                ID = 123_456,
                OtherId = 123
            };

        public static byte[] GenerateSerializedTiny()
        {
            var poco = GenerateTiny();
            return TinyPocoBebop.Encode(poco);
        }

        public static SimplePocoBebop GenerateSimple()
            => new()
            {
                ID = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Two
            };

        public static byte[] GenerateSerializedSimple()
        {
            var poco = GenerateSimple();
            return SimplePocoBebop.Encode(poco);
        }
    }
}
