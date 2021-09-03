``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 21,282.9 ns | 348.70 ns | 326.18 ns |     28 KB |
| SystemTextJson |  7,195.9 ns | 138.69 ns | 142.42 ns |      1 KB |
|       Protobuf |  1,497.3 ns |  29.02 ns |  28.50 ns |      3 KB |
|    MessagePack |  1,484.7 ns |  22.81 ns |  21.34 ns |      1 KB |
|   BebopMessage |    467.9 ns |   9.10 ns |   8.51 ns |      1 KB |
|    BebopStruct |    360.0 ns |   3.41 ns |   2.85 ns |      1 KB |
