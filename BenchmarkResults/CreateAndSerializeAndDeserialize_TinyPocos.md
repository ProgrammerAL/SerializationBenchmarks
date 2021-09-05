``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 1,958.07 ns | 38.506 ns | 39.543 ns |   4,096 B |
| SystemTextJson |   797.51 ns | 15.240 ns | 16.940 ns |     280 B |
|       Protobuf |   153.49 ns |  3.047 ns |  4.067 ns |     328 B |
|    MessagePack |   156.78 ns |  2.947 ns |  2.756 ns |      80 B |
|   BebopMessage |    60.11 ns |  0.138 ns |  0.123 ns |     184 B |
|    BebopStruct |    36.75 ns |  0.498 ns |  0.466 ns |     112 B |
