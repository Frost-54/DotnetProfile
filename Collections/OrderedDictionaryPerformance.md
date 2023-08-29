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
|         RemoveExisting | Syste(...)onary [48] |     ? |     0 |     10.176 ns |  0.1549 ns |  0.1449 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |     0 |     10.144 ns |  0.1871 ns |  0.1750 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **10** |     **?** |      **5.079 ns** |  **0.0388 ns** |  **0.0363 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **10** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    10 |     51.134 ns |  0.2443 ns |  0.2285 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    10 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    10 |     92.571 ns |  0.2271 ns |  0.2124 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    10 |    102.387 ns |  0.0265 ns |  0.0221 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **20** |     **?** |      **5.047 ns** |  **0.0185 ns** |  **0.0164 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **20** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    20 |     50.494 ns |  0.1946 ns |  0.1725 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    20 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    20 |    199.273 ns |  0.2413 ns |  0.2015 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    20 |    211.915 ns |  0.2338 ns |  0.2187 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **40** |     **?** |      **5.358 ns** |  **0.0136 ns** |  **0.0121 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **40** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    40 |     47.686 ns |  0.3322 ns |  0.3107 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    40 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    40 |    381.527 ns |  0.8392 ns |  0.7439 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    40 |    399.387 ns |  0.4370 ns |  0.4088 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |    **80** |     **?** |      **5.456 ns** |  **0.1069 ns** |  **0.1000 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |    **80** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |    80 |     47.948 ns |  0.1797 ns |  0.1681 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |    80 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |    80 |    750.465 ns |  0.6111 ns |  0.5716 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |    80 |    748.388 ns |  1.1046 ns |  1.0332 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |   **100** |     **?** |      **5.070 ns** |  **0.0246 ns** |  **0.0218 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** |   **100** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |   100 |     49.079 ns |  0.1609 ns |  0.1426 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |   100 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |   100 |    914.763 ns |  1.0070 ns |  0.8927 ns | 0.0010 |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |   100 |    922.136 ns |  1.1385 ns |  1.0092 ns | 0.0010 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** |  **1000** |     **?** |      **5.063 ns** |  **0.0412 ns** |  **0.0386 ns** |      **-** |         **-** |
|    TryGetExistingValue | Syste(...)onary [48] |  1000 |     ? |      5.354 ns |  0.0265 ns |  0.0235 ns |      - |         - |
|                    **Add** | **Syste(...)onary [48]** |     **?** |  **1000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     51.480 ns |  0.2030 ns |  0.1899 ns | 0.0022 |      56 B |
|                 Update | Syste(...)onary [48] |     ? |  1000 |     48.969 ns |  0.3150 ns |  0.2947 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? |  1000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  8,910.719 ns |  1.7312 ns |  1.4457 ns |      - |      24 B |
|         RemoveExisting | Syste(...)onary [48] |     ? |  1000 |  8,928.889 ns |  5.7746 ns |  5.1190 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,921.053 ns |  1.0633 ns |  0.9426 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? |  1000 |  8,915.094 ns |  2.2134 ns |  1.9621 ns |      - |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [48]** | **10000** |     **?** |      **5.107 ns** |  **0.0476 ns** |  **0.0445 ns** |      **-** |         **-** |
|                    **Add** | **Syste(...)onary [48]** |     **?** | **10000** |            **NA** |         **NA** |         **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|                 Update | Syste(...)onary [48] |     ? | 10000 |     47.791 ns |  0.2997 ns |  0.2803 ns | 0.0022 |      56 B |
| TryGetNonExistingValue | Syste(...)onary [48] |     ? | 10000 |            NA |         NA |         NA |      - |         - |
|         RemoveExisting | Syste(...)onary [48] |     ? | 10000 | 89,759.541 ns | 73.4023 ns | 61.2942 ns |      - |      24 B |
|      RemoveNonExisting | Syste(...)onary [48] |     ? | 10000 | 88,822.812 ns | 18.4243 ns | 17.2341 ns |      - |      24 B |

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
