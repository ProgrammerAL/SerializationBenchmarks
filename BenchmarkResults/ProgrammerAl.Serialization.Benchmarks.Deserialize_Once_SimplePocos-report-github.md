``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 2,074.83 ns | 41.122 ns | 48.953 ns |   2,832 B |
| SystemTextJson |   702.21 ns | 11.617 ns | 10.866 ns |     128 B |
|       Protobuf |   151.50 ns |  2.866 ns |  2.681 ns |     304 B |
|    MessagePack |   157.08 ns |  0.797 ns |  0.666 ns |     128 B |
|   BebopMessage |    50.14 ns |  1.046 ns |  1.566 ns |     136 B |
|    BebopStruct |    36.87 ns |  0.301 ns |  0.281 ns |     128 B |
