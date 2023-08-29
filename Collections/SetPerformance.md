C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|      Method |                  set |  next |     Mean |     Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **5.825 ns** | **0.0029 ns** | **0.0026 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **4.778 ns** | **0.1336 ns** | **0.1250 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **4.721 ns** | **0.0223 ns** | **0.0197 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **4.823 ns** | **0.0364 ns** | **0.0322 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 4.807 ns | 0.0853 ns | 0.0798 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **4.738 ns** | **0.0668 ns** | **0.0592 ns** |         **-** |
