``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 935.92 ns | 10.962 ns |  9.718 ns |   1,552 B |
| SystemTextJson | 453.66 ns |  8.975 ns | 10.684 ns |     344 B |
|       Protobuf | 100.82 ns |  1.275 ns |  1.192 ns |     136 B |
|    MessagePack | 135.52 ns |  2.704 ns |  3.791 ns |      72 B |
|   BebopMessage |  94.40 ns |  1.924 ns |  3.052 ns |     360 B |
|    BebopStruct |  65.97 ns |  0.968 ns |  0.906 ns |     264 B |
