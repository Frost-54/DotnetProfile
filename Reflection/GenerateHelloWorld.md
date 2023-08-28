C# dynamic code generation using DynamicAssembly vs DynamicMethod vs MetadataBuilder
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |         Mean |        Error |       StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------------------- |-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
| DynamicAssemblyHelloWorld | 429,895.4 ns | 14,172.86 ns | 41,789.01 ns | 2.4414 | 2.4414 | 2.4414 |    5687 B |
|   DynamicMethodHelloWorld |     401.8 ns |      3.64 ns |      3.41 ns | 0.0353 |      - |      - |     888 B |
| MetadataBuilderHelloWorld |           NA |           NA |           NA |      - |      - |      - |         - |

Benchmarks with issues:
  GenerateHelloWorld.MetadataBuilderHelloWorld: DefaultJob
