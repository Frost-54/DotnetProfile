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
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |  **78.22 ns** | **0.159 ns** | **0.149 ns** | **0.0011** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** | **299.26 ns** | **0.644 ns** | **0.571 ns** | **0.0038** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** | **452.25 ns** | **1.898 ns** | **1.775 ns** | **0.0057** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** | **606.85 ns** | **1.627 ns** | **1.442 ns** | **0.0076** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 | 629.84 ns | 1.055 ns | 0.935 ns | 0.0076 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **839.87 ns** | **1.997 ns** | **1.868 ns** | **0.0105** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
