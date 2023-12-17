C# Dictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |     Mean |     Error |    StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |---------:|----------:|----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **2.791 ns** | **0.0116 ns** | **0.0109 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 5.244 ns | 0.0122 ns | 0.0114 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.677 ns | 0.0164 ns | 0.0154 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 4.332 ns | 0.0024 ns | 0.0020 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.068 ns | 0.0013 ns | 0.0012 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.073 ns | 0.0087 ns | 0.0077 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **3.631 ns** | **0.0122 ns** | **0.0114 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 5.584 ns | 0.0091 ns | 0.0076 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 5.376 ns | 0.0104 ns | 0.0092 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 4.647 ns | 0.0109 ns | 0.0102 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 3.624 ns | 0.0090 ns | 0.0080 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 3.618 ns | 0.0067 ns | 0.0056 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **3.616 ns** | **0.0038 ns** | **0.0032 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 5.567 ns | 0.0093 ns | 0.0087 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.629 ns | 0.0090 ns | 0.0085 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 4.654 ns | 0.0136 ns | 0.0128 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 3.623 ns | 0.0106 ns | 0.0100 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 3.616 ns | 0.0024 ns | 0.0020 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **3.626 ns** | **0.0117 ns** | **0.0110 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 3.626 ns | 0.0140 ns | 0.0131 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.549 ns | 0.0106 ns | 0.0099 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.196 ns | 0.0407 ns | 0.0381 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.699 ns | 0.0135 ns | 0.0119 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.757 ns | 0.0109 ns | 0.0102 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 4.648 ns | 0.0120 ns | 0.0112 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 4.651 ns | 0.0196 ns | 0.0174 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.622 ns | 0.0110 ns | 0.0103 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.623 ns | 0.0088 ns | 0.0082 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.623 ns | 0.0099 ns | 0.0092 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.615 ns | 0.0020 ns | 0.0018 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **3.629 ns** | **0.0117 ns** | **0.0103 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.367 ns | 0.0374 ns | 0.0350 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.699 ns | 0.0096 ns | 0.0089 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 4.643 ns | 0.0028 ns | 0.0027 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 3.614 ns | 0.0027 ns | 0.0021 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 3.615 ns | 0.0040 ns | 0.0033 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
