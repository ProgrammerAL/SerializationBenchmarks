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
using ProgrammerAl.Serialization.Entities;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Serialize_Once_ComplexPocos
    {
        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
            => JsonConvert.SerializeObject(_instances.ComplexJson);

        [Benchmark]
        public string SystemTextJson()
            => System.Text.Json.JsonSerializer.Serialize(_instances.ComplexJson);

        [Benchmark]
        public byte[] Protobuf()
            => _instances.ComplexProtobuf.ToByteArray();

        [Benchmark]
        public byte[] MessagePack()
            => MessagePackSerializer.Serialize(_instances.ComplexMsgPack);

        [Benchmark]
        public byte[] BebopMessage()
            => _instances.ComplexBebopMessage.Encode();

        [Benchmark]
        public byte[] BebopStruct()
            => _instances.ComplexBebopStruct.Encode();
    }
}
