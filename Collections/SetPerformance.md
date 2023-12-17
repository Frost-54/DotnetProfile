C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|      Method |                  set |  next |     Mean |     Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **3.621 ns** | **0.0113 ns** | **0.0105 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **3.617 ns** | **0.0027 ns** | **0.0025 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **3.620 ns** | **0.0113 ns** | **0.0105 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **3.620 ns** | **0.0102 ns** | **0.0096 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 3.615 ns | 0.0014 ns | 0.0011 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **3.625 ns** | **0.0116 ns** | **0.0109 ns** |         **-** |
