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
using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class Serialize_Multiple_SimplePocos
    {
        private const int LoopCount = 9;
        
        private readonly SimplePocoJSON _jsonPoco;
        private readonly SimplePocoMsgPack _msgPackPoco;
        private readonly SimplePocoProtobuf _protobufPoco;
        private readonly SimplePocoBebop _bebopPoco;

        public Serialize_Multiple_SimplePocos()
        {
            _jsonPoco = JsonUtilities.GenerateSimple();
            _msgPackPoco = MessagePackUtilities.GenerateSimple();
            _protobufPoco = ProtobufUtilities.GenerateSimple();
            _bebopPoco = BebobUtilities.GenerateSimple();
        }

        [Benchmark]
        public string Serialize_Json_Newtonsoft()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = JsonConvert.SerializeObject(_jsonPoco);
            }

            return JsonConvert.SerializeObject(_jsonPoco);
        }

        [Benchmark]
        public string Serialize_Json_SystemText()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = System.Text.Json.JsonSerializer.Serialize(_jsonPoco);
            }

            return System.Text.Json.JsonSerializer.Serialize(_jsonPoco);
        }

        [Benchmark]
        public byte[] Serialize_Protobuf()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = _protobufPoco.ToByteArray();
            }

            return _protobufPoco.ToByteArray();
        }

        [Benchmark]
        public byte[] Serialize_MessagePack()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _ = MessagePackSerializer.Serialize(_msgPackPoco);
            }

            return MessagePackSerializer.Serialize(_msgPackPoco);
        }
        
        [Benchmark]
        public byte[] Serialize_Bebop()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                _bebopPoco.Encode();
            }

            return _bebopPoco.Encode();
        }
    }
}
