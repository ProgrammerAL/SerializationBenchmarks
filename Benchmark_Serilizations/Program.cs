using System;

using BenchmarkDotNet.Running;

namespace Benchmark_Serilizations
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializationBenchmark>();
        }
    }
}
