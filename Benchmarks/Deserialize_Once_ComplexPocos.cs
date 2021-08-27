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
using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Deserialize_Once_ComplexPocos
    {
        private readonly EntityInstances _instances = new();

        [Benchmark]
        public ComplexPocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<ComplexPocoJSON>(_instances.SerializedComplexJson);

        [Benchmark]
        public ComplexPocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<ComplexPocoJSON>(_instances.SerializedComplexJson);

        [Benchmark]
        public ComplexPocoProtobuf Protobuf()
            => ComplexPocoProtobuf.Parser.ParseFrom(_instances.SerializedComplexProtobuf);

        [Benchmark]
        public ComplexPocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<ComplexPocoMsgPack>(_instances.SerializedComplexMsgPack);


        [Benchmark]
        public ComplexPocoBebopMessage BebopMessage()
            => ComplexPocoBebopMessage.Decode(_instances.SerializedComplexBebopMessage);

        [Benchmark]
        public ComplexPocoBebopStruct BebopStruct()
            => ComplexPocoBebopStruct.Decode(_instances.SerializedComplexBebopStruct);
    }
}
