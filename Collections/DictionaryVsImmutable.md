C# immutable dictionary vs dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                         Method |           dictionary |  next |       Mean |     Error |   StdDev |   Gen0 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|----------:|---------:|-------:|----------:|
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |     **0** |         **NA** |        **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |    **10** |         **NA** |        **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |   **100** |         **NA** |        **NA** |       **NA** |      **-** |         **-** |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** |  **1000** |         **NA** |        **NA** |       **NA** |      **-** |         **-** |
|          DictionaryPerformance | Syste(...)nt32] [66] |  1000 |         NA |        NA |       NA |      - |         - |
|          **DictionaryPerformance** | **Syste(...)nt32] [66]** | **10000** |         **NA** |        **NA** |       **NA** |      **-** |         **-** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |     **0** |   **122.7 ns** |  **10.77 ns** |  **0.59 ns** | **0.0050** |      **96 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |    **10** |   **457.5 ns** |  **29.34 ns** |  **1.61 ns** | **0.0167** |     **320 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |   **100** |   **719.5 ns** |  **74.85 ns** |  **4.10 ns** | **0.0257** |     **488 B** |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** |  **1000** |   **929.0 ns** |  **84.63 ns** |  **4.64 ns** | **0.0343** |     **656 B** |
| ImmutableDictionaryPerformance | Syste(...)nt32] [77] |  1000 |   919.6 ns | 134.81 ns |  7.39 ns | 0.0343 |     656 B |
| **ImmutableDictionaryPerformance** | **Syste(...)nt32] [77]** | **10000** | **1,469.2 ns** | **592.67 ns** | **32.49 ns** | **0.0458** |     **880 B** |

Benchmarks with issues:
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryVsImmutable.DictionaryPerformance: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [dictionary=Syste(...)nt32] [66], next=10000]
