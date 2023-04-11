C# immutable dictionary vs dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                         Method |           dictionary |  next |        Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------- |--------------------- |------ |------------:|----------:|----------:|-------:|----------:|
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |     **0** |          **NA** |        **NA** |        **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |    **10** |          **NA** |        **NA** |        **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |   **100** |          **NA** |        **NA** |        **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |  **1000** |          **NA** |        **NA** |        **NA** |      **-** |         **-** |
|          DictionaryPerformance | Syste(...)nt32] [66] |  1000 |          NA |        NA |        NA |      - |         - |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** | **10000** |          **NA** |        **NA** |        **NA** |      **-** |         **-** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |    **99.63 ns** |  **0.959 ns** |  **0.897 ns** | **0.0051** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** |   **371.44 ns** |  **6.016 ns** |  **5.627 ns** | **0.0167** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** |   **554.45 ns** |  **5.483 ns** |  **5.129 ns** | **0.0257** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** |   **792.15 ns** |  **6.286 ns** |  **5.880 ns** | **0.0343** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 |   764.35 ns | 13.149 ns | 12.300 ns | 0.0343 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **1,160.48 ns** | **11.431 ns** | **10.693 ns** | **0.0458** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
