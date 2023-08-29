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
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** |  **7.935 ns** | **0.1761 ns** | **0.1647 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 25.622 ns | 0.4545 ns | 0.4252 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 25.173 ns | 0.2316 ns | 0.2167 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 | 10.326 ns | 0.1439 ns | 0.1346 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 | 10.276 ns | 0.1876 ns | 0.1755 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 |  9.056 ns | 0.2223 ns | 0.2079 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **20.438 ns** | **0.0816 ns** | **0.0763 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 38.599 ns | 0.1692 ns | 0.1582 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 34.218 ns | 0.3323 ns | 0.2946 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 16.064 ns | 0.3300 ns | 0.3087 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 16.409 ns | 0.2074 ns | 0.1940 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 19.428 ns | 0.1628 ns | 0.1523 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **20.572 ns** | **0.1547 ns** | **0.1447 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 33.926 ns | 0.3296 ns | 0.3083 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 33.466 ns | 0.3098 ns | 0.2747 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 15.779 ns | 0.0981 ns | 0.0917 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 16.155 ns | 0.1118 ns | 0.0991 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 16.331 ns | 0.0983 ns | 0.0871 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **22.056 ns** | **0.0935 ns** | **0.0875 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 34.283 ns | 0.3003 ns | 0.2809 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 33.498 ns | 0.2570 ns | 0.2404 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 15.876 ns | 0.1768 ns | 0.1654 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 16.666 ns | 0.1427 ns | 0.1335 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 16.347 ns | 0.1868 ns | 0.1748 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **22.077 ns** | **0.1281 ns** | **0.1198 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 34.209 ns | 0.2185 ns | 0.2044 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 34.157 ns | 0.3183 ns | 0.2977 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 15.839 ns | 0.1123 ns | 0.1050 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 16.370 ns | 0.1501 ns | 0.1404 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 16.339 ns | 0.1837 ns | 0.1718 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **21.959 ns** | **0.1710 ns** | **0.1516 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 34.227 ns | 0.2853 ns | 0.2669 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 33.802 ns | 0.3107 ns | 0.2906 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 15.557 ns | 0.3835 ns | 0.3767 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 16.391 ns | 0.1705 ns | 0.1595 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 16.430 ns | 0.1500 ns | 0.1330 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **22.362 ns** | **0.0490 ns** | **0.0410 ns** | **0.0010** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 24.506 ns | 0.2660 ns | 0.2488 ns | 0.0010 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 34.506 ns | 0.2467 ns | 0.2307 ns | 0.0019 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 34.895 ns | 0.1513 ns | 0.1181 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 35.073 ns | 0.1860 ns | 0.1740 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 34.828 ns | 0.3002 ns | 0.2808 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 15.948 ns | 0.1400 ns | 0.1310 ns | 0.0010 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 16.126 ns | 0.0829 ns | 0.0692 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 16.527 ns | 0.1072 ns | 0.1003 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 16.460 ns | 0.1462 ns | 0.1368 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.248 ns | 0.1000 ns | 0.0935 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.086 ns | 0.0985 ns | 0.0921 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **23.996 ns** | **0.0930 ns** | **0.0870 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 34.433 ns | 0.1352 ns | 0.1264 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 33.805 ns | 0.2355 ns | 0.2202 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 15.937 ns | 0.1305 ns | 0.1157 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 17.171 ns | 0.1506 ns | 0.1408 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 16.317 ns | 0.0965 ns | 0.0902 ns | 0.0010 |      24 B |

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
