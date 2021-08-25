
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

### Benchmarks project

This project uses Benchmark.NET to run micro benchmarks on different serialization libraries. 

### Info project

This console project will output information about serialization formats that are useful to know, but are not part of a benchmark. For example, it will output the size of serialized objects. This is helpful to know because smaller objects travel over the wire faster.


## Benchmark Results

The below benchmarks were run on August 24, 2021 with the latest version of each.

### Hardware
These were generated from a desktop with the following characteristics:
``` ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.22000
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
```

#### Types of Tests

- 'Tiny' Objects are objects with 2 integer properties
- 'Simple' Objects are obejcts with a handful of different properties (integer, string, enum)

#### Serialize Once Tiny Pocos

This benchmark serializes a 'Tiny' object. The purpose is to see the raw speed of a single serialization on a very small object.

|                    Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------:|---------:|---------:|-------:|------:|------:|----------:|
| Serialize_Json_Newtonsoft | 727.41 ns | 9.262 ns | 8.664 ns | 0.1688 |     - |     - |   1,416 B |
| Serialize_Json_SystemText | 313.80 ns | 6.097 ns | 5.703 ns | 0.0277 |     - |     - |     232 B |
|        Serialize_Protobuf |  55.73 ns | 1.059 ns | 0.990 ns | 0.0114 |     - |     - |      96 B |
|     Serialize_MessagePack |  77.34 ns | 1.527 ns | 1.931 ns | 0.0038 |     - |     - |      32 B |
|           Serialize_Bebop |  45.13 ns | 0.467 ns | 0.414 ns | 0.0143 |     - |     - |     120 B |

####  Serialize Once Simple Pocos

This benchmark serializes a 'Simple' object. The purpose is to see the raw speed of a single serialization on a simple object.

|                    Method |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
| Serialize_Json_Newtonsoft | 909.50 ns | 10.969 ns | 10.260 ns | 0.1783 |     - |     - |   1,496 B |
| Serialize_Json_SystemText | 421.90 ns |  6.509 ns |  6.089 ns | 0.0372 |     - |     - |     312 B |
|        Serialize_Protobuf |  97.40 ns |  1.118 ns |  1.046 ns | 0.0153 |     - |     - |     128 B |
|     Serialize_MessagePack | 124.25 ns |  1.425 ns |  1.190 ns | 0.0086 |     - |     - |      72 B |
|           Serialize_Bebop |  92.63 ns |  1.488 ns |  1.319 ns | 0.0334 |     - |     - |     280 B |

#### Serialize Multiple Simple Pocos

This benchmark runs a loop to serializes a 'Simple' object. This runs 10 times. The purpose is to see if performance gets better/worse after serializing the same object multiple times.

|                    Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
| Serialize_Json_Newtonsoft | 9,191.5 ns | 145.55 ns | 136.14 ns | 1.7853 |     - |     - |  14,960 B |
| Serialize_Json_SystemText | 4,319.2 ns |  73.56 ns |  68.80 ns | 0.3662 |     - |     - |   3,120 B |
|        Serialize_Protobuf |   902.1 ns |  15.50 ns |  14.50 ns | 0.1526 |     - |     - |   1,280 B |
|     Serialize_MessagePack | 1,221.7 ns |  17.21 ns |  16.10 ns | 0.0858 |     - |     - |     720 B |
|           Serialize_Bebop |   951.4 ns |  12.42 ns |  11.62 ns | 0.3347 |     - |     - |   2,800 B |

####  Serialize Multiple Tiny Pocos
This benchmark runs a loop to serializes a 'Tiny' object. This runs 10 times. The purpose is to see if performance gets better/worse after serializing the same object multiple times.

