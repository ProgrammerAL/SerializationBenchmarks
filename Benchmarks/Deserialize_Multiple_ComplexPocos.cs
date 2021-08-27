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
    public class Deserialize_Multiple_ComplexPocos
    {
        private readonly ImmutableArray<string> _jsonPocos;
        private readonly ImmutableArray<byte[]> _msgPackPocos;
        private readonly ImmutableArray<byte[]> _protobufPocos;
        private readonly ImmutableArray<byte[]> _bebopMessagePocos;
        private readonly ImmutableArray<byte[]> _bebopStructPocos;

        private const int EntitiesToTestCount = 10;
        private const int LoopCount = 9;
        private const int LastLoopIndex = 9;

        public Deserialize_Multiple_ComplexPocos()
        {
            _jsonPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => JsonUtilities.GenerateSerializedComplex(x)).ToImmutableArray();
            _msgPackPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => MessagePackUtilities.GenerateSerializedComplex(x)).ToImmutableArray();
            _protobufPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => ProtobufUtilities.GenerateSerializedComplex(x)).ToImmutableArray();
            _bebopMessagePocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedComplexMessage(x)).ToImmutableArray();
            _bebopStructPocos = Enumerable.Range(1, EntitiesToTestCount).Select(x => BebobUtilities.GenerateSerializedComplexStruct(x)).ToImmutableArray();
        }

        [Benchmark]
        public ComplexPocoJSON? NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = JsonConvert.DeserializeObject<ComplexPocoJSON>(serializedPoco);
            }

            return JsonConvert.DeserializeObject<ComplexPocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public ComplexPocoJSON? SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _jsonPocos[i];
                _ = System.Text.Json.JsonSerializer.Deserialize<ComplexPocoJSON>(serializedPoco);
            }

            return System.Text.Json.JsonSerializer.Deserialize<ComplexPocoJSON>(_jsonPocos[LastLoopIndex]);
        }

        [Benchmark]
        public ComplexPocoProtobuf Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _protobufPocos[i];
                _ = ComplexPocoProtobuf.Parser.ParseFrom(serializedPoco);
            }

            return ComplexPocoProtobuf.Parser.ParseFrom(_protobufPocos[LastLoopIndex]);
        }

        [Benchmark]
        public ComplexPocoMsgPack MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _msgPackPocos[i];
                _ = MessagePackSerializer.Deserialize<ComplexPocoMsgPack>(serializedPoco);
            }

            return MessagePackSerializer.Deserialize<ComplexPocoMsgPack>(_msgPackPocos[LastLoopIndex]);
        }

        [Benchmark]
        public ComplexPocoBebopMessage BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopMessagePocos[i];
                _ = ComplexPocoBebopMessage.Decode(serializedPoco);
            }

            return ComplexPocoBebopMessage.Decode(_bebopMessagePocos[LastLoopIndex]);
        }

        [Benchmark]
        public ComplexPocoBebopStruct BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                var serializedPoco = _bebopStructPocos[i];
                _ = ComplexPocoBebopStruct.Decode(serializedPoco);
            }

            return ComplexPocoBebopStruct.Decode(_bebopStructPocos[LastLoopIndex]);
        }
    }
}
