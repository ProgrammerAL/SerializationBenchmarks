
** THIS IS STILL A WORK IN PROGRESS **

# .NET Serialization Benchmarks
There are 2 purposes to this repo:
1. To provide performance comparisons of serializing/deserializing different formats using .NET libraries.
1. To create a straight forward way for anyone to run their own benchmarks for their own custom testing.

The formats tested are:
- JSON
- Protobuf
- MessagePack
- Bebop

There are 2 projects that generate performance data:
- Benchmarks
- Info

## Results TL;DR

All of the benchmark results are below, but here's a summary of how each serialization protocol performed.

- JSON
- Protobuf
- MessagePack
- Bebop


#### Types of Objects Serialized/Deserialized

- 'Tiny' objects are objects with 2 integer properties
- 'Simple' objects are obejcts with a handful of different properties (integer, integer, string, enum)
- 'Complex' objects are objects with multiple types of properties and a child collection


## C# projects Overview

There are 2 projects that provide information. The first is the 'Benchmarks' project. This uses Benchmark.NET to run micro benchmarks on the different serialization libraries. The second is the 'Info' project. This console project outputs information about serialization formats that are useful to know, but are not part of a benchmark. For example, it will output the size of serialized objects. This is helpful to know because smaller objects travel over the wire faster.

## Overview of Serialization Formats

### JSON

JSON is the default serialization protocol used in so many applications. Many of us assume we will serialize to JSON unless we have a good reason to not use it. It will never be the fastest serialization protocol because it is human readable, and thus it's not as compact as the binary protocols on our list. But because it is the default protocol used by many, I wanted it on this list for comparison sake.

### Protobuf

Protobuf is a binary serialization format created and maintained by Google. It is also the serialization format used by GRPC. I personally consider it the default binary format to use when given the choice because it is fast to serialize/deserialize, is consistently maintained by Google, and the byte buffer it generates is small. As you can see from the benchmarks above, it has the best performance-to-size ratio. It's not always the fastest, but it is very fast and usually generates the smallest message. You can read more from Google at https://developers.google.com/protocol-buffers/.

### MessagePack

Most .NET developers will be familiar with using MessagePack with SignalR. While it's not enabled by default (JSON is the default), there is support out of the box for enabled MessagePack for all messages with SignalR. Of the 3 binary serialization protocols we benchmark, this is the slowest. But the message size is a very close second place, and it is always the clear winner in GC Allocated memory. You can read more about MessagePack at the official website https://msgpack.org/, or the repo for the library used in .NET here https://github.com/neuecc/MessagePack-CSharp.

### Bebop

The newest protocol on this list. It was created by Rainway, the Video Game streaming company. It's goal is to be the fastest serialization protocol. As you can see from the benchmarks above, it is easily the fastest. However of the 3 binary protocols we are benchmarking, its message size is the largest and it allocates the most amount of memory. You can read more about it on their repo at https://github.com/RainwayApp/bebop.


## Benchmark Results

The below benchmarks were run on August 26, 2021 with the latest version of each.

### Hardware
These were generated from a desktop with the following characteristics:
``` ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.22000
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
```

### Serialized Objects

Tiny Objects Serialized Size:
| Name        | Size (bytes) |
|-------------|--------------|
| JSON        | 27           |
| Protobuf    | 6            |
| MessagePack | 7            |
| Bebop       | 15           |

Simple Objects Serialized Size:
| Name        | Size (bytes) |
|-------------|--------------|
| JSON        | 83           |
| Protobuf    | 42           |
| MessagePack | 42           |
| Bebop       | 57           |

Complex Objects Serialized Size:
| Name        | Size (bytes) |
|-------------|--------------|
| JSON        | 83           |
| Protobuf    | 306          |
| MessagePack | 279          |
| Bebop       | 243          |

### Serialize POCOs Once

This is the most basic serialization benchmark. It only measures the performance of the serialization. The purpose is to see the raw speed of a single serialization of the object.

#### Tiny POCOs

|         Method |      Mean |    Error |   StdDev |    Median | Allocated |
|--------------- |----------:|---------:|---------:|----------:|----------:|
| NewtonsoftJson | 754.75 ns | 6.209 ns | 5.808 ns | 754.63 ns |   1,416 B |
| SystemTextJson | 305.23 ns | 2.471 ns | 2.311 ns | 304.25 ns |     232 B |
|       Protobuf |  55.41 ns | 0.832 ns | 0.778 ns |  55.39 ns |      96 B |
|    MessagePack |  77.48 ns | 0.885 ns | 0.785 ns |  77.43 ns |      32 B |
|          Bebop |  47.76 ns | 1.005 ns | 1.594 ns |  46.91 ns |     120 B |

####  Simple POCOs

This benchmark serializes a 'Simple' object. The purpose is to see the raw speed of a single serialization on a simple object.

