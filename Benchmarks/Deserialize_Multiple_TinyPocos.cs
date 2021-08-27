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
    public class Deserialize_Multiple_TinyPocos
    {
        private readonly ImmutableArray<string> _jsonPocos;
        private readonly ImmutableArray<byte[]> _msgPackPocos;
        private readonly ImmutableArray<byte[]> _protobufPocos;
        private readonly ImmutableArray<byte[]> _bebopMessagePocos;
        private readonly ImmutableArray<byte[]> _bebopStructPocos;

        private const int EntitiesToTestCount = 10;
        private const int LoopCount = 9;
        private const int LastLoopIndex = 9;

        public Deserialize_Multiple_TinyPocos()
        {
            _jsonPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => JsonUtilities.GenerateSerializedTiny(x)).ToImmutableArray();
            _msgPackPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => MessagePackUtilities.GenerateSerializedTiny(x)).ToImmutableArray();
            _protobufPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => ProtobufUtilities.GenerateSerializedTiny(x)).ToImmutableArray();
            _bebopMessagePocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedTinyMessage(x)).ToImmutableArray();
            _bebopStructPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedTinyStruct(x)).ToImmutableArray();
        }

        [Benchmark]
        public TinyPocoJSON? NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = JsonConvert.DeserializeObject<TinyPocoJSON>(serializedPoco);
            }

            return JsonConvert.DeserializeObject<TinyPocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public TinyPocoJSON? SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = System.Text.Json.JsonSerializer.Deserialize<TinyPocoJSON>(serializedPoco);
            }

            return System.Text.Json.JsonSerializer.Deserialize<TinyPocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public TinyPocoProtobuf Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _protobufPocos[i];
                _ = TinyPocoProtobuf.Parser.ParseFrom(serializedPoco);
            }

            return TinyPocoProtobuf.Parser.ParseFrom(_protobufPocos[LastLoopIndex]);
        }

        [Benchmark]
        public TinyPocoMsgPack MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _msgPackPocos[i];
                _ = MessagePackSerializer.Deserialize<TinyPocoMsgPack>(serializedPoco);
            }

            return MessagePackSerializer.Deserialize<TinyPocoMsgPack>(_msgPackPocos[LastLoopIndex]);
        }

        [Benchmark]
        public TinyPocoBebopMessage BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopMessagePocos[i];
                _ = TinyPocoBebopMessage.Decode(serializedPoco);
            }

            return TinyPocoBebopMessage.Decode(_bebopMessagePocos[LastLoopIndex]);
        }

        [Benchmark]
        public TinyPocoBebopStruct BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopStructPocos[i];
                _ = TinyPocoBebopStruct.Decode(serializedPoco);
            }

            return TinyPocoBebopStruct.Decode(_bebopStructPocos[LastLoopIndex]);
        }
    }
}
