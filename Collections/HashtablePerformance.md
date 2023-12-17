C# Hashtable performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                 Method |            hashtable |     a |    b |  next | last |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------- |--------------------- |------ |----- |------ |----- |----------:|----------:|----------:|-------:|----------:|
|    **TryGetExistingValue** | **Syste(...)table [28]** |     **0** |   **-1** |     **?** |    **?** | **12.283 ns** | **0.0243 ns** | **0.0228 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |     **0** |   **-1** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 12.920 ns | 0.0232 ns | 0.0217 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 12.916 ns | 0.0237 ns | 0.0221 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  8.237 ns | 0.0081 ns | 0.0063 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  7.368 ns | 0.0212 ns | 0.0198 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  9.201 ns | 0.0216 ns | 0.0202 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |    **10** |    **9** |     **?** |    **?** | **17.531 ns** | **0.0664 ns** | **0.0621 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |    **10** |    **9** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |    10 |    9 | 12.917 ns | 0.0280 ns | 0.0262 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |    10 |    9 | 16.294 ns | 0.0088 ns | 0.0069 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |    10 |    9 |  8.258 ns | 0.0261 ns | 0.0244 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  7.344 ns | 0.0200 ns | 0.0187 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  7.339 ns | 0.0223 ns | 0.0198 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |   **100** |   **99** |     **?** |    **?** | **17.572 ns** | **0.0253 ns** | **0.0211 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |   **100** |   **99** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |   100 |   99 | 12.912 ns | 0.0246 ns | 0.0230 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |   100 |   99 | 16.300 ns | 0.0064 ns | 0.0056 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.254 ns | 0.0241 ns | 0.0225 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  7.348 ns | 0.0264 ns | 0.0247 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  7.329 ns | 0.0065 ns | 0.0054 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |  **1000** |  **999** |     **?** |    **?** | **17.646 ns** | **0.1045 ns** | **0.0978 ns** | **0.0003** |      **24 B** |
|    TryGetExistingValue | Syste(...)table [28] |  1000 |  999 |     ? |    ? | 17.797 ns | 0.0779 ns | 0.0729 ns | 0.0003 |      24 B |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |  **1000** |  **999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)table [28] |     ? |    ? |  1000 |  999 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 12.913 ns | 0.0215 ns | 0.0201 ns |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 12.909 ns | 0.0208 ns | 0.0195 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 16.323 ns | 0.0509 ns | 0.0476 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 16.312 ns | 0.0467 ns | 0.0390 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.246 ns | 0.0191 ns | 0.0170 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.263 ns | 0.0237 ns | 0.0221 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.345 ns | 0.0257 ns | 0.0240 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.331 ns | 0.0060 ns | 0.0053 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.342 ns | 0.0223 ns | 0.0209 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.344 ns | 0.0248 ns | 0.0232 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** | **10000** | **9999** |     **?** |    **?** | **17.631 ns** | **0.0847 ns** | **0.0751 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** | **10000** | **9999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 12.897 ns | 0.0089 ns | 0.0074 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 16.344 ns | 0.0514 ns | 0.0481 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  8.254 ns | 0.0220 ns | 0.0195 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  7.344 ns | 0.0252 ns | 0.0235 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  7.323 ns | 0.0053 ns | 0.0041 ns |      - |         - |

Benchmarks with issues:
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=0, last=-1]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10, last=9]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=100, last=99]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10000, last=9999]
