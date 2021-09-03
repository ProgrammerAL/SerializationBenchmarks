
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

All of the benchmark results are below, but here's a summary of how each serialization protocol performed. Remember, there are tradeoffs to every approach.

- JSON
  - We test with both the NewtonSoft.JSON and System.Text.JSON libraries
  - The slowest to serialize and deserialize. Always generates the largest message size.
  - But remember, it's not meant to be the most performant. It's not a binary serialization. It is human readable, which is its biggest strength.
  - JSON is included in this benchmark mostly for comparison.
- Protobuf
  - When serializing, this is very close to being the fastest and can make the smallest serialized entity size. However, as the backing entity class gets bigger, the serialized output becomes larger than the others.
  - When deserializing, it becomes the slowest of the binary serializers, and allocates the most amount of memory which can slow down the system over time with GC pauses.
- MessagePack
  - The most well rounded of the protocols.
  - A very close 3rd in serialization performance, a clear 2nd in deserialization performance.
  - Allocates the least amount of memory when serializing and deserializing.
  - Similar to Protobuf, MessagePack's serialized messages are very small when the entity class is small, but grow much larger as the entity gets bigger. However it's not nearly as bad as Protobuf.
- Bebop
  - We test with both Message and Struct entity types.
  - The fastest in every benchmark, serialization and deserialization.
  - Serializing allocates a lot of memory, but deserialization does not have this problem.
  - Struct entity types generate messages almost as small as Protobuf and MessagePack. As the entity types grow larger, both Struct and Message do not grow as large as Protobuf or MessagePack.


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
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 27           |
| Protobuf      | 6            |
| MessagePack   | 7            |
| Bebop Message | 15           |
| Bebop Struct  | 8            |

Simple Objects Serialized Size:
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 83           |
| Protobuf      | 42           |
| MessagePack   | 42           |
| Bebop Message | 57           |
| Bebop Struct  | 48           |

Complex Objects Serialized Size:
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 83           |
| Protobuf      | 306          |
| MessagePack   | 279          |
| Bebop Message | 243          |
| Bebop Struct  | 201          |

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
| NewtonsoftJson | 2,178.36 ns | 10.585 ns | 9.901 ns |   2,832 B |
| SystemTextJson |   717.57 ns |  9.333 ns | 8.730 ns |     128 B |
|       Protobuf |   161.01 ns |  0.320 ns | 0.284 ns |     304 B |
|    MessagePack |   158.03 ns |  2.187 ns | 2.046 ns |     128 B |
|   BebopMessage |    52.00 ns |  0.622 ns | 0.582 ns |     136 B |
|    BebopStruct |    44.70 ns |  0.308 ns | 0.288 ns |     128 B |

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

|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 13,193.5 ns | 114.12 ns | 106.74 ns |  26,560 B |
| SystemTextJson |  4,190.2 ns |  31.48 ns |  29.44 ns |     240 B |
|       Protobuf |    972.8 ns |  11.49 ns |  10.18 ns |   2,000 B |
|    MessagePack |    665.9 ns |   4.53 ns |   4.23 ns |     240 B |
|   BebopMessage |    212.8 ns |   0.66 ns |   0.58 ns |     320 B |
|    BebopStruct |    140.5 ns |   1.34 ns |   1.19 ns |     240 B |

#### Simple POCOs

|         Method |        Mean |     Error |    StdDev | Allocated |
|--------------- |------------:|----------:|----------:|----------:|
| NewtonsoftJson | 23,573.7 ns | 165.24 ns | 154.57 ns |     28 KB |
| SystemTextJson |  7,282.4 ns |  77.27 ns |  72.28 ns |      1 KB |
|       Protobuf |  1,692.2 ns |   8.19 ns |   6.84 ns |      3 KB |
|    MessagePack |  1,688.1 ns |  13.23 ns |  11.73 ns |      1 KB |
|   BebopMessage |    550.4 ns |   7.98 ns |   7.47 ns |      1 KB |
|    BebopStruct |    499.4 ns |   1.23 ns |   1.09 ns |      1 KB |

#### Complex POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 23.995 μs | 0.1236 μs | 0.1156 μs |     28 KB |
| SystemTextJson |  7.358 μs | 0.0568 μs | 0.0531 μs |      2 KB |
|       Protobuf | 12.314 μs | 0.0165 μs | 0.0128 μs |     13 KB |
|    MessagePack | 18.259 μs | 0.1002 μs | 0.0937 μs |      5 KB |
|   BebopMessage |  2.680 μs | 0.0162 μs | 0.0135 μs |      6 KB |
|    BebopStruct |  2.079 μs | 0.0106 μs | 0.0099 μs |      5 KB |

