C# OrderedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |           Mean |         Error |        StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |---------------:|--------------:|--------------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [48]** |     **0** |     **?** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |     **0** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |     0 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |     0 |             NA |            NA |            NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |     0 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |      15.218 ns |     0.3331 ns |     0.6256 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |      16.008 ns |     0.3327 ns |     0.3267 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |       **5.519 ns** |     **0.2054 ns** |     **0.2742 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |      74.474 ns |     1.5315 ns |     1.8809 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     129.248 ns |     2.5711 ns |     3.7686 ns | 0.0007 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |     143.348 ns |     2.1335 ns |     1.8913 ns | 0.0007 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |       **6.160 ns** |     **0.1782 ns** |     **0.1667 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |      71.714 ns |     1.4480 ns |     2.2544 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |     241.440 ns |     4.8837 ns |     4.5683 ns | 0.0005 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |     250.709 ns |     4.9654 ns |     6.4564 ns | 0.0005 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |       **5.705 ns** |     **0.1911 ns** |     **0.2552 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |      72.666 ns |     1.4601 ns |     1.3658 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |     507.173 ns |     9.7727 ns |     9.1414 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |     481.242 ns |     9.5689 ns |     9.3980 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |       **5.611 ns** |     **0.1910 ns** |     **0.1787 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |      71.969 ns |     1.0583 ns |     0.9900 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |     914.500 ns |    15.1504 ns |    19.6998 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |     961.517 ns |    16.5714 ns |    14.6901 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |       **5.922 ns** |     **0.1818 ns** |     **0.1700 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |      71.299 ns |     1.4648 ns |     1.7989 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |   1,173.836 ns |    23.1551 ns |    32.4602 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |   1,146.573 ns |    22.6226 ns |    21.1612 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |       **5.533 ns** |     **0.1975 ns** |     **0.2704 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |       5.928 ns |     0.2054 ns |     0.2017 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |             NA |            NA |            NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |             NA |            NA |            NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |      73.340 ns |     1.4360 ns |     1.7095 ns | 0.0020 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |      72.512 ns |     1.1561 ns |     1.0814 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |             NA |            NA |            NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  11,811.528 ns |   156.3168 ns |   130.5316 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  10,665.875 ns |   209.1189 ns |   195.6099 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  11,407.827 ns |   225.4212 ns |   394.8070 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  11,946.999 ns |   206.9267 ns |   328.2076 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |       **5.609 ns** |     **0.1695 ns** |     **0.1502 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |             **NA** |            **NA** |            **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |             NA |            NA |            NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |      67.813 ns |     1.3976 ns |     1.6638 ns | 0.0020 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |             NA |            NA |            NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 114,456.380 ns | 2,262.6234 ns | 4,249.7552 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 113,078.748 ns | 2,239.3229 ns | 2,911.7523 ns |      - |      24 B |

Benchmarks with issues:
  OrderedDictionaryPerformance.TryGetExistingValue: DefaultJob [dictionary=Syste(...)onary [48], _=0]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=0]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=0]
  OrderedDictionaryPerformance.Update: DefaultJob [dictionary=Syste(...)onary [48], next=0]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=0]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=10]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=10]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=10]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=20]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=20]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=20]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=40]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=40]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=40]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=80]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=80]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=80]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=100]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=100]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=100]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=1000]
  OrderedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)onary [48], next=10000]
  OrderedDictionaryPerformance.AddBySquareBracket: DefaultJob [dictionary=Syste(...)onary [48], next=10000]
  OrderedDictionaryPerformance.TryGetNonExistingValue: DefaultJob [dictionary=Syste(...)onary [48], next=10000]
