using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace Benchmark_Serilizations
{
    class Program
    {
        static void Main(string[] args)
        {
            var runJob = Job.Dry
                .WithRuntime(CoreRtRuntime.CoreRt50)
                .WithPlatform(Platform.AnyCpu)
                .WithJit(Jit.Default);
            var runConfig = DefaultConfig.Instance;
            runConfig.AddJob(runJob);
            runConfig.AddDiagnoser(MemoryDiagnoser.Default);
            runConfig.AddExporter(MarkdownExporter.Default);
            runConfig.AddValidator(ExecutionValidator.FailOnError);

            var summary = BenchmarkRunner.Run<Serialization_SimplePocos_Benchmark>(config: runConfig);
        }
    }
}