### Create then Serialize

This benchmark creates a new instance of an object and then serializes it. The purpose is to see how much memory is used in a more macro sense of creating the object and serializing it.

#### Tiny POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 784.24 ns | 11.841 ns | 11.076 ns |   1,440 B |
| SystemTextJson | 331.39 ns |  2.288 ns |  2.140 ns |     256 B |
|       Protobuf |  64.91 ns |  0.655 ns |  0.613 ns |     128 B |
|    MessagePack |  84.20 ns |  0.429 ns |  0.380 ns |      56 B |
|   BebopMessage |  52.56 ns |  0.134 ns |  0.119 ns |     152 B |
|    BebopStruct |  33.07 ns |  0.244 ns |  0.229 ns |      88 B |

#### Simple POCOs

|         Method |        Mean |    Error |   StdDev | Allocated |
|--------------- |------------:|---------:|---------:|----------:|
| NewtonsoftJson | 1,092.42 ns | 4.824 ns | 4.512 ns |   1,592 B |
| SystemTextJson |   477.77 ns | 2.714 ns | 2.539 ns |     384 B |
|       Protobuf |   122.48 ns | 0.966 ns | 0.903 ns |     184 B |
|    MessagePack |   149.58 ns | 0.592 ns | 0.525 ns |     112 B |
|   BebopMessage |   118.53 ns | 0.348 ns | 0.326 ns |     408 B |
|    BebopStruct |    91.59 ns | 0.525 ns | 0.491 ns |     304 B |

#### Complex POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 7,525.3 ns | 41.99 ns | 37.23 ns |   5,664 B |
| SystemTextJson | 3,898.3 ns | 20.94 ns | 19.59 ns |   2,072 B |
|       Protobuf | 2,260.7 ns |  8.78 ns |  7.78 ns |   1,308 B |
|    MessagePack | 1,356.5 ns |  5.04 ns |  4.47 ns |     656 B |
|   Bebopmessage | 1,131.7 ns |  7.64 ns |  7.15 ns |   1,648 B |
|    BebopStruct |   951.5 ns |  6.91 ns |  6.46 ns |   1,328 B |


### Create then Serialize then Deserialize

This benchmark creates a new instance of an object, serializes it, then deserializes it. The purpose is to see how much memory is used in a more macro sense of the full lifespan of the process.

#### Tiny POCOs

|         Method |        Mean |    Error |   StdDev | Allocated |
|--------------- |------------:|---------:|---------:|----------:|
| NewtonsoftJson | 2,322.73 ns | 7.618 ns | 6.753 ns |   4,096 B |
| SystemTextJson |   841.82 ns | 7.382 ns | 6.905 ns |     280 B |
|       Protobuf |   173.78 ns | 0.956 ns | 0.894 ns |     328 B |
|    MessagePack |   170.39 ns | 1.407 ns | 1.316 ns |      80 B |
|   BebopMessage |    72.26 ns | 0.264 ns | 0.234 ns |     184 B |
|    BebopStruct |    43.09 ns | 0.103 ns | 0.096 ns |     112 B |

#### Simple POCOs

|         Method |       Mean |    Error |   StdDev | Allocated |
|--------------- |-----------:|---------:|---------:|----------:|
| NewtonsoftJson | 3,725.8 ns | 21.95 ns | 20.53 ns |   4,424 B |
| SystemTextJson | 1,352.1 ns |  6.53 ns |  6.11 ns |     512 B |
|       Protobuf |   321.5 ns |  1.74 ns |  1.55 ns |     488 B |
|    MessagePack |   353.0 ns |  2.73 ns |  2.55 ns |     240 B |
|   BebopMessage |   192.4 ns |  0.93 ns |  0.83 ns |     544 B |
|    BebopStruct |   153.2 ns |  0.62 ns |  0.58 ns |     432 B |

#### Complex POCOs

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| NewtonsoftJson | 20.844 μs | 0.0969 μs | 0.0906 μs |     10 KB |
| SystemTextJson |  9.047 μs | 0.0591 μs | 0.0552 μs |      3 KB |
|       Protobuf |  3.615 μs | 0.0102 μs | 0.0096 μs |      3 KB |
|    MessagePack |  3.454 μs | 0.0157 μs | 0.0147 μs |      1 KB |
|   BebopMessage |  1.454 μs | 0.0044 μs | 0.0039 μs |      2 KB |
|    BebopStruct |  1.338 μs | 0.0049 μs | 0.0044 μs |      2 KB |



