C# Hashtable performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |            hashtable |     a |    b |  next | last |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |----- |------ |----- |----------:|----------:|----------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)table [28]** |     **0** |   **-1** |     **?** |    **?** | **16.342 ns** | **0.1859 ns** | **0.1739 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |     **0** |   **-1** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 15.085 ns | 0.0261 ns | 0.0244 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 15.128 ns | 0.0210 ns | 0.0175 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 10.207 ns | 0.0219 ns | 0.0194 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  8.751 ns | 0.0327 ns | 0.0306 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 10.932 ns | 0.0170 ns | 0.0151 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |    **10** |    **9** |     **?** |    **?** | **25.110 ns** | **0.1462 ns** | **0.1296 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |    **10** |    **9** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |    10 |    9 | 15.157 ns | 0.0214 ns | 0.0200 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |    10 |    9 | 19.172 ns | 0.0493 ns | 0.0437 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |    10 |    9 | 10.394 ns | 0.0217 ns | 0.0203 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 | 10.769 ns | 0.0089 ns | 0.0084 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  8.881 ns | 0.0754 ns | 0.0706 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |   **100** |   **99** |     **?** |    **?** | **23.550 ns** | **0.0834 ns** | **0.0740 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |   **100** |   **99** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |   100 |   99 | 15.168 ns | 0.0264 ns | 0.0247 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |   100 |   99 | 18.796 ns | 0.0645 ns | 0.0603 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |   100 |   99 | 10.399 ns | 0.0413 ns | 0.0366 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.786 ns | 0.0293 ns | 0.0260 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.801 ns | 0.0237 ns | 0.0210 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |  **1000** |  **999** |     **?** |    **?** | **22.111 ns** | **0.0983 ns** | **0.0919 ns** | **0.0010** |      **24 B** |
|    TryGetExistingValue | Syste(...)table [28] |  1000 |  999 |     ? |    ? | 22.927 ns | 0.0490 ns | 0.0409 ns | 0.0010 |      24 B |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |  **1000** |  **999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)table [28] |     ? |    ? |  1000 |  999 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 15.147 ns | 0.0263 ns | 0.0234 ns |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 15.167 ns | 0.0212 ns | 0.0198 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 19.337 ns | 0.0419 ns | 0.0371 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 18.751 ns | 0.0391 ns | 0.0365 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 10.306 ns | 0.0293 ns | 0.0274 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 10.317 ns | 0.0386 ns | 0.0361 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.803 ns | 0.0381 ns | 0.0357 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.821 ns | 0.0293 ns | 0.0274 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.919 ns | 0.0504 ns | 0.0472 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.926 ns | 0.0685 ns | 0.0640 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** | **10000** | **9999** |     **?** |    **?** | **23.196 ns** | **0.0704 ns** | **0.0625 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** | **10000** | **9999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 14.760 ns | 0.0199 ns | 0.0177 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 19.019 ns | 0.0489 ns | 0.0458 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 10.429 ns | 0.0361 ns | 0.0320 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  8.817 ns | 0.0180 ns | 0.0159 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  8.686 ns | 0.0250 ns | 0.0234 ns |      - |         - |

Benchmarks with issues:
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=0, last=-1]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10, last=9]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=100, last=99]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10000, last=9999]
