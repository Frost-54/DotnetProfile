C# OrderedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |          Mean |       Error |      StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |--------------:|------------:|------------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [48]** |     **0** |     **?** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |     **0** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |     0 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |     0 |            NA |          NA |          NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |     0 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |      8.276 ns |   0.0541 ns |   0.0506 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |      8.444 ns |   0.0514 ns |   0.0480 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |      **3.722 ns** |   **0.0174 ns** |   **0.0163 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |     39.966 ns |   0.2341 ns |   0.2076 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     76.242 ns |   0.2258 ns |   0.2112 ns | 0.0002 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |     83.912 ns |   0.2936 ns |   0.2746 ns | 0.0002 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |      **3.722 ns** |   **0.0117 ns** |   **0.0109 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |     39.692 ns |   0.1019 ns |   0.0953 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |    155.389 ns |   3.0641 ns |   3.1466 ns | 0.0002 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |    159.517 ns |   1.6086 ns |   1.5047 ns | 0.0002 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |      **3.725 ns** |   **0.0168 ns** |   **0.0157 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |     39.304 ns |   0.2706 ns |   0.2531 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |    305.104 ns |   0.9875 ns |   0.8754 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |    312.700 ns |   0.9563 ns |   0.7986 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |      **3.713 ns** |   **0.0031 ns** |   **0.0026 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |     39.305 ns |   0.0969 ns |   0.0809 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |    602.608 ns |   1.7913 ns |   1.6756 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |    609.663 ns |   1.4489 ns |   1.2099 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |      **3.714 ns** |   **0.0098 ns** |   **0.0087 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |     39.656 ns |   0.1935 ns |   0.1810 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |    752.026 ns |   2.2097 ns |   2.0669 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |    757.588 ns |   0.5678 ns |   0.4433 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |      **3.721 ns** |   **0.0121 ns** |   **0.0101 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |      3.721 ns |   0.0145 ns |   0.0136 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |            NA |          NA |          NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |          NA |          NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     39.175 ns |   0.0931 ns |   0.0826 ns | 0.0007 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     38.621 ns |   0.1029 ns |   0.0912 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |          NA |          NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  7,447.917 ns |  14.7474 ns |  13.7947 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  7,457.828 ns |  16.2762 ns |  13.5914 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  7,453.510 ns |  13.2769 ns |  11.7696 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  7,455.893 ns |  11.8843 ns |  11.1166 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |      **3.712 ns** |   **0.0035 ns** |   **0.0031 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |            **NA** |          **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |            NA |          NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |     38.793 ns |   0.1390 ns |   0.1300 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |            NA |          NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 75,095.448 ns | 347.9901 ns | 308.4842 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 75,446.987 ns | 367.0884 ns | 343.3747 ns |      - |      24 B |

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
