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
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **9.160 ns** | **0.0019 ns** | **0.0015 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  20.640 ns | 0.0685 ns | 0.0641 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  20.577 ns | 0.0620 ns | 0.0580 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   9.245 ns | 0.0303 ns | 0.0284 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   9.122 ns | 0.0034 ns | 0.0029 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   9.127 ns | 0.0023 ns | 0.0019 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **42.461 ns** | **0.0083 ns** | **0.0073 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  64.924 ns | 0.5106 ns | 0.4776 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  65.251 ns | 0.0748 ns | 0.0700 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  65.728 ns | 0.0316 ns | 0.0247 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  61.911 ns | 0.0111 ns | 0.0099 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  75.461 ns | 0.0147 ns | 0.0137 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **75.108 ns** | **0.0473 ns** | **0.0442 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 | 110.551 ns | 0.1037 ns | 0.0970 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 | 110.721 ns | 0.0424 ns | 0.0376 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 | 110.865 ns | 0.0069 ns | 0.0058 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 | 115.126 ns | 0.0525 ns | 0.0439 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 | 127.451 ns | 0.0249 ns | 0.0221 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** | **107.531 ns** | **0.0090 ns** | **0.0084 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? | 107.713 ns | 0.0113 ns | 0.0100 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |        **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |        NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.616 ns | 0.0121 ns | 0.0101 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 177.659 ns | 0.0593 ns | 0.0525 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.880 ns | 0.0210 ns | 0.0175 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 188.806 ns | 0.0154 ns | 0.0136 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.901 ns | 0.0160 ns | 0.0133 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 188.903 ns | 0.0135 ns | 0.0119 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 206.562 ns | 0.0318 ns | 0.0282 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 206.490 ns | 0.0520 ns | 0.0486 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 219.012 ns | 0.1896 ns | 0.1681 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 219.301 ns | 0.0494 ns | 0.0462 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **150.396 ns** | **0.0258 ns** | **0.0228 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |        **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 223.369 ns | 0.1555 ns | 0.1454 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 234.003 ns | 0.0586 ns | 0.0548 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 234.062 ns | 0.0134 ns | 0.0104 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 260.591 ns | 0.0500 ns | 0.0467 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 272.517 ns | 0.0356 ns | 0.0333 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
