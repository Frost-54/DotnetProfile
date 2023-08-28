C# HybridDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |------ |---------:|---------:|---------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)onary [47]** |     **0** |     **?** | **10.30 ns** | **0.292 ns** | **0.563 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |     **0** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |     0 | 33.35 ns | 1.052 ns | 3.101 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |     0 | 33.82 ns | 0.780 ns | 2.299 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |     0 | 11.69 ns | 0.422 ns | 1.244 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |     0 | 12.18 ns | 0.323 ns | 0.954 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |     0 | 12.00 ns | 0.382 ns | 1.120 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **10** |     **?** | **35.25 ns** | **0.787 ns** | **2.060 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **10** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    10 | 51.51 ns | 1.061 ns | 2.191 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    10 | 53.58 ns | 1.143 ns | 3.369 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    10 | 27.50 ns | 0.632 ns | 1.020 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    10 | 37.65 ns | 0.769 ns | 1.735 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    10 | 38.49 ns | 0.773 ns | 0.759 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **20** |     **?** | **35.96 ns** | **0.627 ns** | **0.523 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **20** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    20 | 54.54 ns | 1.138 ns | 2.081 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    20 | 55.33 ns | 1.146 ns | 1.947 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    20 | 29.46 ns | 0.669 ns | 1.367 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    20 | 40.67 ns | 0.846 ns | 0.905 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    20 | 37.96 ns | 0.798 ns | 1.144 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **40** |     **?** | **36.88 ns** | **0.809 ns** | **0.831 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **40** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    40 | 51.29 ns | 1.046 ns | 1.205 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    40 | 54.08 ns | 1.119 ns | 1.930 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    40 | 28.85 ns | 0.618 ns | 0.548 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    40 | 37.94 ns | 0.750 ns | 0.737 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    40 | 37.89 ns | 0.740 ns | 0.693 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |    **80** |     **?** | **36.86 ns** | **0.784 ns** | **0.805 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |    **80** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |    80 | 54.33 ns | 1.097 ns | 1.387 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |    80 | 54.81 ns | 1.138 ns | 3.114 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |    80 | 29.21 ns | 0.663 ns | 0.737 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |    80 | 37.19 ns | 0.771 ns | 0.722 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |    80 | 40.04 ns | 0.794 ns | 1.326 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |   **100** |     **?** | **38.76 ns** | **0.845 ns** | **1.006 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** |   **100** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |   100 | 54.32 ns | 1.023 ns | 1.623 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |   100 | 56.75 ns | 1.168 ns | 2.464 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |   100 | 28.77 ns | 0.656 ns | 1.001 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |   100 | 38.28 ns | 0.755 ns | 0.706 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |   100 | 39.42 ns | 0.833 ns | 1.544 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** |  **1000** |     **?** | **38.92 ns** | **0.866 ns** | **1.126 ns** | **0.0009** |      **24 B** |
|    TryGetExistingValue | Syste(...)onary [47] |  1000 |     ? | 40.41 ns | 0.891 ns | 1.189 ns | 0.0009 |      24 B |
|                    **Add** | **Syste(...)onary [47]** |     **?** |  **1000** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|                    Add | Syste(...)onary [47] |     ? |  1000 |       NA |       NA |       NA |      - |         - |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 53.39 ns | 1.107 ns | 1.275 ns | 0.0018 |      48 B |
|     AddBySquareBracket | Syste(...)onary [47] |     ? |  1000 | 55.80 ns | 1.159 ns | 1.999 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 57.55 ns | 1.167 ns | 1.918 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? |  1000 | 53.73 ns | 1.129 ns | 3.128 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 28.51 ns | 0.648 ns | 0.908 ns | 0.0009 |      24 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? |  1000 | 28.98 ns | 0.651 ns | 0.824 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 40.66 ns | 0.846 ns | 1.213 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? |  1000 | 40.49 ns | 0.845 ns | 1.340 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 38.30 ns | 0.811 ns | 1.239 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? |  1000 | 38.63 ns | 0.758 ns | 0.709 ns | 0.0009 |      24 B |
|    **TryGetExistingValue** | **Syste(...)onary [47]** | **10000** |     **?** | **40.28 ns** | **0.888 ns** | **1.433 ns** | **0.0009** |      **24 B** |
|                    **Add** | **Syste(...)onary [47]** |     **?** | **10000** |       **NA** |       **NA** |       **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)onary [47] |     ? | 10000 | 58.96 ns | 0.924 ns | 0.864 ns | 0.0018 |      48 B |
|                 Update | Syste(...)onary [47] |     ? | 10000 | 54.59 ns | 1.138 ns | 1.355 ns | 0.0018 |      48 B |
| TryGetNonExistingValue | Syste(...)onary [47] |     ? | 10000 | 28.78 ns | 0.579 ns | 0.542 ns | 0.0009 |      24 B |
|         RemoveExisting | Syste(...)onary [47] |     ? | 10000 | 38.44 ns | 0.806 ns | 0.863 ns | 0.0009 |      24 B |
|      RemoveNonExisting | Syste(...)onary [47] |     ? | 10000 | 43.20 ns | 0.878 ns | 0.821 ns | 0.0009 |      24 B |

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
