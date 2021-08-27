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
    public class Deserialize_Once_ComplexPocos
    {
        private readonly string _jsonPoco;
        private readonly byte[] _msgPackPoco;
        private readonly byte[] _protobufPoco;
        private readonly byte[] _bebopPoco;

        public Deserialize_Once_ComplexPocos()
        {
            _jsonPoco = JsonUtilities.GenerateSerializedComplex();
            _msgPackPoco = MessagePackUtilities.GenerateSerializedComplex();
            _protobufPoco = ProtobufUtilities.GenerateSerializedComplex();
            _bebopPoco = BebobUtilities.GenerateSerializedComplex();
        }

        [Benchmark]
        public ComplexPocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<ComplexPocoJSON>(_jsonPoco);

        [Benchmark]
        public ComplexPocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<ComplexPocoJSON>(_jsonPoco);

        [Benchmark]
        public ComplexPocoProtobuf Protobuf()
            => ComplexPocoProtobuf.Parser.ParseFrom(_protobufPoco);

        [Benchmark]
        public ComplexPocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<ComplexPocoMsgPack>(_msgPackPoco);


        [Benchmark]
        public ComplexPocoBebop Bebop()
            => ComplexPocoBebop.Decode(_bebopPoco);
    }
}
