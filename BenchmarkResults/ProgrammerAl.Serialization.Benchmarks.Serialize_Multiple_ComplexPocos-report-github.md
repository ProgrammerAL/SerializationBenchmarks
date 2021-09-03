``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 58.077 μs | 0.9506 μs | 0.8892 μs |     52 KB |
| SystemTextJson | 29.443 μs | 0.5644 μs | 0.5279 μs |     17 KB |
|       Protobuf |  9.316 μs | 0.0494 μs | 0.0386 μs |      4 KB |
|    MessagePack |  6.136 μs | 0.1170 μs | 0.1252 μs |      3 KB |
|   BebopMessage |  5.783 μs | 0.0708 μs | 0.0662 μs |     12 KB |
|    BebopStruct |  2.671 μs | 0.0441 μs | 0.0413 μs |     10 KB |
