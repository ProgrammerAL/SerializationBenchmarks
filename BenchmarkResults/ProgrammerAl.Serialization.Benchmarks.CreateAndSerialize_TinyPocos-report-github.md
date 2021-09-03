``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |      Mean |    Error |   StdDev | Allocated |
|--------------- |----------:|---------:|---------:|----------:|
| NewtonsoftJson | 673.06 ns | 8.864 ns | 8.292 ns |   1,440 B |
| SystemTextJson | 292.73 ns | 5.693 ns | 6.091 ns |     256 B |
|       Protobuf |  59.45 ns | 0.885 ns | 0.785 ns |     128 B |
|    MessagePack |  83.04 ns | 1.577 ns | 1.937 ns |      56 B |
|   BebopMessage |  46.88 ns | 0.978 ns | 0.915 ns |     152 B |
|    BebopStruct |  24.38 ns | 0.503 ns | 0.471 ns |      88 B |
