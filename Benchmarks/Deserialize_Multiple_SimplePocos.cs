using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public class Deserialize_Multiple_SimplePocos
    {
        private readonly ImmutableArray<string> _jsonPocos;
        private readonly ImmutableArray<byte[]> _msgPackPocos;
        private readonly ImmutableArray<byte[]> _protobufPocos;
        private readonly ImmutableArray<byte[]> _bebopMessagePocos;
        private readonly ImmutableArray<byte[]> _bebopStructPocos;

        private const int EntitiesToTestCount = 10;
        private const int LoopCount = 9;
        private const int LastLoopIndex = 9;

        public Deserialize_Multiple_SimplePocos()
        {
            _jsonPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => JsonUtilities.GenerateSerializedSimple(x)).ToImmutableArray();
            _msgPackPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => MessagePackUtilities.GenerateSerializedSimple(x)).ToImmutableArray();
            _protobufPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => ProtobufUtilities.GenerateSerializedSimple(x)).ToImmutableArray();
            _bebopMessagePocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedSimpleMessage(x)).ToImmutableArray();
            _bebopStructPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedSimpleStruct(x)).ToImmutableArray();
        }

        [Benchmark]
        public SimplePocoJSON? NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = JsonConvert.DeserializeObject<SimplePocoJSON>(serializedPoco);
            }

            return JsonConvert.DeserializeObject<SimplePocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public SimplePocoJSON? SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = System.Text.Json.JsonSerializer.Deserialize<SimplePocoJSON>(serializedPoco);
            }

            return System.Text.Json.JsonSerializer.Deserialize<SimplePocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public SimplePocoProtobuf Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _protobufPocos[i];
                _ = SimplePocoProtobuf.Parser.ParseFrom(serializedPoco);
            }

            return SimplePocoProtobuf.Parser.ParseFrom(_protobufPocos[LastLoopIndex]);
        }

        [Benchmark]
        public SimplePocoMsgPack MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _msgPackPocos[i];
                _ = MessagePackSerializer.Deserialize<SimplePocoMsgPack>(serializedPoco);
            }

            return MessagePackSerializer.Deserialize<SimplePocoMsgPack>(_msgPackPocos[LastLoopIndex]);
        }

        [Benchmark]
        public SimplePocoBebopMessage BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopMessagePocos[i];
                _ = SimplePocoBebopMessage.Decode(serializedPoco);
            }

            return SimplePocoBebopMessage.Decode(_bebopMessagePocos[LastLoopIndex]);
        }

        [Benchmark]
        public SimplePocoBebopStruct BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopStructPocos[i];
                _ = SimplePocoBebopStruct.Decode(serializedPoco);
            }

            return SimplePocoBebopStruct.Decode(_bebopStructPocos[LastLoopIndex]);
        }
    }
}
