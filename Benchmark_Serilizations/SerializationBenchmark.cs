using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benchmark_Serilizations.Entities;
using Benchmark_Serilizations.Entities.Protobuf;
using BenchmarkDotNet.Attributes;
using BenchmarkSerilizations.Entities.Bebop;
using Google.Protobuf;
using MessagePack;
using Newtonsoft.Json;

namespace Benchmark_Serilizations
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        private readonly SimplePoco_JSON _simpleJson;
        private readonly SimplePoco_MsgPack _simpleMsgPk;
        private readonly BasicObject_Protobuf _simpleProtobuf;
        private readonly BasicObjectBebop _simpleBebop;

        public SerializationBenchmark()
        {
            _simpleJson = new SimplePoco_JSON
            { 
                Id = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyObjectEnum.Two
            };

            _simpleMsgPk = new SimplePoco_MsgPack
            {
                Id = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyMsgPackObjectEnum.Two
            };

            _simpleProtobuf = new BasicObject_Protobuf
            {
                Id = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyProtoEnum.Two
            };
            
            _simpleBebop = new BasicObjectBebop
            {
                ID = 123_456,
                Name = "Snuggles the Destroyer of Worlds",
                EnumValue = MyBebopEnum.Two
            };
        }

        [Benchmark]
        public string Serialize_SimpleObject_Json_Newtonsoft()
            => JsonConvert.SerializeObject(_simpleJson);

        [Benchmark]
        public string Serialize_SimpleObject_Json_SystemText()
            => System.Text.Json.JsonSerializer.Serialize(_simpleJson);

        [Benchmark]
        public byte[] Serialize_SimpleObject_Protobuf()
            => _simpleProtobuf.ToByteArray();

        [Benchmark]
        public byte[] Serialize_SimpleObject_MessagePack()
            => MessagePackSerializer.Serialize(_simpleMsgPk);

        [Benchmark]
        public byte[] Serialize_SimpleObject_Bebop()
            => BasicObjectBebop.Encode(_simpleBebop);
    }
}
