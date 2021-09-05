``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 20.858 μs | 0.3218 μs | 0.3010 μs |     28 KB |
| SystemTextJson |  7.013 μs | 0.1307 μs | 0.1223 μs |      2 KB |
|       Protobuf | 11.201 μs | 0.1796 μs | 0.1680 μs |     13 KB |
|    MessagePack | 17.040 μs | 0.3366 μs | 0.4608 μs |      5 KB |
|   BebopMessage |  2.251 μs | 0.0379 μs | 0.0336 μs |      6 KB |
|    BebopStruct |  1.748 μs | 0.0335 μs | 0.0314 μs |      5 KB |
