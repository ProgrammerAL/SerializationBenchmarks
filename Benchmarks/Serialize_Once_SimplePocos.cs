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
using ProgrammerAl.Serialization.Entities;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Serialize_Once_SimplePocos
    {
        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
            => JsonConvert.SerializeObject(_instances.SimpleJson);

        [Benchmark]
        public string SystemTextJson()
            => System.Text.Json.JsonSerializer.Serialize(_instances.SimpleJson);

        [Benchmark]
        public byte[] Protobuf()
            => _instances.SimpleProtobuf.ToByteArray();

        [Benchmark]
        public byte[] MessagePack()
            => MessagePackSerializer.Serialize(_instances.SimpleMsgPack);

        [Benchmark]
        public byte[] BebopMessage()
            => _instances.SimpleBebopMessage.Encode();

        [Benchmark]
        public byte[] BebopStruct()
            => _instances.SimpleBebopStruct.Encode();
    }
}
