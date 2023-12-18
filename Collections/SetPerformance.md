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
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **3.628 ns** | **0.0125 ns** | **0.0117 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **3.626 ns** | **0.0138 ns** | **0.0129 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **3.622 ns** | **0.0139 ns** | **0.0123 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **3.619 ns** | **0.0040 ns** | **0.0033 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 3.626 ns | 0.0161 ns | 0.0151 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **3.622 ns** | **0.0131 ns** | **0.0116 ns** |         **-** |
