using Newtonsoft.Json;

using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

using Google.Protobuf;
using MessagePack;

using System;
using ConsoleTables;

namespace Info
{
    class Program
    {
        static void Main(string[] args)
        {
            var tinyTable = new ConsoleTable("Name", "Size (bytes)");
            
            Console.WriteLine("Tiny Objects Serialized Size:");
            _ = tinyTable.AddRow("JSON", JsonUtilities.GenerateSerializedTiny().Length);
            _ = tinyTable.AddRow("Protobuf", ProtobufUtilities.GenerateSerializedTiny().Length);
            _ = tinyTable.AddRow("MessagePack", MessagePackUtilities.GenerateSerializedTiny().Length);
            _ = tinyTable.AddRow("Bebop Message", BebobUtilities.GenerateSerializedTinyMessage().Length);
            _ = tinyTable.AddRow("Bebop Struct", BebobUtilities.GenerateSerializedTinyStruct().Length);

            tinyTable.Write(Format.MarkDown);

            var simpleTable = new ConsoleTable("Name", "Size (bytes)");

            Console.WriteLine("Simple Objects Serialized Size:");
            _ = simpleTable.AddRow("JSON", JsonUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("Protobuf", ProtobufUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("MessagePack", MessagePackUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("Bebop Message", BebobUtilities.GenerateSerializedSimpleMessage().Length);
            _ = simpleTable.AddRow("Bebop Struct", BebobUtilities.GenerateSerializedSimpleStruct().Length);

            simpleTable.Write(Format.MarkDown);

            var complexTable = new ConsoleTable("Name", "Size (bytes)");

            Console.WriteLine("Complex Objects Serialized Size:");
            _ = complexTable.AddRow("JSON", JsonUtilities.GenerateSerializedComplex().Length);
            _ = complexTable.AddRow("Protobuf", ProtobufUtilities.GenerateSerializedComplex().Length);
            _ = complexTable.AddRow("MessagePack", MessagePackUtilities.GenerateSerializedComplex().Length);
            _ = complexTable.AddRow("Bebop Message", BebobUtilities.GenerateSerializedComplexMessage().Length);
            _ = complexTable.AddRow("Bebop Struct", BebobUtilities.GenerateSerializedComplexStruct().Length);

            complexTable.Write(Format.MarkDown);
        }
    }
}
