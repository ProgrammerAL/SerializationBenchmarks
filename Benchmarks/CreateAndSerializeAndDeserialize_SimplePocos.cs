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
    public class CreateAndSerializeAndDeserialize_SimplePocos
    {
        [Benchmark]
        public SimplePocoJSON NewtonsoftJson()
        {
            var poco = JsonUtilities.GenerateSimple();
            var serialized = JsonConvert.SerializeObject(poco);
            return JsonConvert.DeserializeObject<SimplePocoJSON>(serialized)!;
        }

        [Benchmark]
        public SimplePocoJSON SystemTextJson()
        {
            var poco = JsonUtilities.GenerateSimple();
            var serialized = System.Text.Json.JsonSerializer.Serialize(poco);
            return System.Text.Json.JsonSerializer.Deserialize<SimplePocoJSON>(serialized)!;
        }

        [Benchmark]
        public SimplePocoProtobuf Protobuf()
        {
            var poco = ProtobufUtilities.GenerateSimple();
            var serialized = poco.ToByteArray();
            return SimplePocoProtobuf.Parser.ParseFrom(serialized);
        }

        [Benchmark]
        public SimplePocoMsgPack MessagePack()
        {
            var poco = MessagePackUtilities.GenerateSimple();
            var serialized = MessagePackSerializer.Serialize(poco);
            return MessagePackSerializer.Deserialize<SimplePocoMsgPack>(serialized);
        }

        [Benchmark]
        public SimplePocoBebopMessage Bebop()
        {
            var poco = BebobUtilities.GenerateSimpleMessage();
            var serialized = poco.Encode();
            return SimplePocoBebopMessage.Decode(serialized);
        }
    }
}
