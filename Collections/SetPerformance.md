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
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **4.733 ns** | **0.0403 ns** | **0.0357 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **4.859 ns** | **0.0658 ns** | **0.0616 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **4.733 ns** | **0.0311 ns** | **0.0259 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **4.750 ns** | **0.0256 ns** | **0.0214 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 4.679 ns | 0.0718 ns | 0.0672 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **4.731 ns** | **0.0330 ns** | **0.0257 ns** |         **-** |
