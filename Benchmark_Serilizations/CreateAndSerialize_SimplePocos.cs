using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
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
    public class CreateAndSerialize_SimplePocos
    {
        [Benchmark]
        public string Serialize_Json_Newtonsoft()
        {
            var poco = JsonUtilities.GenerateSimple();
            return JsonConvert.SerializeObject(poco);
        }

        [Benchmark]
        public string Serialize_Json_SystemText()
        {
            var poco = JsonUtilities.GenerateSimple();
            return System.Text.Json.JsonSerializer.Serialize(poco);
        }

        [Benchmark]
        public byte[] Serialize_Protobuf()
        {
            var poco = ProtobufUtilities.GenerateSimple();
            return poco.ToByteArray();
        }

        [Benchmark]
        public byte[] Serialize_MessagePack()
        {
            var poco = MessagePackUtilities.GenerateSimple();
            return MessagePackSerializer.Serialize(poco);
        }

        [Benchmark]
        public byte[] Serialize_Bebop()
        {
            var poco = BebobUtilities.GenerateSimple();
            return SimplePocoBebop.Encode(poco);
        }
    }
}
