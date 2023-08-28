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
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **4.768 ns** | **0.0077 ns** | **0.0068 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **4.705 ns** | **0.0268 ns** | **0.0224 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **4.693 ns** | **0.0183 ns** | **0.0153 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **4.509 ns** | **0.0459 ns** | **0.0358 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 4.743 ns | 0.1318 ns | 0.1465 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **4.793 ns** | **0.0500 ns** | **0.0468 ns** |         **-** |
