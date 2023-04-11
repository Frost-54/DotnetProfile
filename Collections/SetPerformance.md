C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|      Method |                  set |  next |     Mean |     Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **5.578 ns** | **0.0096 ns** | **0.0085 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **5.577 ns** | **0.0013 ns** | **0.0011 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **5.573 ns** | **0.0010 ns** | **0.0009 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **5.573 ns** | **0.0009 ns** | **0.0008 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 5.572 ns | 0.0015 ns | 0.0012 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **5.571 ns** | **0.0009 ns** | **0.0008 ns** |         **-** |
