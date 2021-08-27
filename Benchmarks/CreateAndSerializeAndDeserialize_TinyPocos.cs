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
    public class CreateAndSerializeAndDeserialize_TinyPocos
    {
        [Benchmark]
        public TinyPocoJSON NewtonsoftJson()
        {
            var poco = JsonUtilities.GenerateTiny();
            var serialized = JsonConvert.SerializeObject(poco);
            return JsonConvert.DeserializeObject<TinyPocoJSON>(serialized)!;
        }

        [Benchmark]
        public TinyPocoJSON SystemTextJson()
        {
            var poco = JsonUtilities.GenerateTiny();
            var serialized = System.Text.Json.JsonSerializer.Serialize(poco);
            return System.Text.Json.JsonSerializer.Deserialize<TinyPocoJSON>(serialized)!;
        }

        [Benchmark]
        public TinyPocoProtobuf Protobuf()
        {
            var poco = ProtobufUtilities.GenerateTiny();
            var serialized = poco.ToByteArray();
            return TinyPocoProtobuf.Parser.ParseFrom(serialized);
        }

        [Benchmark]
        public TinyPocoMsgPack MessagePack()
        {
            var poco = MessagePackUtilities.GenerateTiny();
            var serialized = MessagePackSerializer.Serialize(poco);
            return MessagePackSerializer.Deserialize<TinyPocoMsgPack>(serialized);
        }

        [Benchmark]
        public TinyPocoBebopMessage BebopMessage()
        {
            var poco = BebobUtilities.GenerateTinyMessage();
            var serialized = poco.Encode();
            return TinyPocoBebopMessage.Decode(serialized);
        }

        [Benchmark]
        public TinyPocoBebopStruct BebopStruct()
        {
            var poco = BebobUtilities.GenerateTinyStruct();
            var serialized = poco.Encode();
            return TinyPocoBebopStruct.Decode(serialized);
        }
    }
}
