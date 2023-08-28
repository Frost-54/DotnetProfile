C# SortedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |       Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |-----------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **9.146 ns** | **0.0016 ns** | **0.0015 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  20.637 ns | 0.0653 ns | 0.0611 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  20.579 ns | 0.0205 ns | 0.0182 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   9.242 ns | 0.0248 ns | 0.0232 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   9.292 ns | 0.1438 ns | 0.1345 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   9.287 ns | 0.0210 ns | 0.0196 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **42.492 ns** | **0.0039 ns** | **0.0034 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  65.497 ns | 0.0797 ns | 0.0706 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  64.922 ns | 0.3141 ns | 0.2939 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  65.947 ns | 0.0823 ns | 0.0770 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  61.267 ns | 0.0145 ns | 0.0121 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  75.962 ns | 0.0081 ns | 0.0076 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **75.115 ns** | **0.0368 ns** | **0.0345 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 | 110.296 ns | 0.1719 ns | 0.1608 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 | 110.865 ns | 0.0368 ns | 0.0344 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 | 110.911 ns | 0.0393 ns | 0.0348 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 | 114.752 ns | 0.0597 ns | 0.0558 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 | 127.522 ns | 0.0253 ns | 0.0211 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** | **107.568 ns** | **0.0302 ns** | **0.0267 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? | 107.731 ns | 0.0172 ns | 0.0160 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.589 ns | 0.0174 ns | 0.0163 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.588 ns | 0.0145 ns | 0.0121 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.876 ns | 0.0241 ns | 0.0225 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.896 ns | 0.0198 ns | 0.0175 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.924 ns | 0.0163 ns | 0.0144 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.927 ns | 0.0251 ns | 0.0222 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 206.002 ns | 0.1069 ns | 0.1000 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 206.052 ns | 0.3130 ns | 0.2928 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 219.079 ns | 0.1116 ns | 0.0989 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 219.103 ns | 0.0823 ns | 0.0770 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **150.434 ns** | **0.0562 ns** | **0.0498 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 223.269 ns | 0.1780 ns | 0.1665 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 234.008 ns | 0.0375 ns | 0.0351 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 233.978 ns | 0.0301 ns | 0.0267 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 259.874 ns | 0.1168 ns | 0.1035 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 272.711 ns | 0.0399 ns | 0.0354 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
