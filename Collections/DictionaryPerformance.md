C# Dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |     Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |---------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **3.488 ns** | **0.0088 ns** | **0.0082 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 5.919 ns | 0.0089 ns | 0.0083 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.669 ns | 0.0008 ns | 0.0007 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 5.115 ns | 0.0076 ns | 0.0071 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.243 ns | 0.0012 ns | 0.0011 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.241 ns | 0.0021 ns | 0.0019 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **6.259 ns** | **0.0018 ns** | **0.0015 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 5.923 ns | 0.0111 ns | 0.0098 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 5.703 ns | 0.0005 ns | 0.0004 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 6.093 ns | 0.0028 ns | 0.0025 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 4.533 ns | 0.0025 ns | 0.0023 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 4.535 ns | 0.0017 ns | 0.0015 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **6.265 ns** | **0.0050 ns** | **0.0042 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 5.916 ns | 0.0078 ns | 0.0070 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.749 ns | 0.0019 ns | 0.0015 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 6.095 ns | 0.0030 ns | 0.0028 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 4.541 ns | 0.0021 ns | 0.0020 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 4.534 ns | 0.0012 ns | 0.0011 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **6.260 ns** | **0.0020 ns** | **0.0019 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 6.258 ns | 0.0029 ns | 0.0026 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.909 ns | 0.0059 ns | 0.0052 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.917 ns | 0.0075 ns | 0.0070 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 6.137 ns | 0.0013 ns | 0.0011 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 6.135 ns | 0.0033 ns | 0.0031 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.090 ns | 0.0023 ns | 0.0021 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 6.093 ns | 0.0017 ns | 0.0015 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.531 ns | 0.0014 ns | 0.0012 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.536 ns | 0.0016 ns | 0.0015 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.535 ns | 0.0026 ns | 0.0023 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 4.533 ns | 0.0015 ns | 0.0014 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **6.259 ns** | **0.0020 ns** | **0.0019 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.920 ns | 0.0073 ns | 0.0068 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.701 ns | 0.0008 ns | 0.0007 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 6.084 ns | 0.0027 ns | 0.0025 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.531 ns | 0.0016 ns | 0.0014 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.534 ns | 0.0015 ns | 0.0012 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