|                    Method |       Mean |    Error |   StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|-------------------------- |-----------:|---------:|---------:|-------:|-------:|------:|----------:|
| Serialize_Json_Newtonsoft | 7,534.5 ns | 68.64 ns | 64.21 ns | 1.6861 | 0.0076 |     - |  14,160 B |
| Serialize_Json_SystemText | 2,921.1 ns | 45.15 ns | 42.24 ns | 0.2747 |      - |     - |   2,320 B |
|        Serialize_Protobuf |   539.0 ns |  9.36 ns |  8.76 ns | 0.1144 |      - |     - |     960 B |
|     Serialize_MessagePack |   751.6 ns | 12.96 ns | 12.12 ns | 0.0381 |      - |     - |     320 B |
|           Serialize_Bebop |   430.2 ns |  3.37 ns |  3.15 ns | 0.1431 |      - |     - |   1,200 B |

#### Create and Serialize Tiny Pocos

This benchmark creates a new instance of a 'Tiny' object and serializes it. The purpose is to see how much memory is used in a more macro sense of creating the object and serializing it.

|                    Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------:|---------:|---------:|-------:|------:|------:|----------:|
| Serialize_Json_Newtonsoft | 745.91 ns | 8.002 ns | 7.485 ns | 0.1717 |     - |     - |   1,440 B |
| Serialize_Json_SystemText | 309.44 ns | 4.564 ns | 4.269 ns | 0.0305 |     - |     - |     256 B |
|        Serialize_Protobuf |  62.22 ns | 0.943 ns | 0.882 ns | 0.0153 |     - |     - |     128 B |
|     Serialize_MessagePack |  81.55 ns | 1.206 ns | 1.129 ns | 0.0067 |     - |     - |      56 B |
|           Serialize_Bebop |  48.56 ns | 0.255 ns | 0.238 ns | 0.0181 |     - |     - |     152 B |


#### Create and Serialize Simple Pocos

This benchmark creates a new instance of a 'Simple' object and serializes it. The purpose is to see how much memory is used in a more macro sense of creating the object and serializing it.

|                    Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
| Serialize_Json_Newtonsoft | 912.7 ns | 10.00 ns |  8.87 ns | 0.1822 |     - |     - |   1,528 B |
| Serialize_Json_SystemText | 434.5 ns |  8.42 ns | 10.35 ns | 0.0410 |     - |     - |     344 B |
|        Serialize_Protobuf | 107.9 ns |  0.64 ns |  0.53 ns | 0.0200 |     - |     - |     168 B |
|     Serialize_MessagePack | 138.6 ns |  1.05 ns |  0.88 ns | 0.0124 |     - |     - |     104 B |
|           Serialize_Bebop | 103.2 ns |  1.18 ns |  1.10 ns | 0.0381 |     - |     - |     320 B |

## Overview of Serialization Formats

### JSON

JSON is the default serialization protocol used in so many applications. Many of us assume we will serialize to JSON unless we have a good reason to not use it. It will never be the fastest serialization protocol because it is human readable, and thus it's not as compact as the binary protocols on our list. But because it is the default protocol used by many, I wanted it on this list for comparison sake.

### Protobuf

Protobuf is a binary serialization format created and maintained by Google. It is also the serialization format used by GRPC. I personally consider it the default binary format to use when given the choice because it is fast to serialize/deserialize, is consistently maintained by Google, and the byte buffer it generates is small. As you can see from the benchmarks above, it has the best performance-to-size ratio. It's not always the fastest, but it is very fast and usually generates the smallest message. You can read more from Google at https://developers.google.com/protocol-buffers/.

### MessagePack

Most .NET developers will be familiar with using MessagePack with SignalR. While it's not enabled by default (JSON is the default), there is support out of the box for enabled MessagePack for all messages with SignalR. Of the 3 binary serialization protocols we benchmark, this is the slowest. But the message size is a very close second place, and it is always the clear winner in GC Allocated memory. You can read more about MessagePack at the official website https://msgpack.org/, or the repo for the library used in .NET here https://github.com/neuecc/MessagePack-CSharp.

### Bebop

The newest protocol on this list. It was created by Rainway, the Video Game streaming company. It's goal is to be the fastest serialization protocol. As you can see from the benchmarks above, it is easily the fastest. However of the 3 binary protocols we are benchmarking, its message size is the largest and it allocates the most amount of memory. You can read more about it on their repo at https://github.com/RainwayApp/bebop.

