C# HybridDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |----------:|----------:|----------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** |  **6.158 ns** | **0.0436 ns** | **0.0407 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 17.662 ns | 0.0554 ns | 0.0462 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 17.654 ns | 0.0469 ns | 0.0416 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 |  6.917 ns | 0.0860 ns | 0.0805 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 |  6.900 ns | 0.1014 ns | 0.0949 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 |  6.884 ns | 0.0397 ns | 0.0371 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **15.329 ns** | **0.0689 ns** | **0.0644 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 26.473 ns | 0.1394 ns | 0.1164 ns | 0.0005 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 26.672 ns | 0.0847 ns | 0.0792 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 10.981 ns | 0.0546 ns | 0.0456 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 12.486 ns | 0.0848 ns | 0.0793 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 12.443 ns | 0.0342 ns | 0.0303 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **15.421 ns** | **0.0672 ns** | **0.0629 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 26.336 ns | 0.0904 ns | 0.0846 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 26.549 ns | 0.0684 ns | 0.0606 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 10.891 ns | 0.0359 ns | 0.0336 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 12.517 ns | 0.1116 ns | 0.1044 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 12.353 ns | 0.0364 ns | 0.0340 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **15.796 ns** | **0.0415 ns** | **0.0346 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 26.245 ns | 0.0606 ns | 0.0567 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 26.535 ns | 0.0958 ns | 0.0897 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 10.894 ns | 0.0620 ns | 0.0580 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 12.398 ns | 0.0624 ns | 0.0553 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 12.352 ns | 0.0366 ns | 0.0343 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **15.575 ns** | **0.0771 ns** | **0.0721 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 26.367 ns | 0.1147 ns | 0.1017 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 26.448 ns | 0.0451 ns | 0.0422 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 11.071 ns | 0.0354 ns | 0.0331 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 12.443 ns | 0.1028 ns | 0.0961 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 12.346 ns | 0.0232 ns | 0.0217 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **15.799 ns** | **0.0224 ns** | **0.0187 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 26.424 ns | 0.1390 ns | 0.1232 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 26.885 ns | 0.1113 ns | 0.1041 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 10.847 ns | 0.0435 ns | 0.0407 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 12.577 ns | 0.1105 ns | 0.0980 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 12.478 ns | 0.0489 ns | 0.0457 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **15.410 ns** | **0.0869 ns** | **0.0813 ns** | **0.0003** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 15.256 ns | 0.0841 ns | 0.0787 ns | 0.0003 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 26.563 ns | 0.1242 ns | 0.1162 ns | 0.0006 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 26.540 ns | 0.0983 ns | 0.0872 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 26.795 ns | 0.1065 ns | 0.0997 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 26.356 ns | 0.0741 ns | 0.0693 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 11.580 ns | 0.0226 ns | 0.0189 ns | 0.0003 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 11.022 ns | 0.0803 ns | 0.0712 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 12.534 ns | 0.0766 ns | 0.0716 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 12.745 ns | 0.0846 ns | 0.0791 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 12.602 ns | 0.0359 ns | 0.0336 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 12.561 ns | 0.0883 ns | 0.0826 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **15.345 ns** | **0.0810 ns** | **0.0718 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 26.636 ns | 0.2030 ns | 0.1899 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 26.771 ns | 0.0695 ns | 0.0617 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 11.056 ns | 0.0325 ns | 0.0304 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 12.339 ns | 0.0347 ns | 0.0325 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 12.462 ns | 0.0544 ns | 0.0509 ns | 0.0003 |      24 B |

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
