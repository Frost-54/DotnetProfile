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
|    **TryGetExistingValue** | **Syste(...)table [28]** |     **0** |   **-1** |     **?** |    **?** | **18.054 ns** | **0.2133 ns** | **0.1891 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |     **0** |   **-1** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 14.809 ns | 0.0287 ns | 0.0255 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 14.795 ns | 0.0266 ns | 0.0249 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 10.095 ns | 0.0303 ns | 0.0284 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  8.817 ns | 0.0269 ns | 0.0252 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 10.850 ns | 0.0568 ns | 0.0531 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |    **10** |    **9** |     **?** |    **?** | **23.393 ns** | **0.1097 ns** | **0.1027 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |    **10** |    **9** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |    10 |    9 | 14.807 ns | 0.0260 ns | 0.0243 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |    10 |    9 | 19.234 ns | 0.0570 ns | 0.0533 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |    10 |    9 | 10.099 ns | 0.0362 ns | 0.0302 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 | 11.697 ns | 0.0519 ns | 0.0486 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  8.744 ns | 0.0768 ns | 0.0681 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |   **100** |   **99** |     **?** |    **?** | **22.993 ns** | **0.0966 ns** | **0.0904 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |   **100** |   **99** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |   100 |   99 | 14.806 ns | 0.0231 ns | 0.0216 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |   100 |   99 | 19.332 ns | 0.0341 ns | 0.0302 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |   100 |   99 | 10.083 ns | 0.0273 ns | 0.0228 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.863 ns | 0.0797 ns | 0.0745 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.864 ns | 0.0636 ns | 0.0595 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |  **1000** |  **999** |     **?** |    **?** | **21.888 ns** | **0.0914 ns** | **0.0811 ns** | **0.0010** |      **24 B** |
|    TryGetExistingValue | Syste(...)table [28] |  1000 |  999 |     ? |    ? | 23.297 ns | 0.1665 ns | 0.1558 ns | 0.0010 |      24 B |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |  **1000** |  **999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)table [28] |     ? |    ? |  1000 |  999 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 14.713 ns | 0.0268 ns | 0.0250 ns |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 14.786 ns | 0.0442 ns | 0.0414 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 19.275 ns | 0.0638 ns | 0.0597 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 19.189 ns | 0.0614 ns | 0.0545 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 10.030 ns | 0.0369 ns | 0.0345 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 10.391 ns | 0.0322 ns | 0.0302 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.739 ns | 0.0219 ns | 0.0205 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.906 ns | 0.0619 ns | 0.0579 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.804 ns | 0.0296 ns | 0.0262 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.863 ns | 0.0686 ns | 0.0642 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** | **10000** | **9999** |     **?** |    **?** | **24.934 ns** | **0.1231 ns** | **0.1028 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** | **10000** | **9999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 15.154 ns | 0.0104 ns | 0.0097 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 18.830 ns | 0.0724 ns | 0.0604 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 10.326 ns | 0.0223 ns | 0.0197 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 10.303 ns | 0.0091 ns | 0.0085 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  8.909 ns | 0.0520 ns | 0.0486 ns |      - |         - |

Benchmarks with issues:
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=0, last=-1]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10, last=9]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=100, last=99]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10000, last=9999]
