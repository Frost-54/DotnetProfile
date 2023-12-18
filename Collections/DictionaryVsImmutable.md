C# immutable dictionary vs dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                         Method |           dictionary |  next |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------------- |--------------------- |------ |----------:|---------:|---------:|-------:|----------:|
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |     **0** |        **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |    **10** |        **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |   **100** |        **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |  **1000** |        **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          DictionaryPerformance | Syste(...)nt32] [66] |  1000 |        NA |       NA |       NA |      - |         - |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** | **10000** |        **NA** |       **NA** |       **NA** |      **-** |         **-** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |  **80.17 ns** | **0.193 ns** | **0.171 ns** | **0.0011** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** | **327.69 ns** | **0.947 ns** | **0.839 ns** | **0.0038** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** | **449.88 ns** | **1.194 ns** | **1.117 ns** | **0.0057** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** | **607.19 ns** | **1.582 ns** | **1.480 ns** | **0.0076** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 | 600.65 ns | 2.018 ns | 1.887 ns | 0.0076 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **844.97 ns** | **1.618 ns** | **1.513 ns** | **0.0105** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
