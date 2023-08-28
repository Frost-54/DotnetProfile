C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|      Method |                  set |  next |     Mean |     Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **5.965 ns** | **0.1613 ns** | **0.1920 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **6.122 ns** | **0.1663 ns** | **0.1980 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **6.084 ns** | **0.1668 ns** | **0.3555 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **6.199 ns** | **0.1648 ns** | **0.2364 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 6.385 ns | 0.1568 ns | 0.2298 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **6.557 ns** | **0.1740 ns** | **0.2071 ns** |         **-** |
