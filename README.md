# .NET Serialization Benchmarks
The purposes of this repo are to:
1. Provide performance comparisons of serializing/deserializing different formats using .NET libraries.
1. Create a straight forward way for anyone to run their own benchmarks for their own custom testing.

The protocols tested are:
- JSON
- Protobuf
- MessagePack
- Bebop

## Results

All of the benchmark result files are in the [BenchmarkResults](./BenchmarkResults/) folder, but here's a summary of how each serialization protocol performed. Remember, there are tradeoffs to every approach.

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


## Overview of Serialization Formats

### JSON

JSON is the default serialization protocol used in so many applications. Many of us assume we will serialize to JSON unless we have a good reason to not use it. It will never be the fastest serialization protocol because it is human readable, and thus it's not as compact as the binary protocols on our list. But because it is the default protocol used by many, I wanted it on this list for comparison sake.

### Protobuf

Protobuf is a binary serialization format created and maintained by Google. It is also the serialization format used by GRPC. I consider it the default binary format to use when given the choice because it is fast to serialize/deserialize, is consistently maintained by Google, and the byte buffer it generates is small. You can read more from Google at https://developers.google.com/protocol-buffers/.

### MessagePack

Most .NET developers will be familiar with using MessagePack with SignalR. It's not enabled by default in SignalR (JSON is), but there is support out of the box to enable MessagePack. You can read more about MessagePack at the official website https://msgpack.org/, or the repo for the library used in .NET here https://github.com/neuecc/MessagePack-CSharp.

### Bebop

The newest protocol on this list. It was created by Rainway with the goal to be the fastest serialization protocol. As you can see in the benchmarks, it is easily the fastest in every serialization/deserialization test. You can read more about it on their repo at https://github.com/RainwayApp/bebop.

## Benchmarks

### C# Projects Overview

There are 2 *.csproj files that provide information. The first is the 'Benchmarks' project. This uses Benchmark .NET to run micro benchmarks on the different serialization libraries. The second is the 'Info' project. This console project outputs information about serialization formats that are useful to know, but are not part of a benchmark. For example, it will output the size of serialized objects. This is helpful to know because smaller objects travel over the wire faster.

### Types of Objects Serialized/Deserialized

- 'Tiny' objects are objects with 2 integer properties
- 'Simple' objects are obejcts with a handful of different properties (integer, integer, string, enum)
- 'Complex' objects are objects with multiple types of properties and a child collection


### Serialized Object Sizes

Tiny:
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 27           |
| Protobuf      | 6            |
| MessagePack   | 7            |
| Bebop Message | 15           |
| Bebop Struct  | 8            |

Simple:
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 83           |
| Protobuf      | 42           |
| MessagePack   | 42           |
| Bebop Message | 57           |
| Bebop Struct  | 48           |

Complex:
| Name          | Size (bytes) |
|---------------|--------------|
| JSON          | 83           |
| Protobuf      | 306          |
| MessagePack   | 279          |
| Bebop Message | 243          |
| Bebop Struct  | 201          |

### Types of Benchmarks

The below benchmarks are run for each of the different object sizes. See the [BenchmarkResults](./BenchmarkResults/) folder for individual results.

#### Serialize POCOs Once

This is the most basic serialization benchmark. It only measures the performance of the serialization. The purpose is to see the raw speed of a single serialization of the object.

#### Serialize POCOs Multiple Times

This benchmark runs a loop to serializes an object a total of 10 times. The purpose is to see if performance gets better/worse after serializing the same object multiple times.

#### Deserialize POCOs Once

This is the most basic deserialization benchmark. It only measures the performance of the deserialization. The purpose is to see the raw speed of a single deserialization of the object.

#### Deserialize POCOs Multiple Times

This benchmark runs a loop to deserialize an object a total of 10 times. The purpose is to see if performance gets better/worse after deserializing the same object multiple times.

#### Create then Serialize

This benchmark creates a new instance of an object and then serializes it. The purpose is to see how much memory is used in a more macro sense of creating the object and serializing it.

#### Create then Serialize then Deserialize

This benchmark creates a new instance of an object, serializes it, then deserializes it. The purpose is to see how much memory is used in a more macro sense of the full lifespan of the process.



