C# Dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|      Method |           dictionary |  next | Mean | Error |
|------------ |--------------------- |------ |-----:|------:|
| **Performance** | **Syste(...)nt32] [66]** |     **0** |   **NA** |    **NA** |
| **Performance** | **Syste(...)nt32] [66]** |    **10** |   **NA** |    **NA** |
| **Performance** | **Syste(...)nt32] [66]** |   **100** |   **NA** |    **NA** |
| **Performance** | **Syste(...)nt32] [66]** |  **1000** |   **NA** |    **NA** |
| Performance | Syste(...)nt32] [66] |  1000 |   NA |    NA |
| **Performance** | **Syste(...)nt32] [66]** | **10000** |   **NA** |    **NA** |

Benchmarks with issues:
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Performance: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
