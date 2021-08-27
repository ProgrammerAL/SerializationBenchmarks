using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Google.Protobuf;
using MessagePack;
using Newtonsoft.Json;
using ProgrammerAl.Serialization.Entities;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Serialize_Multiple_SimplePocos
    {
        private const int LoopCount = 9;

        private readonly EntityInstances _instances = new();

        [Benchmark]
        public string NewtonsoftJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = JsonConvert.SerializeObject(_instances.SimpleJson);
            }

            return JsonConvert.SerializeObject(_instances.SimpleJson);
        }

        [Benchmark]
        public string SystemTextJson()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = System.Text.Json.JsonSerializer.Serialize(_instances.SimpleJson);
            }

            return System.Text.Json.JsonSerializer.Serialize(_instances.SimpleJson);
        }

        [Benchmark]
        public byte[] Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.SimpleProtobuf.ToByteArray();
            }

            return _instances.SimpleProtobuf.ToByteArray();
        }

        [Benchmark]
        public byte[] MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = MessagePackSerializer.Serialize(_instances.SimpleMsgPack);
            }

            return MessagePackSerializer.Serialize(_instances.SimpleMsgPack);
        }
        
        [Benchmark]
        public byte[] BebopMessage()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.SimpleBebopMessage.Encode();
            }

            return _instances.SimpleBebopMessage.Encode();
        }

        [Benchmark]
        public byte[] BebopStruct()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _instances.SimpleBebopStruct.Encode();
            }

            return _instances.SimpleBebopStruct.Encode();
        }
    }
}
