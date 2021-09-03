``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 6,874.1 ns | 99.86 ns | 93.41 ns |   5,664 B |
| SystemTextJson | 3,619.8 ns | 69.57 ns | 68.33 ns |   2,072 B |
|       Protobuf | 2,106.6 ns | 25.87 ns | 24.20 ns |   1,309 B |
|    MessagePack | 1,272.1 ns | 18.69 ns | 17.48 ns |     656 B |
|   Bebopmessage | 1,029.6 ns | 14.87 ns | 13.91 ns |   1,648 B |
|    BebopStruct |   848.4 ns | 14.06 ns | 13.15 ns |   1,328 B |
