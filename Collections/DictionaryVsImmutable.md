C# immutable dictionary vs dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                         Method |           dictionary |  next |       Mean |   Error |  StdDev |   Gen0 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|-------:|----------:|
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |     **0** |         **NA** |      **NA** |      **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |    **10** |         **NA** |      **NA** |      **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |   **100** |         **NA** |      **NA** |      **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |  **1000** |         **NA** |      **NA** |      **NA** |      **-** |         **-** |
|          DictionaryPerformance | Syste(...)nt32] [66] |  1000 |         NA |      NA |      NA |      - |         - |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** | **10000** |         **NA** |      **NA** |      **NA** |      **-** |         **-** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |   **100.5 ns** | **0.27 ns** | **0.25 ns** | **0.0038** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** |   **369.8 ns** | **0.67 ns** | **0.60 ns** | **0.0124** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** |   **531.6 ns** | **1.27 ns** | **1.13 ns** | **0.0191** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** |   **722.2 ns** | **2.40 ns** | **2.25 ns** | **0.0257** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 |   708.2 ns | 1.85 ns | 1.73 ns | 0.0257 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **1,042.6 ns** | **4.91 ns** | **4.59 ns** | **0.0343** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
