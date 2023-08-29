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
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** |  **9.489 ns** | **0.1518 ns** | **0.1420 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 25.478 ns | 0.2776 ns | 0.2597 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 26.069 ns | 0.1961 ns | 0.1835 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 | 10.484 ns | 0.1475 ns | 0.1307 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 | 10.250 ns | 0.1259 ns | 0.1177 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 |  9.768 ns | 0.1437 ns | 0.1344 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **22.836 ns** | **0.0985 ns** | **0.0922 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 34.597 ns | 0.2925 ns | 0.2737 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 34.074 ns | 0.2074 ns | 0.1940 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 14.791 ns | 0.1533 ns | 0.1434 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 16.316 ns | 0.0867 ns | 0.0811 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 16.520 ns | 0.1373 ns | 0.1284 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **21.966 ns** | **0.1304 ns** | **0.1220 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 33.388 ns | 0.1645 ns | 0.1374 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 33.134 ns | 0.1052 ns | 0.0984 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 15.667 ns | 0.1045 ns | 0.0873 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 16.052 ns | 0.0617 ns | 0.0577 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 16.428 ns | 0.1416 ns | 0.1324 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **21.829 ns** | **0.0883 ns** | **0.0782 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 34.965 ns | 0.1303 ns | 0.1155 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 33.551 ns | 0.1900 ns | 0.1777 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 14.631 ns | 0.2272 ns | 0.2125 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 16.471 ns | 0.1325 ns | 0.1240 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 16.174 ns | 0.0769 ns | 0.0719 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **21.929 ns** | **0.0883 ns** | **0.0783 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 34.429 ns | 0.3202 ns | 0.2995 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 34.471 ns | 0.2241 ns | 0.2096 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 15.957 ns | 0.1046 ns | 0.0978 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 16.319 ns | 0.1873 ns | 0.1752 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 16.194 ns | 0.1104 ns | 0.0979 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **20.732 ns** | **0.1376 ns** | **0.1287 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 33.959 ns | 0.4342 ns | 0.4062 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 33.493 ns | 0.2919 ns | 0.2730 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 16.161 ns | 0.1634 ns | 0.1529 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 17.304 ns | 0.1569 ns | 0.1468 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 17.086 ns | 0.1037 ns | 0.0970 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **22.294 ns** | **0.0573 ns** | **0.0536 ns** | **0.0010** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 22.679 ns | 0.1430 ns | 0.1337 ns | 0.0010 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 34.117 ns | 0.1452 ns | 0.1358 ns | 0.0019 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 34.808 ns | 0.1410 ns | 0.1319 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 34.950 ns | 0.1999 ns | 0.1870 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 34.645 ns | 0.2809 ns | 0.2628 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 16.744 ns | 0.1231 ns | 0.1091 ns | 0.0010 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 14.906 ns | 0.1650 ns | 0.1543 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 16.112 ns | 0.0497 ns | 0.0465 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 16.342 ns | 0.1497 ns | 0.1327 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.412 ns | 0.1513 ns | 0.1416 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 16.930 ns | 0.1374 ns | 0.1285 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **20.574 ns** | **0.0815 ns** | **0.0723 ns** | **0.0010** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 34.423 ns | 0.3245 ns | 0.3036 ns | 0.0019 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 33.517 ns | 0.2046 ns | 0.1914 ns | 0.0019 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 15.863 ns | 0.0905 ns | 0.0802 ns | 0.0010 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 16.138 ns | 0.0410 ns | 0.0384 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 16.481 ns | 0.2015 ns | 0.1786 ns | 0.0010 |      24 B |

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
