``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 958.76 ns | 13.843 ns | 12.948 ns |   1,592 B |
| SystemTextJson | 448.75 ns |  4.916 ns |  4.358 ns |     384 B |
|       Protobuf | 106.44 ns |  1.637 ns |  1.531 ns |     184 B |
|    MessagePack | 133.80 ns |  2.531 ns |  2.367 ns |     112 B |
|   BebopMessage | 101.00 ns |  1.474 ns |  1.378 ns |     408 B |
|    BebopStruct |  79.22 ns |  1.376 ns |  1.287 ns |     304 B |
