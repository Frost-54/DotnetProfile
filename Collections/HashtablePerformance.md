C# Hashtable performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                 Method |            hashtable |     a |    b |  next | last |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |----- |------ |----- |---------:|---------:|---------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)table [28]** |     **0** |   **-1** |     **?** |    **?** | **22.41 ns** | **0.359 ns** | **0.336 ns** | **0.0013** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |     **0** |   **-1** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 19.67 ns | 0.016 ns | 0.015 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 19.62 ns | 0.013 ns | 0.012 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 15.64 ns | 0.004 ns | 0.004 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 22.16 ns | 0.003 ns | 0.003 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 23.04 ns | 0.013 ns | 0.012 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |    **10** |    **9** |     **?** |    **?** | **28.53 ns** | **0.407 ns** | **0.381 ns** | **0.0013** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |    **10** |    **9** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |    10 |    9 | 19.66 ns | 0.048 ns | 0.045 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |    10 |    9 | 25.11 ns | 0.279 ns | 0.233 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |    10 |    9 | 15.65 ns | 0.003 ns | 0.002 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 | 22.19 ns | 0.004 ns | 0.003 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 | 22.19 ns | 0.003 ns | 0.002 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |   **100** |   **99** |     **?** |    **?** | **28.35 ns** | **0.341 ns** | **0.319 ns** | **0.0013** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |   **100** |   **99** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |   100 |   99 | 19.65 ns | 0.019 ns | 0.018 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |   100 |   99 | 24.80 ns | 0.051 ns | 0.048 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |   100 |   99 | 15.62 ns | 0.003 ns | 0.002 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 | 22.19 ns | 0.004 ns | 0.003 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 | 22.19 ns | 0.003 ns | 0.003 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |  **1000** |  **999** |     **?** |    **?** | **28.34 ns** | **0.443 ns** | **0.392 ns** | **0.0013** |      **24 B** |
|    TryGetExistingValue | Syste(...)table [28] |  1000 |  999 |     ? |    ? | 28.02 ns | 0.495 ns | 0.463 ns | 0.0013 |      24 B |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |  **1000** |  **999** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|                    Add | Syste(...)table [28] |     ? |    ? |  1000 |  999 |       NA |       NA |       NA |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 19.58 ns | 0.045 ns | 0.043 ns |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 19.58 ns | 0.019 ns | 0.018 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 25.15 ns | 0.042 ns | 0.037 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 24.76 ns | 0.040 ns | 0.035 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 15.61 ns | 0.006 ns | 0.005 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 15.51 ns | 0.008 ns | 0.007 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 22.19 ns | 0.001 ns | 0.001 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 22.20 ns | 0.001 ns | 0.001 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 22.36 ns | 0.002 ns | 0.001 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 22.19 ns | 0.002 ns | 0.002 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** | **10000** | **9999** |     **?** |    **?** | **27.90 ns** | **0.404 ns** | **0.378 ns** | **0.0013** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** | **10000** | **9999** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 19.56 ns | 0.017 ns | 0.016 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 24.77 ns | 0.046 ns | 0.043 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 15.51 ns | 0.005 ns | 0.005 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 21.52 ns | 0.003 ns | 0.003 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 22.11 ns | 0.213 ns | 0.199 ns |      - |         - |

Benchmarks with issues:
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=0, last=-1]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10, last=9]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=100, last=99]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10000, last=9999]
