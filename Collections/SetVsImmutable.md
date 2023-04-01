C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                  Method |                  set |  next |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------ |--------------------- |------ |-----------:|----------:|----------:|-------:|----------:|
|          **SetPerformance** | **Syste(...)nt32] [50]** |     **0** |   **4.527 ns** | **0.0130 ns** | **0.0109 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |    **10** |   **4.561 ns** | **0.0761 ns** | **0.0674 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |   **100** |   **4.554 ns** | **0.0621 ns** | **0.0581 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |  **1000** |   **4.569 ns** | **0.0718 ns** | **0.0672 ns** |      **-** |         **-** |
|          SetPerformance | Syste(...)nt32] [50] |  1000 |   4.517 ns | 0.0081 ns | 0.0068 ns |      - |         - |
|          **SetPerformance** | **Syste(...)nt32] [50]** | **10000** |   **4.530 ns** | **0.0197 ns** | **0.0154 ns** |      **-** |         **-** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |     **0** |  **75.969 ns** | **0.3575 ns** | **0.3344 ns** | **0.0041** |     **104 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |    **10** | **280.492 ns** | **1.7241 ns** | **1.6128 ns** | **0.0129** |     **328 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |   **100** | **424.540 ns** | **2.9438 ns** | **2.7536 ns** | **0.0196** |     **496 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |  **1000** | **565.425 ns** | **2.2604 ns** | **2.1143 ns** | **0.0257** |     **664 B** |
| ImmutableSetPerformance | Syste(...)nt32] [61] |  1000 | 560.400 ns | 3.7703 ns | 3.5267 ns | 0.0257 |     664 B |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** | **10000** | **801.609 ns** | **5.7047 ns** | **5.3362 ns** | **0.0353** |     **888 B** |
