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
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |     **0** |     **?** | **2.793 ns** | **0.0185 ns** | **0.0164 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |     **0** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |     0 | 5.426 ns | 0.0457 ns | 0.0428 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |     0 | 5.672 ns | 0.0201 ns | 0.0188 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |     0 | 4.332 ns | 0.0039 ns | 0.0030 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |     0 | 2.070 ns | 0.0014 ns | 0.0013 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |     0 | 2.072 ns | 0.0033 ns | 0.0029 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |    **10** |     **?** | **3.624 ns** | **0.0047 ns** | **0.0039 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |    **10** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |    10 | 5.440 ns | 0.0787 ns | 0.0697 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |    10 | 5.675 ns | 0.0096 ns | 0.0081 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |    10 | 4.647 ns | 0.0135 ns | 0.0126 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |    10 | 3.620 ns | 0.0089 ns | 0.0079 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |    10 | 3.624 ns | 0.0123 ns | 0.0115 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |   **100** |     **?** | **3.619 ns** | **0.0112 ns** | **0.0104 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |   **100** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |   100 | 5.559 ns | 0.0097 ns | 0.0090 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |   100 | 5.682 ns | 0.0118 ns | 0.0110 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |   100 | 4.639 ns | 0.0024 ns | 0.0019 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |   100 | 3.624 ns | 0.0153 ns | 0.0143 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |   100 | 3.625 ns | 0.0121 ns | 0.0114 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** |  **1000** |     **?** | **3.619 ns** | **0.0047 ns** | **0.0039 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [66] |  1000 |     ? | 3.617 ns | 0.0043 ns | 0.0034 ns |         - |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** |  **1000** |       **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [66] |     ? |  1000 |       NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 6.346 ns | 0.0076 ns | 0.0068 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? |  1000 | 5.246 ns | 0.0235 ns | 0.0220 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.709 ns | 0.0084 ns | 0.0079 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? |  1000 | 5.761 ns | 0.0109 ns | 0.0102 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 4.653 ns | 0.0153 ns | 0.0143 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? |  1000 | 4.658 ns | 0.0192 ns | 0.0170 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.616 ns | 0.0027 ns | 0.0025 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.622 ns | 0.0102 ns | 0.0095 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.627 ns | 0.0133 ns | 0.0118 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? |  1000 | 3.617 ns | 0.0097 ns | 0.0086 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [66]** | **10000** |     **?** | **3.629 ns** | **0.0078 ns** | **0.0069 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [66]** |     **?** | **10000** |       **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [66] |     ? | 10000 | 5.335 ns | 0.0337 ns | 0.0316 ns |         - |
|                 Update | Syste(...)nt32] [66] |     ? | 10000 | 5.640 ns | 0.0096 ns | 0.0085 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [66] |     ? | 10000 | 4.649 ns | 0.0120 ns | 0.0112 ns |         - |
|         RemoveExisting | Syste(...)nt32] [66] |     ? | 10000 | 4.083 ns | 0.0210 ns | 0.0197 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [66] |     ? | 10000 | 3.623 ns | 0.0101 ns | 0.0095 ns |         - |

Benchmarks with issues:
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=0]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=100]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=1000]
  DictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [66], next=10000]
