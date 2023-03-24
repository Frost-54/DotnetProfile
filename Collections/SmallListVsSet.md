C# List vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|            Method | Size |                  set | doesNotExist |                 list |       Mean |       Error |     StdDev |   Gen0 | Allocated |
|------------------ |----- |--------------------- |------------- |--------------------- |-----------:|------------:|-----------:|-------:|----------:|
|    **FindSpeedOfSet** |    **0** | **Syste(...)nt32] [50]** |            **0** |                    **?** |   **5.333 ns** |   **0.3365 ns** |  **0.0184 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |    **0** | **Syste(...)nt32] [50]** |           **10** |                    **?** |   **5.406 ns** |   **0.2716 ns** |  **0.0149 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |    **0** | **Syste(...)nt32] [50]** |           **20** |                    **?** |   **5.186 ns** |   **0.6271 ns** |  **0.0344 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |    **0** |                    **?** |            **0** | **Syste(...)nt32] [47]** |   **7.606 ns** |   **2.3378 ns** |  **0.1281 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |    **0** |                    **?** |           **10** | **Syste(...)nt32] [47]** |  **10.277 ns** |   **0.1389 ns** |  **0.0076 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |    **0** |                    **?** |           **20** | **Syste(...)nt32] [47]** |  **14.704 ns** |   **1.5733 ns** |  **0.0862 ns** |      **-** |         **-** |
|      **MemoryOfList** |    **0** |                    **?** |            **?** |                    **?** |  **14.537 ns** |  **10.3011 ns** |  **0.5646 ns** | **0.0017** |      **32 B** |
|       MemoryOfSet |    0 |                    ? |            ? |                    ? |  12.970 ns |   9.7615 ns |  0.5351 ns | 0.0034 |      64 B |
| InsertSpeedOfList |    0 |                    ? |            ? |                    ? |  37.183 ns |  14.3112 ns |  0.7844 ns | 0.0038 |      72 B |
|  InsertSpeedOfSet |    0 |                    ? |            ? |                    ? |  76.736 ns |  26.6188 ns |  1.4591 ns | 0.0089 |     168 B |
|    **FindSpeedOfSet** |   **10** | **Syste(...)nt32] [50]** |            **0** |                    **?** |   **5.396 ns** |   **0.2650 ns** |  **0.0145 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |   **10** | **Syste(...)nt32] [50]** |           **10** |                    **?** |   **5.409 ns** |   **1.7867 ns** |  **0.0979 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |   **10** | **Syste(...)nt32] [50]** |           **20** |                    **?** |   **5.466 ns** |   **0.1609 ns** |  **0.0088 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **10** |                    **?** |            **0** | **Syste(...)nt32] [47]** |   **8.026 ns** |   **1.0217 ns** |  **0.0560 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **10** |                    **?** |           **10** | **Syste(...)nt32] [47]** |  **10.227 ns** |   **0.3332 ns** |  **0.0183 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **10** |                    **?** |           **20** | **Syste(...)nt32] [47]** |  **14.069 ns** |   **1.8189 ns** |  **0.0997 ns** |      **-** |         **-** |
|      **MemoryOfList** |   **10** |                    **?** |            **?** |                    **?** |  **29.484 ns** |  **22.6792 ns** |  **1.2431 ns** | **0.0051** |      **96 B** |
|       MemoryOfSet |   10 |                    ? |            ? |                    ? |  78.686 ns | 151.0755 ns |  8.2810 ns | 0.0157 |     296 B |
| InsertSpeedOfList |   10 |                    ? |            ? |                    ? | 156.750 ns |  23.9606 ns |  1.3134 ns | 0.0114 |     216 B |
|  InsertSpeedOfSet |   10 |                    ? |            ? |                    ? | 389.012 ns |  77.3223 ns |  4.2383 ns | 0.0353 |     664 B |
|    **FindSpeedOfSet** |   **20** | **Syste(...)nt32] [50]** |            **0** |                    **?** |   **5.421 ns** |   **0.6470 ns** |  **0.0355 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |   **20** | **Syste(...)nt32] [50]** |           **10** |                    **?** |   **5.411 ns** |   **1.3007 ns** |  **0.0713 ns** |      **-** |         **-** |
|    **FindSpeedOfSet** |   **20** | **Syste(...)nt32] [50]** |           **20** |                    **?** |   **5.374 ns** |   **0.9715 ns** |  **0.0532 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **20** |                    **?** |            **0** | **Syste(...)nt32] [47]** |   **7.997 ns** |   **1.0540 ns** |  **0.0578 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **20** |                    **?** |           **10** | **Syste(...)nt32] [47]** |  **10.032 ns** |   **3.0238 ns** |  **0.1657 ns** |      **-** |         **-** |
|   **FindSpeedOfList** |   **20** |                    **?** |           **20** | **Syste(...)nt32] [47]** |  **13.923 ns** |   **2.2902 ns** |  **0.1255 ns** |      **-** |         **-** |
|      **MemoryOfList** |   **20** |                    **?** |            **?** |                    **?** |  **31.136 ns** |  **31.9126 ns** |  **1.7492 ns** | **0.0073** |     **136 B** |
|       MemoryOfSet |   20 |                    ? |            ? |                    ? |  99.768 ns | 119.5415 ns |  6.5525 ns | 0.0261 |     488 B |
| InsertSpeedOfList |   20 |                    ? |            ? |                    ? | 209.835 ns |  98.6488 ns |  5.4073 ns | 0.0196 |     368 B |
|  InsertSpeedOfSet |   20 |                    ? |            ? |                    ? | 676.390 ns | 256.8587 ns | 14.0793 ns | 0.0696 |    1312 B |