|         Method |       Mean |    Error |   StdDev |     Median | Allocated |
|--------------- |-----------:|---------:|---------:|-----------:|----------:|
| NewtonsoftJson | 1,057.0 ns | 19.01 ns | 16.85 ns | 1,053.9 ns |   1,552 B |
| SystemTextJson |   473.9 ns |  8.18 ns |  7.65 ns |   474.8 ns |     344 B |
|       Protobuf |   122.9 ns |  1.32 ns |  1.24 ns |   122.8 ns |     136 B |
|    MessagePack |   125.5 ns |  1.86 ns |  1.74 ns |   125.7 ns |      72 B |
|          Bebop |   119.9 ns |  2.44 ns |  4.52 ns |   122.0 ns |     360 B |

#### Complex POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 6,188.1 ns | 27.44 ns | 25.67 ns |   5,312 B |
| SystemTextJson | 2,949.0 ns | 13.95 ns | 13.05 ns |   1,720 B |
|       Protobuf |   957.3 ns |  6.67 ns |  5.91 ns |     400 B |
|    MessagePack |   623.3 ns |  4.00 ns |  3.74 ns |     304 B |
|          Bebop |   350.2 ns |  2.27 ns |  2.13 ns |   1,264 B |

### Serialize POCOs Multiple Times

This benchmark runs a loop to serializes an object a total of 10 times. The purpose is to see if performance gets better/worse after serializing the same object multiple times.

#### Simple POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 10.527 μs | 0.0760 μs | 0.0711 μs |  15,520 B |
| SystemTextJson |  4.561 μs | 0.0308 μs | 0.0273 μs |   3,440 B |
|       Protobuf |  1.067 μs | 0.0058 μs | 0.0054 μs |   1,360 B |
|    MessagePack |  1.303 μs | 0.0096 μs | 0.0090 μs |     720 B |
|          Bebop |  1.071 μs | 0.0065 μs | 0.0061 μs |   3,600 B |

####  Tiny POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 7,441.3 ns | 52.01 ns | 48.65 ns |  14,160 B |
| SystemTextJson | 2,988.6 ns | 56.54 ns | 52.88 ns |   2,320 B |
|       Protobuf |   519.5 ns |  6.92 ns |  6.14 ns |     960 B |
|    MessagePack |   731.3 ns |  9.63 ns |  8.53 ns |     320 B |
|          Bebop |   438.1 ns |  2.63 ns |  2.46 ns |   1,200 B |

#### Complex POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 62.118 μs | 0.2504 μs | 0.2343 μs |     52 KB |
| SystemTextJson | 29.649 μs | 0.1574 μs | 0.1396 μs |     17 KB |
|       Protobuf | 10.013 μs | 0.1449 μs | 0.1355 μs |      4 KB |
|    MessagePack |  6.113 μs | 0.0363 μs | 0.0322 μs |      3 KB |
|          Bebop |  5.702 μs | 0.0196 μs | 0.0183 μs |     12 KB |

### Deserialize POCOs Once

This is the most basic deserialization benchmark. It only measures the performance of the deserialization. The purpose is to see the raw speed of a single deserialization of the object.

#### Tiny POCOs

|         Method |        Mean |    Error |   StdDev | Allocated |
|--------------- |------------:|---------:|---------:|----------:|
| NewtonsoftJson | 1,288.09 ns | 8.785 ns | 7.787 ns |   2,656 B |
| SystemTextJson |   412.64 ns | 3.799 ns | 3.553 ns |      24 B |
|       Protobuf |    98.20 ns | 0.584 ns | 0.546 ns |     200 B |
|    MessagePack |    69.49 ns | 0.339 ns | 0.317 ns |      24 B |
|          Bebop |    20.21 ns | 0.213 ns | 0.178 ns |      32 B |

#### Simple POCOs

|         Method |        Mean |     Error |   StdDev | Allocated |
|--------------- |------------:|----------:|---------:|----------:|
| NewtonsoftJson | 2,300.75 ns | 10.700 ns | 8.935 ns |   2,832 B |
| SystemTextJson |   692.76 ns |  9.477 ns | 8.865 ns |     128 B |
|       Protobuf |   161.09 ns |  1.235 ns | 1.156 ns |     304 B |
|    MessagePack |   171.56 ns |  1.516 ns | 1.418 ns |     128 B |
|          Bebop |    60.19 ns |  0.265 ns | 0.221 ns |     136 B |

#### Complex POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 2,207.5 ns | 12.74 ns | 11.92 ns |   2,864 B |
| SystemTextJson |   722.3 ns |  6.40 ns |  5.99 ns |     160 B |
|       Protobuf | 1,133.6 ns |  9.46 ns |  8.39 ns |   1,288 B |
|    MessagePack | 1,645.4 ns | 14.98 ns | 11.70 ns |     552 B |
|          Bebop |   236.6 ns |  3.47 ns |  3.25 ns |     592 B |

### Deserialize POCOs Multiple Times

This benchmark runs a loop to deserialize an object a total of 10 times. The purpose is to see if performance gets better/worse after deserializing the same object multiple times.

#### Tiny POCOs

|         Method |        Mean |     Error |   StdDev | Allocated |
|--------------- |------------:|----------:|---------:|----------:|
| NewtonsoftJson | 12,834.0 ns | 106.98 ns | 94.84 ns |  26,560 B |
| SystemTextJson |  4,052.5 ns |  39.99 ns | 37.40 ns |     240 B |
|       Protobuf |    972.4 ns |   5.11 ns |  4.78 ns |   2,000 B |
|    MessagePack |    766.2 ns |   5.23 ns |  4.90 ns |     240 B |
|          Bebop |    208.9 ns |   0.98 ns |  0.91 ns |     320 B |

