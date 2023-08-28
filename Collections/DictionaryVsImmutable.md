C# immutable dictionary vs dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                         Method |           dictionary |  next |        Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------------- |--------------------- |------ |------------:|---------:|---------:|-------:|----------:|
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |     **0** |          **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |    **10** |          **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |   **100** |          **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |  **1000** |          **NA** |       **NA** |       **NA** |      **-** |         **-** |
|          DictionaryPerformance | Syste(...)nt32] [66] |  1000 |          NA |       NA |       NA |      - |         - |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** | **10000** |          **NA** |       **NA** |       **NA** |      **-** |         **-** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |    **99.18 ns** | **0.691 ns** | **0.647 ns** | **0.0038** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** |   **354.62 ns** | **1.399 ns** | **1.308 ns** | **0.0124** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** |   **528.48 ns** | **1.745 ns** | **1.547 ns** | **0.0191** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** |   **733.27 ns** | **3.651 ns** | **3.416 ns** | **0.0257** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 |   721.34 ns | 4.583 ns | 4.287 ns | 0.0257 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **1,035.84 ns** | **5.355 ns** | **5.009 ns** | **0.0343** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
