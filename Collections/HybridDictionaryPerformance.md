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
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** |  **6.583 ns** | **0.0544 ns** | **0.0508 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 18.127 ns | 0.0985 ns | 0.0873 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 18.209 ns | 0.1084 ns | 0.0961 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 |  7.120 ns | 0.0316 ns | 0.0295 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 |  7.370 ns | 0.1702 ns | 0.1672 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 |  7.827 ns | 0.0322 ns | 0.0301 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **16.301 ns** | **0.0760 ns** | **0.0711 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 26.879 ns | 0.0782 ns | 0.0693 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 27.267 ns | 0.1273 ns | 0.1191 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 11.443 ns | 0.0565 ns | 0.0529 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 12.934 ns | 0.0882 ns | 0.0825 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 13.078 ns | 0.0966 ns | 0.0856 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **15.818 ns** | **0.1143 ns** | **0.1069 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 26.792 ns | 0.0657 ns | 0.0582 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 27.111 ns | 0.0589 ns | 0.0522 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 11.127 ns | 0.0349 ns | 0.0309 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 12.836 ns | 0.0426 ns | 0.0399 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 12.673 ns | 0.0449 ns | 0.0398 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **15.498 ns** | **0.0746 ns** | **0.0698 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 27.120 ns | 0.0618 ns | 0.0483 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 27.317 ns | 0.0956 ns | 0.0847 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 11.333 ns | 0.0387 ns | 0.0323 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 12.740 ns | 0.0454 ns | 0.0425 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 12.794 ns | 0.0290 ns | 0.0271 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **16.334 ns** | **0.0860 ns** | **0.0804 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 26.933 ns | 0.0977 ns | 0.0914 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 27.221 ns | 0.0544 ns | 0.0482 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 11.369 ns | 0.1839 ns | 0.1721 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 12.807 ns | 0.0227 ns | 0.0213 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 12.834 ns | 0.0345 ns | 0.0323 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **15.684 ns** | **0.0885 ns** | **0.0828 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 27.303 ns | 0.0915 ns | 0.0812 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 27.624 ns | 0.1093 ns | 0.0969 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 11.306 ns | 0.0171 ns | 0.0152 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 12.802 ns | 0.0497 ns | 0.0441 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 12.700 ns | 0.0430 ns | 0.0381 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **15.867 ns** | **0.1259 ns** | **0.1178 ns** | **0.0003** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 16.255 ns | 0.0716 ns | 0.0670 ns | 0.0003 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 27.331 ns | 0.1295 ns | 0.1211 ns | 0.0006 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 27.318 ns | 0.1140 ns | 0.1067 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 27.253 ns | 0.0894 ns | 0.0793 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 26.985 ns | 0.0574 ns | 0.0509 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 11.190 ns | 0.0528 ns | 0.0494 ns | 0.0003 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 11.468 ns | 0.0601 ns | 0.0533 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 12.647 ns | 0.0364 ns | 0.0323 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 12.772 ns | 0.0454 ns | 0.0403 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 12.640 ns | 0.0378 ns | 0.0354 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 12.670 ns | 0.0333 ns | 0.0311 ns | 0.0003 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **16.423 ns** | **0.0705 ns** | **0.0660 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 27.266 ns | 0.1757 ns | 0.1644 ns | 0.0006 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 27.113 ns | 0.0678 ns | 0.0634 ns | 0.0006 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 11.159 ns | 0.0403 ns | 0.0377 ns | 0.0003 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 12.769 ns | 0.0360 ns | 0.0319 ns | 0.0003 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 12.805 ns | 0.0531 ns | 0.0497 ns | 0.0003 |      24 B |

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
