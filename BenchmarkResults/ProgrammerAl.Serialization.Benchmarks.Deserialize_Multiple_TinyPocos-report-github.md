``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 11,158.7 ns | 163.02 ns | 144.51 ns |  26,560 B |
| SystemTextJson |  4,094.2 ns |  78.93 ns |  87.73 ns |     240 B |
|       Protobuf |    867.3 ns |  10.56 ns |   9.88 ns |   2,000 B |
|    MessagePack |    679.0 ns |   4.54 ns |   4.02 ns |     240 B |
|   BebopMessage |    192.4 ns |   2.66 ns |   2.48 ns |     320 B |
|    BebopStruct |    121.9 ns |   1.03 ns |   0.92 ns |     240 B |
