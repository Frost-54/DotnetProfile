C# Dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |     Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |---------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **3.400 ns** | **0.1034 ns** | **0.0967 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 6.284 ns | 0.1672 ns | 0.1990 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 7.117 ns | 0.1764 ns | 0.1650 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 5.728 ns | 0.1606 ns | 0.2354 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 3.201 ns | 0.1076 ns | 0.1610 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.881 ns | 0.1030 ns | 0.0964 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **5.843 ns** | **0.1643 ns** | **0.1687 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 6.121 ns | 0.1649 ns | 0.1542 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 7.018 ns | 0.1748 ns | 0.1635 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 6.346 ns | 0.1718 ns | 0.2293 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 5.238 ns | 0.1497 ns | 0.3058 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 4.997 ns | 0.1468 ns | 0.2533 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **5.770 ns** | **0.1570 ns** | **0.1928 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 6.336 ns | 0.1509 ns | 0.1412 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 7.628 ns | 0.1954 ns | 0.2472 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 6.766 ns | 0.1543 ns | 0.1368 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 4.746 ns | 0.1338 ns | 0.2003 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 4.765 ns | 0.1350 ns | 0.1196 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **7.712 ns** | **0.1372 ns** | **0.1216 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 6.055 ns | 0.1649 ns | 0.3478 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 6.558 ns | 0.1571 ns | 0.1393 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 6.090 ns | 0.0894 ns | 0.1999 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 7.900 ns | 0.1739 ns | 0.2261 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 7.876 ns | 0.1849 ns | 0.1639 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.560 ns | 0.1593 ns | 0.1490 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 5.953 ns | 0.1399 ns | 0.1961 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.507 ns | 0.1343 ns | 0.1699 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 5.138 ns | 0.1457 ns | 0.3010 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.761 ns | 0.1300 ns | 0.1736 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 5.249 ns | 0.1466 ns | 0.2753 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **5.797 ns** | **0.1598 ns** | **0.2799 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 6.948 ns | 0.1795 ns | 0.1843 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 7.192 ns | 0.1912 ns | 0.2045 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 6.405 ns | 0.1289 ns | 0.1143 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 5.030 ns | 0.1189 ns | 0.1112 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 5.239 ns | 0.1431 ns | 0.1648 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
