C# SortedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |       Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |-----------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **7.615 ns** | **0.0061 ns** | **0.0057 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  16.388 ns | 0.0123 ns | 0.0116 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  16.390 ns | 0.0115 ns | 0.0107 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   7.610 ns | 0.0014 ns | 0.0013 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   7.390 ns | 0.0223 ns | 0.0198 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   7.409 ns | 0.0205 ns | 0.0192 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **32.977 ns** | **0.0116 ns** | **0.0097 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  50.616 ns | 0.0325 ns | 0.0304 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  50.606 ns | 0.0274 ns | 0.0243 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  50.799 ns | 0.0244 ns | 0.0204 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  46.948 ns | 0.0853 ns | 0.0756 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  57.511 ns | 0.0762 ns | 0.0713 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **57.796 ns** | **0.0195 ns** | **0.0152 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 |  84.606 ns | 0.0484 ns | 0.0453 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 |  84.552 ns | 0.0673 ns | 0.0629 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 |  84.921 ns | 0.0545 ns | 0.0510 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 |  86.343 ns | 0.1616 ns | 0.1512 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 |  95.841 ns | 0.1265 ns | 0.1121 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** |  **82.467 ns** | **0.0501 ns** | **0.0468 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? |  83.058 ns | 0.0364 ns | 0.0323 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 136.603 ns | 0.0998 ns | 0.0885 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 136.501 ns | 0.0267 ns | 0.0223 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 145.253 ns | 0.1028 ns | 0.0962 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 145.158 ns | 0.0291 ns | 0.0272 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 145.513 ns | 0.1194 ns | 0.1059 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 145.503 ns | 0.0868 ns | 0.0769 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 154.885 ns | 0.4404 ns | 0.4120 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 154.814 ns | 0.3404 ns | 0.3184 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 164.646 ns | 0.3617 ns | 0.3383 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 164.420 ns | 0.4527 ns | 0.4235 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **115.866 ns** | **0.0541 ns** | **0.0479 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 171.823 ns | 0.0991 ns | 0.0927 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 179.877 ns | 0.1085 ns | 0.1015 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 180.145 ns | 0.0574 ns | 0.0479 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 194.082 ns | 0.3249 ns | 0.3039 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 203.587 ns | 0.2332 ns | 0.1947 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
