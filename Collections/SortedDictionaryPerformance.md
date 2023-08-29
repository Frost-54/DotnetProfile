C# SortedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |       Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |-----------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **9.154 ns** | **0.0016 ns** | **0.0015 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  20.447 ns | 0.1207 ns | 0.1129 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  20.655 ns | 0.0895 ns | 0.0837 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   9.247 ns | 0.0348 ns | 0.0291 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   9.132 ns | 0.0056 ns | 0.0050 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   9.131 ns | 0.0046 ns | 0.0040 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **42.478 ns** | **0.0052 ns** | **0.0043 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  65.855 ns | 0.1597 ns | 0.1494 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  64.407 ns | 0.4555 ns | 0.4261 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  65.706 ns | 0.0570 ns | 0.0476 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  61.875 ns | 0.0153 ns | 0.0136 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  76.003 ns | 0.0085 ns | 0.0079 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **75.116 ns** | **0.0371 ns** | **0.0347 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 | 110.745 ns | 0.0530 ns | 0.0496 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 | 110.925 ns | 0.0426 ns | 0.0377 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 | 110.868 ns | 0.0115 ns | 0.0096 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 | 115.118 ns | 0.0527 ns | 0.0493 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 | 127.479 ns | 0.0360 ns | 0.0300 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** | **107.130 ns** | **0.0285 ns** | **0.0267 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? | 107.731 ns | 0.0180 ns | 0.0160 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.623 ns | 0.0225 ns | 0.0188 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.651 ns | 0.0170 ns | 0.0159 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.897 ns | 0.0176 ns | 0.0164 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.930 ns | 0.0298 ns | 0.0279 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.882 ns | 0.0161 ns | 0.0134 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.904 ns | 0.0199 ns | 0.0186 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 205.744 ns | 0.1971 ns | 0.1747 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 206.519 ns | 0.0356 ns | 0.0316 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 219.321 ns | 0.0529 ns | 0.0441 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 218.946 ns | 0.1190 ns | 0.1113 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **150.401 ns** | **0.0302 ns** | **0.0282 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 222.985 ns | 0.1150 ns | 0.1076 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 233.929 ns | 0.0282 ns | 0.0264 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 233.950 ns | 0.0418 ns | 0.0349 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 260.172 ns | 0.2762 ns | 0.2584 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 272.575 ns | 0.0894 ns | 0.0836 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
