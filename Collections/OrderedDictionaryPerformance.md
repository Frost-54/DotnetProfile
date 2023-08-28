C# OrderedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |          Mean |      Error |     StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |--------------:|-----------:|-----------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [48]** |     **0** |     **?** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |     **0** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |     0 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |     0 |            NA |         NA |         NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |     0 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |     10.818 ns |  0.2573 ns |  0.2281 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |     10.907 ns |  0.1817 ns |  0.1699 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |      **5.370 ns** |  **0.0137 ns** |  **0.0121 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |     47.718 ns |  0.3562 ns |  0.3332 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     94.437 ns |  0.0703 ns |  0.0658 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |    104.295 ns |  0.0638 ns |  0.0597 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |      **5.178 ns** |  **0.1106 ns** |  **0.1035 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |     49.836 ns |  0.2977 ns |  0.2785 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |    200.414 ns |  0.1062 ns |  0.0994 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |    206.969 ns |  0.1958 ns |  0.1831 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |      **5.372 ns** |  **0.0185 ns** |  **0.0164 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |     48.931 ns |  0.3018 ns |  0.2823 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |    379.128 ns |  0.3375 ns |  0.2818 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |    392.729 ns |  0.7996 ns |  0.7479 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |      **5.390 ns** |  **0.0506 ns** |  **0.0473 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |     49.382 ns |  0.2717 ns |  0.2541 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |    738.232 ns |  0.9449 ns |  0.7891 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |    748.044 ns |  0.6534 ns |  0.5792 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |      **5.221 ns** |  **0.1044 ns** |  **0.0977 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |     48.604 ns |  0.2446 ns |  0.2288 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |    918.367 ns |  0.8332 ns |  0.7386 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |    923.642 ns |  1.7149 ns |  1.6042 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |      **5.169 ns** |  **0.0981 ns** |  **0.0918 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |      5.057 ns |  0.0565 ns |  0.0529 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     51.786 ns |  0.1775 ns |  0.1660 ns | 0.0022 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     47.942 ns |  0.3214 ns |  0.3007 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  8,909.576 ns |  1.3726 ns |  1.1462 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 | 11,576.127 ns |  4.2076 ns |  3.9358 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,925.673 ns |  1.6843 ns |  1.5755 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,940.724 ns |  5.7081 ns |  5.3394 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |      **5.092 ns** |  **0.0220 ns** |  **0.0195 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |     49.529 ns |  0.2070 ns |  0.1936 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 89,121.178 ns | 41.1715 ns | 38.5118 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 89,761.265 ns | 32.2864 ns | 30.2008 ns |      - |      24 B |

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
