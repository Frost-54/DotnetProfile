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
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **7.617 ns** | **0.0091 ns** | **0.0085 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  16.389 ns | 0.0159 ns | 0.0149 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  16.392 ns | 0.0185 ns | 0.0164 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   7.617 ns | 0.0076 ns | 0.0071 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   7.374 ns | 0.0218 ns | 0.0204 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   7.324 ns | 0.0080 ns | 0.0075 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **32.985 ns** | **0.0275 ns** | **0.0257 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  50.603 ns | 0.0354 ns | 0.0331 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  50.537 ns | 0.0213 ns | 0.0200 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  50.915 ns | 0.0382 ns | 0.0339 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  46.943 ns | 0.0692 ns | 0.0648 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  57.464 ns | 0.0933 ns | 0.0779 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **57.911 ns** | **0.0450 ns** | **0.0421 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 |  84.676 ns | 0.0626 ns | 0.0586 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 |  84.646 ns | 0.0732 ns | 0.0684 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 |  85.545 ns | 0.0634 ns | 0.0562 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 |  86.190 ns | 0.0270 ns | 0.0239 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 |  96.520 ns | 0.1833 ns | 0.1715 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** |  **82.452 ns** | **0.0260 ns** | **0.0217 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? |  82.501 ns | 0.0567 ns | 0.0530 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 136.629 ns | 0.1305 ns | 0.1220 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 136.657 ns | 0.1132 ns | 0.1059 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 145.242 ns | 0.0993 ns | 0.0929 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 145.121 ns | 0.0489 ns | 0.0409 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 145.581 ns | 0.1318 ns | 0.1168 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 145.518 ns | 0.0268 ns | 0.0237 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 154.847 ns | 0.3930 ns | 0.3676 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 154.572 ns | 0.0574 ns | 0.0449 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 164.332 ns | 0.3193 ns | 0.2987 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 164.306 ns | 0.2341 ns | 0.2190 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **115.912 ns** | **0.0475 ns** | **0.0397 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 171.353 ns | 0.1286 ns | 0.1074 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 179.848 ns | 0.1115 ns | 0.0931 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 180.227 ns | 0.1526 ns | 0.1428 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 194.124 ns | 0.3750 ns | 0.3507 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 203.778 ns | 0.4627 ns | 0.4101 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
