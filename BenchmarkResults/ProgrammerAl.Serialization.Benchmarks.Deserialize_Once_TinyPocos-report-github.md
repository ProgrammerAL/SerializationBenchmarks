``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 1,117.70 ns | 22.164 ns | 30.338 ns |   2,656 B |
| SystemTextJson |   414.44 ns |  6.890 ns |  6.445 ns |      24 B |
|       Protobuf |    85.51 ns |  1.330 ns |  1.111 ns |     200 B |
|    MessagePack |    75.12 ns |  0.371 ns |  0.310 ns |      24 B |
|   BebopMessage |    18.47 ns |  0.415 ns |  0.509 ns |      32 B |
|    BebopStruct |    11.93 ns |  0.282 ns |  0.301 ns |      24 B |
