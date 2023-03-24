C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                  Method |                  set |  next |         Mean |       Error |     StdDev |   Gen0 | Allocated |
|------------------------ |--------------------- |------ |-------------:|------------:|-----------:|-------:|----------:|
|          **SetPerformance** | **Syste(...)nt32] [50]** |     **0** |     **6.523 ns** |   **1.5117 ns** |  **0.0829 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |    **10** |     **6.610 ns** |   **2.2613 ns** |  **0.1240 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |   **100** |     **6.612 ns** |   **1.5930 ns** |  **0.0873 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |  **1000** |     **6.583 ns** |   **2.1125 ns** |  **0.1158 ns** |      **-** |         **-** |
|          SetPerformance | Syste(...)nt32] [50] |  1000 |     6.650 ns |   0.2934 ns |  0.0161 ns |      - |         - |
|          **SetPerformance** | **Syste(...)nt32] [50]** | **10000** |     **8.122 ns** |   **0.7808 ns** |  **0.0428 ns** |      **-** |         **-** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |     **0** |   **104.011 ns** |  **10.1879 ns** |  **0.5584 ns** | **0.0055** |     **104 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |    **10** |   **373.223 ns** |  **29.3233 ns** |  **1.6073 ns** | **0.0172** |     **328 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |   **100** |   **581.194 ns** |  **47.1441 ns** |  **2.5841 ns** | **0.0257** |     **496 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |  **1000** |   **897.069 ns** | **316.4446 ns** | **17.3454 ns** | **0.0353** |     **664 B** |
| ImmutableSetPerformance | Syste(...)nt32] [61] |  1000 |   795.800 ns | 119.8355 ns |  6.5686 ns | 0.0353 |     664 B |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** | **10000** | **1,132.139 ns** | **321.2272 ns** | **17.6075 ns** | **0.0458** |     **888 B** |
