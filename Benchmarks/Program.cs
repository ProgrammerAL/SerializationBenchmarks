﻿#pragma warning disable IDE0058 // Expression value is never used

using System;

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace ProgrammerAl.Serialization.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var memoryDiagnoserConfig = new MemoryDiagnoserConfig(displayGenColumns: false);
            var memoryDiagnoser = new MemoryDiagnoser(memoryDiagnoserConfig);

            var runConfig = DefaultConfig.Instance
                                        .AddDiagnoser(memoryDiagnoser)
                                        .AddExporter(MarkdownExporter.GitHub)
                                        .AddValidator(ExecutionValidator.FailOnError);

            BenchmarkRunner.Run<CreateAndSerialize_TinyPocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerialize_SimplePocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerialize_ComplexPocos>(runConfig);

            BenchmarkRunner.Run<Serialize_Once_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Once_SimplePocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Once_ComplexPocos>(runConfig);

            BenchmarkRunner.Run<Serialize_Multiple_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Multiple_SimplePocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Multiple_ComplexPocos>(runConfig);

            BenchmarkRunner.Run<CreateAndSerializeAndDeserialize_TinyPocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerializeAndDeserialize_SimplePocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerializeAndDeserialize_ComplexPocos>(runConfig);

            BenchmarkRunner.Run<Deserialize_Once_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Deserialize_Once_SimplePocos>(runConfig);
            BenchmarkRunner.Run<Deserialize_Once_ComplexPocos>(runConfig);

            BenchmarkRunner.Run<Deserialize_Multiple_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Deserialize_Multiple_SimplePocos>(runConfig);
            BenchmarkRunner.Run<Deserialize_Multiple_ComplexPocos>(runConfig);
        }
    }
}
#pragma warning restore IDE0058 // Expression value is never used
