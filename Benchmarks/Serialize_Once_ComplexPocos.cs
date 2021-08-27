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
    public class Serialize_Once_ComplexPocos
    {
        private readonly ComplexPocoJSON _jsonPoco;
        private readonly ComplexPocoMsgPack _msgPackPoco;
        private readonly ComplexPocoProtobuf _protobufPoco;
        private readonly ComplexPocoBebopMessage _bebopPoco;

        public Serialize_Once_ComplexPocos()
        {
            _jsonPoco = JsonUtilities.GenerateComplex();
            _msgPackPoco = MessagePackUtilities.GenerateComplex();
            _protobufPoco = ProtobufUtilities.GenerateComplex();
            _bebopPoco = BebobUtilities.GenerateComplexMessage();
        }

        [Benchmark]
        public string NewtonsoftJson()
            => JsonConvert.SerializeObject(_jsonPoco);

        [Benchmark]
        public string SystemTextJson()
            => System.Text.Json.JsonSerializer.Serialize(_jsonPoco);

        [Benchmark]
        public byte[] Protobuf()
            => _protobufPoco.ToByteArray();

        [Benchmark]
        public byte[] MessagePack()
            => MessagePackSerializer.Serialize(_msgPackPoco);

        [Benchmark]
        public byte[] Bebop()
            => _bebopPoco.Encode();
    }
}
