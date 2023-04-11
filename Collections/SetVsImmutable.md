C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                  Method |                  set |  next |       Mean |      Error |    StdDev |   Gen0 | Allocated |
|------------------------ |--------------------- |------ |-----------:|-----------:|----------:|-------:|----------:|
|          **SetPerformance** | **Syste(...)nt32] [50]** |     **0** |   **5.572 ns** |  **0.0007 ns** | **0.0006 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |    **10** |   **5.571 ns** |  **0.0014 ns** | **0.0012 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |   **100** |   **5.573 ns** |  **0.0013 ns** | **0.0011 ns** |      **-** |         **-** |
|          **SetPerformance** | **Syste(...)nt32] [50]** |  **1000** |   **5.573 ns** |  **0.0007 ns** | **0.0006 ns** |      **-** |         **-** |
|          SetPerformance | Syste(...)nt32] [50] |  1000 |   7.856 ns |  0.0014 ns | 0.0012 ns |      - |         - |
|          **SetPerformance** | **Syste(...)nt32] [50]** | **10000** |   **5.572 ns** |  **0.0010 ns** | **0.0009 ns** |      **-** |         **-** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |     **0** |  **80.368 ns** |  **1.1415 ns** | **1.0119 ns** | **0.0055** |     **104 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |    **10** | **297.316 ns** |  **3.9288 ns** | **3.6750 ns** | **0.0172** |     **328 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |   **100** | **453.350 ns** |  **5.2413 ns** | **4.6463 ns** | **0.0262** |     **496 B** |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** |  **1000** | **643.536 ns** |  **9.4016 ns** | **8.7942 ns** | **0.0353** |     **664 B** |
| ImmutableSetPerformance | Syste(...)nt32] [61] |  1000 | 638.149 ns |  5.6911 ns | 5.0451 ns | 0.0353 |     664 B |
| **ImmutableSetPerformance** | **Syste(...)nt32] [61]** | **10000** | **968.720 ns** | **10.7538 ns** | **8.9799 ns** | **0.0458** |     **888 B** |
