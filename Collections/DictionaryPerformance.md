C# Dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |     Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |---------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **3.603 ns** | **0.0044 ns** | **0.0041 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 5.082 ns | 0.0616 ns | 0.0576 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.063 ns | 0.0439 ns | 0.0410 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 5.201 ns | 0.0031 ns | 0.0027 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.791 ns | 0.0483 ns | 0.0452 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.779 ns | 0.0141 ns | 0.0118 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **4.551 ns** | **0.1040 ns** | **0.0973 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 5.096 ns | 0.0403 ns | 0.0357 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 5.857 ns | 0.1519 ns | 0.1689 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 6.060 ns | 0.0119 ns | 0.0111 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 4.240 ns | 0.0400 ns | 0.0374 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 4.268 ns | 0.0226 ns | 0.0212 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **4.673 ns** | **0.1108 ns** | **0.1036 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 5.098 ns | 0.0223 ns | 0.0209 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.683 ns | 0.0152 ns | 0.0135 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 6.062 ns | 0.0086 ns | 0.0080 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 4.282 ns | 0.0327 ns | 0.0306 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 4.255 ns | 0.0217 ns | 0.0192 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **6.152 ns** | **0.0014 ns** | **0.0013 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 4.523 ns | 0.1062 ns | 0.0994 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.003 ns | 0.0774 ns | 0.0724 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.077 ns | 0.0502 ns | 0.0445 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.691 ns | 0.0720 ns | 0.0673 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.814 ns | 0.0338 ns | 0.0282 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.062 ns | 0.0107 ns | 0.0100 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.073 ns | 0.0080 ns | 0.0075 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.294 ns | 0.0235 ns | 0.0197 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.257 ns | 0.0277 ns | 0.0245 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.293 ns | 0.0228 ns | 0.0202 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.278 ns | 0.0286 ns | 0.0267 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **4.615 ns** | **0.1085 ns** | **0.0906 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.088 ns | 0.0460 ns | 0.0408 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.711 ns | 0.0324 ns | 0.0271 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 6.067 ns | 0.0076 ns | 0.0071 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.272 ns | 0.0165 ns | 0.0155 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.259 ns | 0.0326 ns | 0.0305 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
