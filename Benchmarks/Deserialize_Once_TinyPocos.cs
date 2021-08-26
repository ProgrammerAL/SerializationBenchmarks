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
    public class Deserialize_Once_TinyPocos
    {
        private readonly string _jsonPoco;
        private readonly byte[] _msgPackPoco;
        private readonly byte[] _protobufPoco;
        private readonly byte[] _bebopPoco;

        public Deserialize_Once_TinyPocos()
        {
            _jsonPoco = JsonUtilities.GenerateSerializedTiny();
            _msgPackPoco = MessagePackUtilities.GenerateSerializedTiny();
            _protobufPoco = ProtobufUtilities.GenerateSerializedTiny();
            _bebopPoco = BebobUtilities.GenerateSerializedTiny();
        }

        [Benchmark]
        public TinyPocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<TinyPocoJSON>(_jsonPoco);

        [Benchmark]
        public TinyPocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<TinyPocoJSON>(_jsonPoco);

        [Benchmark]
        public TinyPocoProtobuf Protobuf()
            => TinyPocoProtobuf.Parser.ParseFrom(_protobufPoco);

        [Benchmark]
        public TinyPocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<TinyPocoMsgPack>(_msgPackPoco);


        [Benchmark]
        public TinyPocoBebop Bebop()
            => TinyPocoBebop.Decode(_bebopPoco);
    }
}
