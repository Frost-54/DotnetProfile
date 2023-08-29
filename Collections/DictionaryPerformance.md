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
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **3.591 ns** | **0.0100 ns** | **0.0094 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 4.936 ns | 0.0226 ns | 0.0176 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.051 ns | 0.0228 ns | 0.0213 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 5.199 ns | 0.0075 ns | 0.0070 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.802 ns | 0.0305 ns | 0.0285 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.781 ns | 0.0252 ns | 0.0235 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **4.656 ns** | **0.1319 ns** | **0.1570 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 5.093 ns | 0.0658 ns | 0.0616 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 6.381 ns | 0.0054 ns | 0.0042 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 6.067 ns | 0.0101 ns | 0.0090 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 4.270 ns | 0.0247 ns | 0.0231 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 4.243 ns | 0.0391 ns | 0.0365 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **4.713 ns** | **0.0564 ns** | **0.0527 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 5.097 ns | 0.0502 ns | 0.0470 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.688 ns | 0.0118 ns | 0.0105 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 6.067 ns | 0.0133 ns | 0.0124 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 4.276 ns | 0.0163 ns | 0.0145 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 4.278 ns | 0.0261 ns | 0.0244 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **4.625 ns** | **0.1328 ns** | **0.1726 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 4.677 ns | 0.1313 ns | 0.1459 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 4.961 ns | 0.0237 ns | 0.0210 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.073 ns | 0.0357 ns | 0.0334 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.830 ns | 0.0241 ns | 0.0188 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.845 ns | 0.0411 ns | 0.0321 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.070 ns | 0.0100 ns | 0.0093 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.066 ns | 0.0070 ns | 0.0066 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.258 ns | 0.0099 ns | 0.0082 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.312 ns | 0.0490 ns | 0.0458 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.238 ns | 0.0230 ns | 0.0215 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.258 ns | 0.0271 ns | 0.0253 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **4.524 ns** | **0.0933 ns** | **0.0873 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.071 ns | 0.0288 ns | 0.0269 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.706 ns | 0.0244 ns | 0.0204 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 6.095 ns | 0.0312 ns | 0.0292 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.257 ns | 0.0414 ns | 0.0367 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.233 ns | 0.0203 ns | 0.0180 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
