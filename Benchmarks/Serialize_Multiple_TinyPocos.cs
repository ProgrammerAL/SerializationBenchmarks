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
    public class Serialize_Multiple_TinyPocos
    {
        private const int LoopCount = 9;

        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = JsonConvert.SerializeObject(_instances.TinyJson);
            }

            return JsonConvert.SerializeObject(_instances.TinyJson);
        }

        [Benchmark]
        public string SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = System.Text.Json.JsonSerializer.Serialize(_instances.TinyJson);
            }

            return System.Text.Json.JsonSerializer.Serialize(_instances.TinyJson);
        }

        [Benchmark]
        public byte[] Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.TinyProtobuf.ToByteArray();
            }

            return _instances.TinyProtobuf.ToByteArray();
        }

        [Benchmark]
        public byte[] MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = MessagePackSerializer.Serialize(_instances.TinyMsgPack);
            }

            return MessagePackSerializer.Serialize(_instances.TinyMsgPack);
        }

        [Benchmark]
        public byte[] BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.TinyBebopMessage.Encode();
            }

            return _instances.TinyBebopMessage.Encode();
        }

        [Benchmark]
        public byte[] BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.TinyBebopStruct.Encode();
            }

            return _instances.TinyBebopStruct.Encode();
        }
    }
}
