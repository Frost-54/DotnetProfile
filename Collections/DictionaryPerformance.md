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
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **3.602 ns** | **0.0104 ns** | **0.0092 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 4.982 ns | 0.0790 ns | 0.0739 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.784 ns | 0.0232 ns | 0.0194 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 5.195 ns | 0.0045 ns | 0.0040 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.782 ns | 0.0320 ns | 0.0300 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.765 ns | 0.0427 ns | 0.0399 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **4.740 ns** | **0.0028 ns** | **0.0025 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 4.980 ns | 0.0786 ns | 0.0735 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 5.713 ns | 0.0276 ns | 0.0245 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 6.056 ns | 0.0062 ns | 0.0055 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 4.260 ns | 0.0302 ns | 0.0267 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 4.296 ns | 0.0399 ns | 0.0333 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **4.651 ns** | **0.1309 ns** | **0.1286 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 4.944 ns | 0.0751 ns | 0.0702 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.708 ns | 0.0200 ns | 0.0177 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 6.088 ns | 0.0229 ns | 0.0214 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 4.258 ns | 0.0332 ns | 0.0294 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 4.259 ns | 0.0196 ns | 0.0183 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **4.695 ns** | **0.1104 ns** | **0.1032 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 4.722 ns | 0.0696 ns | 0.0651 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 4.976 ns | 0.0602 ns | 0.0563 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.006 ns | 0.0518 ns | 0.0485 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.823 ns | 0.0342 ns | 0.0286 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.796 ns | 0.0367 ns | 0.0325 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.061 ns | 0.0099 ns | 0.0088 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.200 ns | 0.0458 ns | 0.0429 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.214 ns | 0.0256 ns | 0.0214 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.241 ns | 0.0184 ns | 0.0163 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.229 ns | 0.0127 ns | 0.0119 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.271 ns | 0.0350 ns | 0.0327 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **4.675 ns** | **0.0521 ns** | **0.0487 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.021 ns | 0.0454 ns | 0.0425 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.715 ns | 0.0215 ns | 0.0201 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 6.083 ns | 0.0267 ns | 0.0250 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.266 ns | 0.0228 ns | 0.0213 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.234 ns | 0.0108 ns | 0.0090 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
