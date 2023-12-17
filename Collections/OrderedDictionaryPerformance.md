C# OrderedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |          Mean |         Error |      StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |--------------:|--------------:|------------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [48]** |     **0** |     **?** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |     **0** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |     0 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |     0 |            NA |            NA |          NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |     0 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |      7.994 ns |     0.0287 ns |   0.0255 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |      7.988 ns |     0.0237 ns |   0.0210 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |      **3.720 ns** |     **0.0172 ns** |   **0.0153 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |     39.125 ns |     0.1503 ns |   0.1406 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     76.596 ns |     0.2324 ns |   0.2174 ns | 0.0002 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |     83.454 ns |     0.0966 ns |   0.0754 ns | 0.0002 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |      **3.720 ns** |     **0.0115 ns** |   **0.0108 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |     38.958 ns |     0.1384 ns |   0.1294 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |    155.964 ns |     1.8980 ns |   1.7754 ns | 0.0002 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |    160.146 ns |     2.6659 ns |   2.3633 ns | 0.0002 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |      **3.723 ns** |     **0.0126 ns** |   **0.0112 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |     39.199 ns |     0.1292 ns |   0.1208 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |    304.963 ns |     0.7738 ns |   0.7238 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |    312.684 ns |     0.9207 ns |   0.7688 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |      **3.717 ns** |     **0.0098 ns** |   **0.0091 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |     38.310 ns |     0.2182 ns |   0.2041 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |    602.629 ns |     1.6913 ns |   1.5820 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |    610.216 ns |     1.9328 ns |   1.8080 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |      **3.751 ns** |     **0.0085 ns** |   **0.0071 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |     38.703 ns |     0.1653 ns |   0.1546 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |    751.118 ns |     1.4765 ns |   1.3811 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |    759.227 ns |     2.0274 ns |   1.7972 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |      **3.722 ns** |     **0.0108 ns** |   **0.0101 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |      3.722 ns |     0.0123 ns |   0.0109 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |            NA |            NA |          NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |            NA |          NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     39.020 ns |     0.1510 ns |   0.1412 ns | 0.0007 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     38.288 ns |     0.0463 ns |   0.0386 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |            NA |          NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  7,451.046 ns |    14.7932 ns |  13.8375 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  7,453.896 ns |    14.1400 ns |  12.5347 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  7,454.226 ns |    16.7150 ns |  15.6352 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  7,465.318 ns |    15.0010 ns |  13.2980 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |      **3.720 ns** |     **0.0134 ns** |   **0.0119 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |            **NA** |            **NA** |          **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |            NA |            NA |          NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |     38.424 ns |     0.1545 ns |   0.1446 ns | 0.0007 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |            NA |            NA |          NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 76,154.552 ns | 1,044.7845 ns | 977.2921 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 75,135.375 ns |   196.1375 ns | 183.4671 ns |      - |      24 B |

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
