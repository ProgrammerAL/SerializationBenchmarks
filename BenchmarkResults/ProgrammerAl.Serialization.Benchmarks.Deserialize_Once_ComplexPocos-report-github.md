``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 2,134.6 ns | 41.64 ns | 40.90 ns |   2,864 B |
| SystemTextJson |   675.3 ns | 11.58 ns | 10.83 ns |     160 B |
|       Protobuf | 1,051.4 ns | 20.85 ns | 24.82 ns |   1,288 B |
|    MessagePack | 1,584.6 ns | 31.02 ns | 38.10 ns |     552 B |
|   BebopMessage |   231.7 ns |  3.50 ns |  3.28 ns |     592 B |
|    BebopStruct |   166.1 ns |  2.16 ns |  1.91 ns |     504 B |
