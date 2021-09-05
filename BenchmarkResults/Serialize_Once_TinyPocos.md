``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 664.80 ns | 11.115 ns | 10.397 ns |   1,416 B |
| SystemTextJson | 283.30 ns |  5.643 ns |  7.533 ns |     232 B |
|       Protobuf |  50.99 ns |  1.042 ns |  0.975 ns |      96 B |
|    MessagePack |  73.64 ns |  1.178 ns |  1.102 ns |      32 B |
|   BebopMessage |  38.21 ns |  0.637 ns |  0.596 ns |     120 B |
|    BebopStruct |  22.17 ns |  0.119 ns |  0.106 ns |      64 B |
