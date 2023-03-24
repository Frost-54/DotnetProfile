C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|      Method |                  set |  next |     Mean |      Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|-----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **6.595 ns** |  **0.4803 ns** | **0.0263 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **6.660 ns** |  **0.7306 ns** | **0.0400 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **7.029 ns** | **10.5735 ns** | **0.5796 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **6.963 ns** |  **8.6613 ns** | **0.4748 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 6.765 ns |  6.0402 ns | 0.3311 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **6.660 ns** |  **0.3615 ns** | **0.0198 ns** |         **-** |
