C# dynamic code generation using DynamicAssembly vs DynamicMethod
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                    Method |         Mean |       Error |      StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------------------- |-------------:|------------:|------------:|-------:|-------:|-------:|----------:|
| DynamicAssemblyHelloWorld | 334,730.9 ns | 5,631.02 ns | 6,484.69 ns | 1.9531 | 1.9531 | 1.9531 |    5304 B |
|   DynamicMethodHelloWorld |     317.3 ns |     2.06 ns |     1.92 ns | 0.0105 |      - |      - |     888 B |
| MetadataBuilderHelloWorld |           NA |          NA |          NA |      - |      - |      - |         - |

Benchmarks with issues:
  GenerateHelloWorld.MetadataBuilderHelloWorld: DefaultJob
