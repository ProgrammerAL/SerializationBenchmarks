using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

namespace ProgrammerAl.Serialization.Entities
{
    public class EntityInstances
    {
        //Tiny POCOs
        public TinyPocoJSON TinyJson { get; } = JsonUtilities.GenerateTiny();
        public TinyPocoMsgPack TinyMsgPack { get; } = MessagePackUtilities.GenerateTiny();
        public TinyPocoProtobuf TinyProtobuf { get; } = ProtobufUtilities.GenerateTiny();
        public TinyPocoBebopMessage TinyBebopMessage { get; } = BebobUtilities.GenerateTinyMessage();
        public TinyPocoBebopStruct TinyBebopStruct { get; } = BebobUtilities.GenerateTinyStruct();

        //Simple POCOs
        public SimplePocoJSON SimpleJson { get; } = JsonUtilities.GenerateSimple();
        public SimplePocoMsgPack SimpleMsgPack { get; } = MessagePackUtilities.GenerateSimple();
        public SimplePocoProtobuf SimpleProtobuf { get; } = ProtobufUtilities.GenerateSimple();
        public SimplePocoBebopMessage SimpleBebopMessage { get; } = BebobUtilities.GenerateSimpleMessage();
        public SimplePocoBebopStruct SimpleBebopStruct { get; } = BebobUtilities.GenerateSimpleStruct();

        //Complex POCOs
        public ComplexPocoJSON ComplexJson { get; } = JsonUtilities.GenerateComplex();
        public ComplexPocoMsgPack ComplexMsgPack { get; } = MessagePackUtilities.GenerateComplex();
        public ComplexPocoProtobuf ComplexProtobuf { get; } = ProtobufUtilities.GenerateComplex();
        public ComplexPocoBebopMessage ComplexBebopMessage { get; } = BebobUtilities.GenerateComplexMessage();
        public ComplexPocoBebopStruct ComplexBebopStruct { get; } = BebobUtilities.GenerateComplexStruct();
        
        //Serialized Tiny POCOs
        public string SerializedTinyJson { get; } = JsonUtilities.GenerateSerializedTiny();
        public byte[] SerializedTinyMsgPack { get; } = MessagePackUtilities.GenerateSerializedTiny();
        public byte[] SerializedTinyProtobuf { get; } = ProtobufUtilities.GenerateSerializedTiny();
        public byte[] SerializedTinyBebopMessage { get; } = BebobUtilities.GenerateSerializedTinyMessage();
        public byte[] SerializedTinyBebopStruct { get; } = BebobUtilities.GenerateSerializedTinyStruct();

        //Serialized Simple POCOs
        public string SerializedSimpleJson { get; } = JsonUtilities.GenerateSerializedSimple();
        public byte[] SerializedSimpleMsgPack { get; } = MessagePackUtilities.GenerateSerializedSimple();
        public byte[] SerializedSimpleProtobuf { get; } = ProtobufUtilities.GenerateSerializedSimple();
        public byte[] SerializedSimpleBebopMessage { get; } = BebobUtilities.GenerateSerializedSimpleMessage();
        public byte[] SerializedSimpleBebopStruct { get; } = BebobUtilities.GenerateSerializedSimpleStruct();

        //Serialized Complex POCOs
        public string SerializedComplexJson { get; } = JsonUtilities.GenerateSerializedComplex();
        public byte[] SerializedComplexMsgPack { get; } = MessagePackUtilities.GenerateSerializedComplex();
        public byte[] SerializedComplexProtobuf { get; } = ProtobufUtilities.GenerateSerializedComplex();
        public byte[] SerializedComplexBebopMessage { get; } = BebobUtilities.GenerateSerializedComplexMessage();
        public byte[] SerializedComplexBebopStruct { get; } = BebobUtilities.GenerateSerializedComplexStruct();
    }
}
