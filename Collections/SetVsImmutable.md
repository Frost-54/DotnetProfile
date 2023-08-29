C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                        Method |                  set |  next |       Mean |     Error |    StdDev |     Median |   Gen0 | Allocated |
|------------------------------ |--------------------- |------ |-----------:|----------:|----------:|-----------:|-------:|----------:|
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |   **4.724 ns** | **0.0417 ns** | **0.0348 ns** |   **4.720 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |   2.688 ns | 0.0272 ns | 0.0255 ns |   2.700 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |   2.601 ns | 0.0363 ns | 0.0322 ns |   2.603 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |   3.608 ns | 0.0101 ns | 0.0094 ns |   3.610 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |   3.583 ns | 0.0122 ns | 0.0114 ns |   3.581 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |   **4.742 ns** | **0.0355 ns** | **0.0277 ns** |   **4.736 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |   4.547 ns | 0.0048 ns | 0.0045 ns |   4.546 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |   3.838 ns | 0.0113 ns | 0.0100 ns |   3.838 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |   4.128 ns | 0.0037 ns | 0.0033 ns |   4.128 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |   3.768 ns | 0.0282 ns | 0.0264 ns |   3.768 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |   **4.750 ns** | **0.0488 ns** | **0.0433 ns** |   **4.754 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |   5.079 ns | 0.0044 ns | 0.0042 ns |   5.080 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |   3.819 ns | 0.0291 ns | 0.0273 ns |   3.804 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |   4.137 ns | 0.0065 ns | 0.0061 ns |   4.136 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |   3.778 ns | 0.0225 ns | 0.0210 ns |   3.774 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |   **4.684 ns** | **0.0457 ns** | **0.0405 ns** |   **4.687 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |   4.567 ns | 0.0862 ns | 0.0764 ns |   4.553 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   6.938 ns | 0.0106 ns | 0.0094 ns |   6.938 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   5.082 ns | 0.0039 ns | 0.0032 ns |   5.081 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   5.916 ns | 0.4071 ns | 1.2004 ns |   6.626 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.841 ns | 0.0207 ns | 0.0193 ns |   3.843 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.133 ns | 0.0073 ns | 0.0068 ns |   4.131 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.135 ns | 0.0134 ns | 0.0125 ns |   4.132 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.796 ns | 0.0362 ns | 0.0338 ns |   3.794 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.829 ns | 0.0240 ns | 0.0224 ns |   3.829 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |   **4.794 ns** | **0.0755 ns** | **0.0706 ns** |   **4.809 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |   5.964 ns | 0.0074 ns | 0.0069 ns |   5.965 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |   3.848 ns | 0.0139 ns | 0.0130 ns |   3.851 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |   4.134 ns | 0.0060 ns | 0.0056 ns |   4.135 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |   3.777 ns | 0.0332 ns | 0.0311 ns |   3.783 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |  **80.313 ns** | **0.4710 ns** | **0.4406 ns** |  **80.314 ns** | **0.0041** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |  17.407 ns | 0.0122 ns | 0.0102 ns |  17.411 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |  17.425 ns | 0.0155 ns | 0.0145 ns |  17.425 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |  30.120 ns | 0.0493 ns | 0.0461 ns |  30.123 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |  29.562 ns | 0.0341 ns | 0.0285 ns |  29.571 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** | **281.547 ns** | **2.3653 ns** | **2.2125 ns** | **281.191 ns** | **0.0129** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |  27.247 ns | 0.0077 ns | 0.0072 ns |  27.245 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |  25.970 ns | 0.0131 ns | 0.0122 ns |  25.966 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |  41.013 ns | 0.0944 ns | 0.0883 ns |  41.001 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 | 197.096 ns | 2.1211 ns | 1.9841 ns | 197.212 ns | 0.0086 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** | **439.928 ns** | **2.6881 ns** | **2.5145 ns** | **440.030 ns** | **0.0196** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |  34.223 ns | 0.0101 ns | 0.0089 ns |  34.226 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |  33.440 ns | 0.0059 ns | 0.0052 ns |  33.441 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |  46.696 ns | 0.0176 ns | 0.0165 ns |  46.700 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 | 335.240 ns | 2.7023 ns | 2.5277 ns | 335.234 ns | 0.0153 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** | **592.712 ns** | **5.2498 ns** | **4.9107 ns** | **590.239 ns** | **0.0257** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 | 617.750 ns | 1.2132 ns | 1.0755 ns | 617.690 ns | 0.0257 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  42.226 ns | 0.0063 ns | 0.0059 ns |  42.224 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  41.904 ns | 0.0072 ns | 0.0064 ns |  41.903 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.387 ns | 0.0019 ns | 0.0016 ns |  40.387 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.365 ns | 0.0065 ns | 0.0058 ns |  40.364 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.126 ns | 0.0292 ns | 0.0273 ns |  54.127 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.828 ns | 0.0501 ns | 0.0468 ns |  54.817 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 479.159 ns | 2.1098 ns | 1.9735 ns | 479.469 ns | 0.0219 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 483.244 ns | 1.9733 ns | 1.8458 ns | 482.990 ns | 0.0219 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **857.630 ns** | **1.6790 ns** | **1.5705 ns** | **857.433 ns** | **0.0353** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |  51.699 ns | 0.0113 ns | 0.0106 ns |  51.698 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |  50.360 ns | 0.0091 ns | 0.0085 ns |  50.359 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |  63.340 ns | 0.0594 ns | 0.0556 ns |  63.342 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 | 686.977 ns | 3.5627 ns | 3.3325 ns | 687.157 ns | 0.0305 |     776 B |
