``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 18.811 μs | 0.2401 μs | 0.2129 μs |     10 KB |
| SystemTextJson |  8.543 μs | 0.0488 μs | 0.0407 μs |      3 KB |
|       Protobuf |  3.338 μs | 0.0650 μs | 0.0773 μs |      3 KB |
|    MessagePack |  3.220 μs | 0.0624 μs | 0.0613 μs |      1 KB |
|   BebopMessage |  1.292 μs | 0.0249 μs | 0.0277 μs |      2 KB |
|    BebopStruct |  1.162 μs | 0.0126 μs | 0.0105 μs |      2 KB |
