``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |     Error |    StdDev | Allocated |
|--------------- |-----------:|----------:|----------:|----------:|
| NewtonsoftJson | 6,531.4 ns | 123.57 ns | 115.59 ns |  14,160 B |
| SystemTextJson | 2,722.8 ns |  33.28 ns |  27.79 ns |   2,320 B |
|       Protobuf |   521.9 ns |   9.69 ns |   8.59 ns |     960 B |
|    MessagePack |   734.8 ns |   7.33 ns |   6.85 ns |     320 B |
|   BebopMessage |   384.5 ns |   4.27 ns |   3.99 ns |   1,200 B |
|    BebopStruct |   247.0 ns |   2.08 ns |   1.84 ns |     640 B |
