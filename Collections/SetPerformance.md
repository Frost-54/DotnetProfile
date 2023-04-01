C# HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|      Method |                  set |  next |     Mean |     Error |    StdDev | Allocated |
|------------ |--------------------- |------ |---------:|----------:|----------:|----------:|
| **Performance** | **Syste(...)nt32] [50]** |     **0** | **4.559 ns** | **0.0441 ns** | **0.0391 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |    **10** | **4.561 ns** | **0.0080 ns** | **0.0066 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |   **100** | **4.586 ns** | **0.0557 ns** | **0.0493 ns** |         **-** |
| **Performance** | **Syste(...)nt32] [50]** |  **1000** | **4.532 ns** | **0.0231 ns** | **0.0216 ns** |         **-** |
| Performance | Syste(...)nt32] [50] |  1000 | 4.520 ns | 0.0094 ns | 0.0079 ns |         - |
| **Performance** | **Syste(...)nt32] [50]** | **10000** | **4.540 ns** | **0.0445 ns** | **0.0394 ns** |         **-** |
