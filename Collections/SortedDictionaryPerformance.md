C# SortedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |       Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |-----------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **7.391 ns** | **0.0008 ns** | **0.0007 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  18.411 ns | 0.0012 ns | 0.0011 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  18.414 ns | 0.0020 ns | 0.0018 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   7.729 ns | 0.0008 ns | 0.0006 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   7.413 ns | 0.0007 ns | 0.0006 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   7.412 ns | 0.0016 ns | 0.0014 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **36.511 ns** | **0.0045 ns** | **0.0038 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  57.215 ns | 0.0059 ns | 0.0052 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  57.218 ns | 0.0080 ns | 0.0071 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  56.892 ns | 0.0051 ns | 0.0040 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  60.199 ns | 0.0385 ns | 0.0360 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  74.110 ns | 0.0152 ns | 0.0127 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **65.610 ns** | **0.0056 ns** | **0.0050 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 |  96.043 ns | 0.0113 ns | 0.0100 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 |  96.030 ns | 0.0089 ns | 0.0075 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 |  95.693 ns | 0.0125 ns | 0.0111 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 | 112.799 ns | 0.0116 ns | 0.0103 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 | 124.964 ns | 0.0418 ns | 0.0370 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** |  **94.707 ns** | **0.0058 ns** | **0.0048 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? |  94.732 ns | 0.0118 ns | 0.0105 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 164.395 ns | 0.0375 ns | 0.0333 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 165.658 ns | 1.1396 ns | 1.0660 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 173.714 ns | 0.0168 ns | 0.0149 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 175.454 ns | 0.1060 ns | 0.0885 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 162.912 ns | 0.0125 ns | 0.0097 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 162.730 ns | 0.0172 ns | 0.0144 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 202.586 ns | 0.0232 ns | 0.0206 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 202.819 ns | 0.0191 ns | 0.0170 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 215.595 ns | 0.0128 ns | 0.0119 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 215.610 ns | 0.0211 ns | 0.0187 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **145.049 ns** | **0.0218 ns** | **0.0193 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 206.574 ns | 0.2538 ns | 0.2374 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 213.689 ns | 0.0759 ns | 0.0710 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 202.146 ns | 0.0267 ns | 0.0250 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 255.910 ns | 0.0287 ns | 0.0239 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 269.041 ns | 0.0437 ns | 0.0408 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
