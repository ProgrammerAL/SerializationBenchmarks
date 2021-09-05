``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22449
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|         Method |       Mean |     Error |    StdDev | Allocated |
|--------------- |-----------:|----------:|----------:|----------:|
| NewtonsoftJson | 9,520.9 ns | 183.50 ns | 196.34 ns |  15,520 B |
| SystemTextJson | 4,395.7 ns |  84.45 ns |  90.36 ns |   3,440 B |
|       Protobuf | 1,019.8 ns |  17.66 ns |  16.52 ns |   1,360 B |
|    MessagePack | 1,224.8 ns |  20.04 ns |  18.74 ns |     720 B |
|   BebopMessage |   887.8 ns |  14.30 ns |  13.37 ns |   3,600 B |
|    BebopStruct |   637.8 ns |   3.65 ns |   3.05 ns |   2,640 B |
