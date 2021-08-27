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

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Serialize_Multiple_ComplexPocos
    {
        private const int LoopCount = 9;

        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = JsonConvert.SerializeObject(_instances.ComplexJson);
            }

            return JsonConvert.SerializeObject(_instances.ComplexJson);
        }

        [Benchmark]
        public string SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = System.Text.Json.JsonSerializer.Serialize(_instances.ComplexJson);
            }

            return System.Text.Json.JsonSerializer.Serialize(_instances.ComplexJson);
        }

        [Benchmark]
        public byte[] Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.ComplexProtobuf.ToByteArray();
            }

            return _instances.ComplexProtobuf.ToByteArray();
        }

        [Benchmark]
        public byte[] MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = MessagePackSerializer.Serialize(_instances.ComplexMsgPack);
            }

            return MessagePackSerializer.Serialize(_instances.ComplexMsgPack);
        }

        [Benchmark]
        public byte[] BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.ComplexBebopMessage.Encode();
            }

            return _instances.ComplexBebopMessage.Encode();
        }

        [Benchmark]
        public byte[] BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.ComplexBebopStruct.Encode();
            }

            return _instances.ComplexBebopStruct.Encode();
        }
    }
}
