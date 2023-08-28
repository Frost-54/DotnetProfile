C# HybridDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |----------:|----------:|----------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** |  **8.119 ns** | **0.1329 ns** | **0.1243 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 24.629 ns | 0.2785 ns | 0.2605 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 24.415 ns | 0.3919 ns | 0.3474 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 | 10.694 ns | 0.1315 ns | 0.1230 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 | 10.716 ns | 0.1661 ns | 0.1554 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 |  9.313 ns | 0.2097 ns | 0.1961 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **20.707 ns** | **0.1059 ns** | **0.0991 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 34.640 ns | 0.2246 ns | 0.2101 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 33.550 ns | 0.2445 ns | 0.2287 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 14.812 ns | 0.3540 ns | 0.3788 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 16.823 ns | 0.1309 ns | 0.1224 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 16.335 ns | 0.1759 ns | 0.1646 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **23.797 ns** | **0.0550 ns** | **0.0488 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 34.153 ns | 0.3293 ns | 0.3080 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 34.196 ns | 0.2870 ns | 0.2684 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 14.542 ns | 0.1490 ns | 0.1321 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 16.392 ns | 0.1584 ns | 0.1482 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 16.118 ns | 0.1335 ns | 0.1183 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **22.649 ns** | **0.1076 ns** | **0.0840 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 34.598 ns | 0.4982 ns | 0.4660 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 33.262 ns | 0.2484 ns | 0.2202 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 15.846 ns | 0.1411 ns | 0.1250 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 16.571 ns | 0.1741 ns | 0.1629 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 16.384 ns | 0.1821 ns | 0.1703 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **22.463 ns** | **0.1625 ns** | **0.1441 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 34.414 ns | 0.2701 ns | 0.2527 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 34.138 ns | 0.3621 ns | 0.3387 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 14.394 ns | 0.1373 ns | 0.1146 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 16.216 ns | 0.1300 ns | 0.1216 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 16.389 ns | 0.1251 ns | 0.1171 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **20.723 ns** | **0.1069 ns** | **0.1000 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 34.888 ns | 0.2521 ns | 0.2358 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 33.644 ns | 0.2231 ns | 0.2087 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 16.173 ns | 0.3171 ns | 0.2966 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 16.531 ns | 0.1993 ns | 0.1864 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 16.390 ns | 0.1549 ns | 0.1449 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **22.732 ns** | **0.1370 ns** | **0.1281 ns** | **0.0010** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 22.332 ns | 0.1295 ns | 0.1081 ns | 0.0010 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 33.551 ns | 0.4887 ns | 0.4571 ns | 0.0019 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 33.908 ns | 0.3999 ns | 0.3740 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 33.274 ns | 0.3912 ns | 0.3659 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 34.422 ns | 0.1735 ns | 0.1623 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 14.471 ns | 0.2257 ns | 0.2001 ns | 0.0010 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 16.011 ns | 0.2281 ns | 0.2134 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 16.270 ns | 0.1328 ns | 0.1242 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 18.846 ns | 0.1624 ns | 0.1519 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.409 ns | 0.1922 ns | 0.1798 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.202 ns | 0.1816 ns | 0.1699 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **22.062 ns** | **0.1215 ns** | **0.1137 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 33.646 ns | 0.3673 ns | 0.3436 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 34.238 ns | 0.3536 ns | 0.3308 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 15.597 ns | 0.1073 ns | 0.0951 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 15.890 ns | 0.0993 ns | 0.0880 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 16.243 ns | 0.2321 ns | 0.2171 ns | 0.0010 |      24 B |

Benchmarks with issues:
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=0]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=10]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=20]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=40]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=80]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=100]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=1000]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=1000]
  HybridDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [47], next=10000]
