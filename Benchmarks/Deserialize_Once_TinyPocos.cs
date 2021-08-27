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
    public class Deserialize_Once_TinyPocos
    {
        private readonly EntityInstances _instances = new();
        
        [Benchmark]
        public TinyPocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<TinyPocoJSON>(_instances.SerializedTinyJson);

        [Benchmark]
        public TinyPocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<TinyPocoJSON>(_instances.SerializedTinyJson);

        [Benchmark]
        public TinyPocoProtobuf Protobuf()
            => TinyPocoProtobuf.Parser.ParseFrom(_instances.SerializedTinyProtobuf);

        [Benchmark]
        public TinyPocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<TinyPocoMsgPack>(_instances.SerializedTinyMsgPack);

        [Benchmark]
        public TinyPocoBebopMessage BebopMessage()
            => TinyPocoBebopMessage.Decode(_instances.SerializedTinyBebopMessage);

        [Benchmark]
        public TinyPocoBebopStruct BebopStruct()
            => TinyPocoBebopStruct.Decode(_instances.SerializedTinyBebopStruct);
    }
}
