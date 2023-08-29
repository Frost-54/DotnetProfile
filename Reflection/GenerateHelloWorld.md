C# dynamic code generation using DynamicAssembly vs DynamicMethod
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |         Mean |        Error |       StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------------------- |-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
| DynamicAssemblyHelloWorld | 424,641.8 ns | 14,704.48 ns | 42,893.67 ns | 6.3477 | 6.3477 | 6.3477 |    5370 B |
|   DynamicMethodHelloWorld |     427.3 ns |      2.76 ns |      2.45 ns | 0.0353 |      - |      - |     888 B |
| MetadataBuilderHelloWorld |           NA |           NA |           NA |      - |      - |      - |         - |

Benchmarks with issues:
  GenerateHelloWorld.MetadataBuilderHelloWorld: DefaultJob
