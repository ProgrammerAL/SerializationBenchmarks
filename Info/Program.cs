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
            _ = tinyTable.AddRow("Bebop", BebobUtilities.GenerateSerializedTiny().Length);

            tinyTable.Write(Format.MarkDown);

            Console.WriteLine();

            var simpleTable = new ConsoleTable("Name", "Size (bytes)");

            Console.WriteLine("Simple Objects Serialized Size:");
            _ = simpleTable.AddRow("JSON", JsonUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("Protobuf", ProtobufUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("MessagePack", MessagePackUtilities.GenerateSerializedSimple().Length);
            _ = simpleTable.AddRow("Bebop", BebobUtilities.GenerateSerializedSimple().Length);

            simpleTable.Write(Format.MarkDown);
        }
    }
}
