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
|    **TryGetExistingValue** | **Syste(...)table [28]** |     **0** |   **-1** |     **?** |    **?** | **12.998 ns** | **0.0368 ns** | **0.0326 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |     **0** |   **-1** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 12.904 ns | 0.0235 ns | 0.0220 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |     0 |   -1 | 12.926 ns | 0.0331 ns | 0.0310 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  8.246 ns | 0.0042 ns | 0.0032 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  7.378 ns | 0.0281 ns | 0.0263 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |     0 |   -1 |  9.185 ns | 0.0137 ns | 0.0115 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |    **10** |    **9** |     **?** |    **?** | **19.798 ns** | **0.0855 ns** | **0.0758 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |    **10** |    **9** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |    10 |    9 | 12.899 ns | 0.0087 ns | 0.0073 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |    10 |    9 | 16.334 ns | 0.0487 ns | 0.0456 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |    10 |    9 |  8.248 ns | 0.0238 ns | 0.0222 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  7.342 ns | 0.0202 ns | 0.0179 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |    10 |    9 |  7.338 ns | 0.0059 ns | 0.0046 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |   **100** |   **99** |     **?** |    **?** | **17.955 ns** | **0.0394 ns** | **0.0369 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |   **100** |   **99** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |   100 |   99 | 12.934 ns | 0.0273 ns | 0.0256 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |   100 |   99 | 16.343 ns | 0.0762 ns | 0.0713 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |   100 |   99 |  8.255 ns | 0.0272 ns | 0.0254 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  7.345 ns | 0.0228 ns | 0.0213 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |   100 |   99 |  7.336 ns | 0.0076 ns | 0.0064 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** |  **1000** |  **999** |     **?** |    **?** | **17.944 ns** | **0.0184 ns** | **0.0163 ns** | **0.0003** |      **24 B** |
|    TryGetExistingValue | Syste(...)table [28] |  1000 |  999 |     ? |    ? | 18.060 ns | 0.0622 ns | 0.0552 ns | 0.0003 |      24 B |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** |  **1000** |  **999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|                    Add | Syste(...)table [28] |     ? |    ? |  1000 |  999 |        NA |        NA |        NA |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 12.901 ns | 0.0158 ns | 0.0140 ns |      - |         - |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 12.894 ns | 0.0060 ns | 0.0050 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 16.315 ns | 0.0211 ns | 0.0187 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? |  1000 |  999 | 16.306 ns | 0.0214 ns | 0.0179 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.258 ns | 0.0263 ns | 0.0233 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  8.254 ns | 0.0259 ns | 0.0242 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.357 ns | 0.0349 ns | 0.0326 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.329 ns | 0.0078 ns | 0.0061 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.336 ns | 0.0101 ns | 0.0084 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? |  1000 |  999 |  7.334 ns | 0.0166 ns | 0.0139 ns |      - |         - |
|    **TryGetExistingValue** | **Syste(...)table [28]** | **10000** | **9999** |     **?** |    **?** | **17.979 ns** | **0.0863 ns** | **0.0807 ns** | **0.0003** |      **24 B** |
|                    **Add** | **Syste(...)table [28]** |     **?** |    **?** | **10000** | **9999** |        **NA** |        **NA** |        **NA** |      **-** |         **-** |
|     AddBySquareBracket | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 12.917 ns | 0.0314 ns | 0.0278 ns |      - |         - |
|                 Update | Syste(...)table [28] |     ? |    ? | 10000 | 9999 | 16.302 ns | 0.0165 ns | 0.0129 ns |      - |         - |
| TryGetNonExistingValue | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  8.251 ns | 0.0231 ns | 0.0216 ns |      - |         - |
|         RemoveExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  7.344 ns | 0.0222 ns | 0.0196 ns |      - |         - |
|      RemoveNonExisting | Syste(...)table [28] |     ? |    ? | 10000 | 9999 |  7.332 ns | 0.0047 ns | 0.0042 ns |      - |         - |

Benchmarks with issues:
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=0, last=-1]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10, last=9]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=100, last=99]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=1000, last=999]
  HashtablePerformance.Add: DefaultJob [hashtable=Syste(...)table [28], next=10000, last=9999]
