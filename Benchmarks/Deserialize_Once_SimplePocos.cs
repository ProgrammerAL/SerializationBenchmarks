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
    public class Deserialize_Once_SimplePocos
    {
        private readonly EntityInstances _instances = new();

        [Benchmark]
        public SimplePocoJSON? NewtonsoftJson()
            => JsonConvert.DeserializeObject<SimplePocoJSON>(_instances.SerializedSimpleJson);

        [Benchmark]
        public SimplePocoJSON? SystemTextJson()
            => System.Text.Json.JsonSerializer.Deserialize<SimplePocoJSON>(_instances.SerializedSimpleJson);

        [Benchmark]
        public SimplePocoProtobuf Protobuf()
            => SimplePocoProtobuf.Parser.ParseFrom(_instances.SerializedSimpleProtobuf);

        [Benchmark]
        public SimplePocoMsgPack MessagePack()
            => MessagePackSerializer.Deserialize<SimplePocoMsgPack>(_instances.SerializedSimpleMsgPack);


        [Benchmark]
        public SimplePocoBebopMessage BebopMessage()
            => SimplePocoBebopMessage.Decode(_instances.SerializedSimpleBebopMessage);

        [Benchmark]
        public SimplePocoBebopStruct BebopStruct()
            => SimplePocoBebopStruct.Decode(_instances.SerializedSimpleBebopStruct);
    }
}
