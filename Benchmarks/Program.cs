#pragma warning disable IDE0058 // Expression value is never used

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
            var runConfig = DefaultConfig.Instance
                                        .AddDiagnoser(MemoryDiagnoser.Default)
                                        .AddExporter(MarkdownExporter.Default)
                                        .AddValidator(ExecutionValidator.FailOnError);

            BenchmarkRunner.Run<CreateAndSerialize_TinyPocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerialize_SimplePocos>(runConfig);

            BenchmarkRunner.Run<Serialize_Once_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Once_SimplePocos>(runConfig);

            BenchmarkRunner.Run<Serialize_Multiple_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Serialize_Multiple_SimplePocos>(runConfig);

            BenchmarkRunner.Run<CreateAndSerializeAndDeserialize_TinyPocos>(runConfig);
            BenchmarkRunner.Run<CreateAndSerializeAndDeserialize_SimplePocos>(runConfig);

            BenchmarkRunner.Run<Deserialize_Once_TinyPocos>(runConfig);
            BenchmarkRunner.Run<Deserialize_Multiple_TinyPocos>(runConfig);
        }
    }
}
#pragma warning restore IDE0058 // Expression value is never used