#### Simple POCOs

|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 22,988.9 ns | 265.97 ns | 248.78 ns |     28 KB |
| SystemTextJson |  7,159.8 ns |  55.78 ns |  52.18 ns |      1 KB |
|       Protobuf |  1,663.4 ns |  13.36 ns |  12.50 ns |      3 KB |
|    MessagePack |  1,587.0 ns |  19.51 ns |  18.25 ns |      1 KB |
|          Bebop |    619.4 ns |   3.60 ns |   3.37 ns |      1 KB |

#### Complex POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 21.603 μs | 0.1334 μs | 0.1248 μs |     28 KB |
| SystemTextJson |  7.205 μs | 0.0819 μs | 0.0766 μs |      2 KB |
|       Protobuf | 10.802 μs | 0.0709 μs | 0.0629 μs |     13 KB |
|    MessagePack | 17.979 μs | 0.1079 μs | 0.1010 μs |      5 KB |
|          Bebop |  2.412 μs | 0.0114 μs | 0.0101 μs |      6 KB |

### Create then Serialize

This benchmark creates a new instance of an object and then serializes it. The purpose is to see how much memory is used in a more macro sense of creating the object and serializing it.

#### Tiny POCOs

|         Method |      Mean |     Error |   StdDev | Allocated |
|--------------- |----------:|----------:|---------:|----------:|
| NewtonsoftJson | 752.72 ns | 10.555 ns | 9.873 ns |   1,440 B |
| SystemTextJson | 330.58 ns |  4.845 ns | 4.532 ns |     256 B |
|       Protobuf |  68.42 ns |  1.368 ns | 1.918 ns |     128 B |
|    MessagePack |  83.37 ns |  0.651 ns | 0.577 ns |      56 B |
|          Bebop |  49.11 ns |  0.265 ns | 0.235 ns |     152 B |

#### Simple POCOs

|         Method |       Mean |   Error |  StdDev | Allocated |
|--------------- |-----------:|--------:|--------:|----------:|
| NewtonsoftJson | 1,054.1 ns | 6.99 ns | 6.53 ns |   1,592 B |
| SystemTextJson |   500.1 ns | 4.61 ns | 4.31 ns |     384 B |
|       Protobuf |   127.7 ns | 0.77 ns | 0.72 ns |     184 B |
|    MessagePack |   147.2 ns | 2.62 ns | 2.45 ns |     112 B |
|          Bebop |   123.5 ns | 0.65 ns | 0.61 ns |     408 B |

#### Complex POCOs

|         Method |     Mean |     Error |    StdDev | Allocated |
|--------------- |---------:|----------:|----------:|----------:|
| NewtonsoftJson | 7.110 μs | 0.0218 μs | 0.0194 μs |   5,664 B |
| SystemTextJson | 3.801 μs | 0.0081 μs | 0.0076 μs |   2,072 B |
|       Protobuf | 2.187 μs | 0.0150 μs | 0.0125 μs |   1,309 B |
|    MessagePack | 1.348 μs | 0.0034 μs | 0.0032 μs |     656 B |
|          Bebop | 1.055 μs | 0.0060 μs | 0.0053 μs |   1,648 B |

### Create then Serialize then Deserialize

This benchmark creates a new instance of an object, serializes it, then deserializes it. The purpose is to see how much memory is used in a more macro sense of the full lifespan of the process.

#### Tiny POCOs

|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 2,223.19 ns | 18.547 ns | 17.349 ns |   4,096 B |
| SystemTextJson |   825.31 ns |  9.528 ns |  8.913 ns |     280 B |
|       Protobuf |   170.23 ns |  2.781 ns |  2.601 ns |     328 B |
|    MessagePack |   160.39 ns |  1.251 ns |  1.170 ns |      80 B |
|          Bebop |    69.95 ns |  0.801 ns |  0.669 ns |     184 B |

#### Simple POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 3,622.7 ns | 23.44 ns | 21.93 ns |   4,424 B |
| SystemTextJson | 1,346.2 ns | 15.72 ns | 14.71 ns |     512 B |
|       Protobuf |   309.0 ns |  3.96 ns |  3.70 ns |     488 B |
|    MessagePack |   351.4 ns |  4.17 ns |  3.90 ns |     240 B |
|          Bebop |   196.4 ns |  1.01 ns |  0.90 ns |     544 B |

#### Complex POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 19.805 μs | 0.1083 μs | 0.1013 μs |     10 KB |
| SystemTextJson |  8.831 μs | 0.0387 μs | 0.0362 μs |      3 KB |
|       Protobuf |  3.452 μs | 0.0174 μs | 0.0163 μs |      3 KB |
|    MessagePack |  3.410 μs | 0.0078 μs | 0.0073 μs |      1 KB |
|          Bebop |  1.340 μs | 0.0050 μs | 0.0047 μs |      2 KB |


