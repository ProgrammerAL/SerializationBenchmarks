``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 3,308.5 ns | 44.83 ns | 41.94 ns |   4,424 B |
| SystemTextJson | 1,284.7 ns | 25.71 ns | 34.32 ns |     512 B |
|       Protobuf |   277.9 ns |  1.71 ns |  1.43 ns |     488 B |
|    MessagePack |   338.5 ns |  6.74 ns |  5.97 ns |     240 B |
|   BebopMessage |   162.8 ns |  3.20 ns |  3.15 ns |     544 B |
|    BebopStruct |   129.1 ns |  1.13 ns |  0.88 ns |     432 B |
