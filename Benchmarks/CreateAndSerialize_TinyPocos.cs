using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using Google.Protobuf;

using MessagePack;

using Newtonsoft.Json;

using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class CreateAndSerialize_TinyPocos
    {
        [Benchmark]
        public string NewtonsoftJson()
        {
            var poco = JsonUtilities.GenerateTiny();
            return JsonConvert.SerializeObject(poco);
        }

        [Benchmark]
        public string SystemTextJson()
        {
            var poco = JsonUtilities.GenerateTiny();
            return System.Text.Json.JsonSerializer.Serialize(poco);
        }

        [Benchmark]
        public byte[] Protobuf()
        {
            var poco = ProtobufUtilities.GenerateTiny();
            return poco.ToByteArray();
        }

        [Benchmark]
        public byte[] MessagePack()
        {
            var poco = MessagePackUtilities.GenerateTiny();
            return MessagePackSerializer.Serialize(poco);
        }

        [Benchmark]
        public byte[] Bebop()
        {
            var poco = BebobUtilities.GenerateTinyMessage();
            return poco.Encode();
        }
    }
}
