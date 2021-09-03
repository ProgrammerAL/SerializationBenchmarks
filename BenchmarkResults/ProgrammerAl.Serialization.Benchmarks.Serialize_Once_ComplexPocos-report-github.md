``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |     Error |    StdDev | Allocated |
|--------------- |-----------:|----------:|----------:|----------:|
| NewtonsoftJson | 5,862.3 ns | 112.17 ns | 115.19 ns |   5,312 B |
| SystemTextJson | 2,889.7 ns |  56.72 ns |  69.65 ns |   1,720 B |
|       Protobuf |   926.5 ns |  16.46 ns |  15.40 ns |     400 B |
|    MessagePack |   631.6 ns |   9.67 ns |   8.58 ns |     304 B |
|   BebopMessage |   361.0 ns |   3.47 ns |   3.08 ns |   1,264 B |
|    BebopStruct |   239.2 ns |   1.85 ns |   1.55 ns |   1,032 B |
