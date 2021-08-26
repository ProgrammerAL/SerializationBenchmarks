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
    public class Serialize_Once_TinyPocos
    {
        private readonly TinyPocoJSON _jsonPoco;
        private readonly TinyPocoMsgPack _msgPackPoco;
        private readonly TinyPocoProtobuf _protobufPoco;
        private readonly TinyPocoBebop _bebopPoco;

        public Serialize_Once_TinyPocos()
        {
            _jsonPoco = JsonUtilities.GenerateTiny();
            _msgPackPoco = MessagePackUtilities.GenerateTiny();
            _protobufPoco = ProtobufUtilities.GenerateTiny();
            _bebopPoco = BebobUtilities.GenerateTiny();
        }

        [Benchmark]
        public string Serialize_Json_Newtonsoft()
            => JsonConvert.SerializeObject(_jsonPoco);

        [Benchmark]
        public string Serialize_Json_SystemText()
            => System.Text.Json.JsonSerializer.Serialize(_jsonPoco);

        [Benchmark]
        public byte[] Serialize_Protobuf()
            => _protobufPoco.ToByteArray();

        [Benchmark]
        public byte[] Serialize_MessagePack()
            => MessagePackSerializer.Serialize(_msgPackPoco);

        [Benchmark]
        public byte[] Serialize_Bebop()
            => _bebopPoco.Encode();
    }
}
