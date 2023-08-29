C# dynamic code generation using DynamicAssembly vs DynamicMethod
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |           Mean |         Error |          StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------------------- |---------------:|--------------:|----------------:|-------:|-------:|-------:|----------:|
| DynamicAssemblyHelloWorld |   411,555.4 ns |  12,881.87 ns |    37,372.63 ns | 3.4180 | 3.4180 | 3.4180 |    5558 B |
|   DynamicMethodHelloWorld |       416.4 ns |       3.30 ns |         3.09 ns | 0.0353 |      - |      - |     888 B |
| MetadataBuilderHelloWorld | 2,479,467.7 ns | 367,133.46 ns | 1,029,481.59 ns | 2.4414 | 0.4883 |      - |   70056 B |
