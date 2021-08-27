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
    public class Serialize_Once_TinyPocos
    {
        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
            => JsonConvert.SerializeObject(_instances.TinyJson);

        [Benchmark]
        public string SystemTextJson()
            => System.Text.Json.JsonSerializer.Serialize(_instances.TinyJson);

        [Benchmark]
        public byte[] Protobuf()
            => _instances.TinyProtobuf.ToByteArray();

        [Benchmark]
        public byte[] MessagePack()
            => MessagePackSerializer.Serialize(_instances.TinyMsgPack);

        [Benchmark]
        public byte[] BebopMessage()
            => _instances.TinyBebopMessage.Encode();

        [Benchmark]
        public byte[] BebopStruct()
            => _instances.TinyBebopStruct.Encode();
    }
}
