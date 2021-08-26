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
    public class Deserialize_Once_SimplePocos
    {
        private readonly string _jsonPoco;
        private readonly byte[] _msgPackPoco;
        private readonly byte[] _protobufPoco;
        private readonly byte[] _bebopPoco;

        public Deserialize_Once_SimplePocos()
        {
            _jsonPoco = JsonUtilities.GenerateSerializedSimple();
            _msgPackPoco = MessagePackUtilities.GenerateSerializedSimple();
            _protobufPoco = ProtobufUtilities.GenerateSerializedSimple();
            _bebopPoco = BebobUtilities.GenerateSerializedSimple();
        }

        [Benchmark]
        public SimplePocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<SimplePocoJSON>(_jsonPoco);

        [Benchmark]
        public SimplePocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<SimplePocoJSON>(_jsonPoco);

        [Benchmark]
        public SimplePocoProtobuf Protobuf()
            => SimplePocoProtobuf.Parser.ParseFrom(_protobufPoco);

        [Benchmark]
        public SimplePocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<SimplePocoMsgPack>(_msgPackPoco);


        [Benchmark]
        public SimplePocoBebop Bebop()
            => SimplePocoBebop.Decode(_bebopPoco);
    }
}
