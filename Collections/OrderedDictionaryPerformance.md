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
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |     11.010 ns |  0.0996 ns |  0.0931 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |     10.584 ns |  0.1190 ns |  0.1113 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |      **5.126 ns** |  **0.0374 ns** |  **0.0350 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |     48.318 ns |  0.1263 ns |  0.1181 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     93.852 ns |  0.0985 ns |  0.0873 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |    108.308 ns |  0.1082 ns |  0.1012 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |      **5.363 ns** |  **0.0241 ns** |  **0.0226 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |     51.354 ns |  0.0736 ns |  0.0575 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |    195.693 ns |  0.3140 ns |  0.2622 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |    208.485 ns |  0.2346 ns |  0.2079 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |      **5.422 ns** |  **0.0920 ns** |  **0.0861 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |     47.672 ns |  0.2648 ns |  0.2477 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |    388.408 ns |  1.4703 ns |  1.3753 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |    390.953 ns |  0.6351 ns |  0.5630 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |      **5.231 ns** |  **0.0852 ns** |  **0.0797 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |     50.971 ns |  0.3513 ns |  0.3286 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |    737.479 ns |  0.5804 ns |  0.5145 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |    762.353 ns |  0.9756 ns |  0.8649 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |      **5.283 ns** |  **0.0461 ns** |  **0.0432 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |     47.477 ns |  0.2628 ns |  0.2458 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |    929.544 ns |  0.5709 ns |  0.5340 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |    922.700 ns |  1.7916 ns |  1.6758 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |      **5.355 ns** |  **0.0196 ns** |  **0.0164 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |      5.330 ns |  0.0306 ns |  0.0286 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     50.054 ns |  0.2245 ns |  0.2100 ns | 0.0022 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     51.403 ns |  0.1792 ns |  0.1676 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  8,919.999 ns |  2.2565 ns |  2.1107 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  8,899.879 ns |  2.7135 ns |  2.2659 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,927.531 ns |  3.1676 ns |  2.9630 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,923.299 ns |  5.0631 ns |  4.4883 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |      **4.992 ns** |  **0.0212 ns** |  **0.0165 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |     49.390 ns |  0.1833 ns |  0.1714 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 89,798.746 ns | 18.4129 ns | 16.3225 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 89,439.282 ns | 18.2061 ns | 17.0300 ns |      - |      24 B |

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
