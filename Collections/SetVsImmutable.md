C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                        Method |                  set |  next |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------ |--------------------- |------ |-----------:|----------:|----------:|-------:|----------:|
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |   **3.724 ns** | **0.0071 ns** | **0.0059 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |   2.396 ns | 0.0026 ns | 0.0020 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |   2.378 ns | 0.0032 ns | 0.0025 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |   2.072 ns | 0.0079 ns | 0.0070 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |   2.074 ns | 0.0102 ns | 0.0095 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |   **3.616 ns** | **0.0025 ns** | **0.0019 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |   3.969 ns | 0.0156 ns | 0.0146 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |   3.122 ns | 0.0125 ns | 0.0117 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |   3.620 ns | 0.0123 ns | 0.0115 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |   3.621 ns | 0.0112 ns | 0.0099 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |   **3.623 ns** | **0.0111 ns** | **0.0104 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |   3.967 ns | 0.0082 ns | 0.0064 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |   3.122 ns | 0.0139 ns | 0.0130 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |   3.624 ns | 0.0115 ns | 0.0108 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |   3.617 ns | 0.0031 ns | 0.0024 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |   **3.627 ns** | **0.0140 ns** | **0.0131 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |   3.624 ns | 0.0085 ns | 0.0075 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   3.986 ns | 0.0157 ns | 0.0140 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   3.958 ns | 0.0147 ns | 0.0137 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.098 ns | 0.0106 ns | 0.0094 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.120 ns | 0.0126 ns | 0.0118 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   3.620 ns | 0.0100 ns | 0.0093 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   3.620 ns | 0.0078 ns | 0.0069 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.624 ns | 0.0105 ns | 0.0098 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.626 ns | 0.0107 ns | 0.0100 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |   **3.617 ns** | **0.0030 ns** | **0.0028 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |   3.951 ns | 0.0150 ns | 0.0133 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |   3.124 ns | 0.0202 ns | 0.0189 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |   3.622 ns | 0.0110 ns | 0.0103 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |   3.616 ns | 0.0040 ns | 0.0031 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |  **61.936 ns** | **0.2944 ns** | **0.2610 ns** | **0.0012** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |  16.223 ns | 0.0319 ns | 0.0298 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |  17.066 ns | 0.0251 ns | 0.0210 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |  24.030 ns | 0.0404 ns | 0.0359 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |  23.981 ns | 0.0404 ns | 0.0358 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** | **223.524 ns** | **0.7568 ns** | **0.6709 ns** | **0.0038** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |  23.585 ns | 0.0270 ns | 0.0253 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |  22.033 ns | 0.0101 ns | 0.0094 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |  30.319 ns | 0.0532 ns | 0.0498 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 | 158.249 ns | 1.0216 ns | 0.9556 ns | 0.0024 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** | **354.658 ns** | **1.9991 ns** | **1.8699 ns** | **0.0057** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |  28.527 ns | 0.0883 ns | 0.0826 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |  26.881 ns | 0.0243 ns | 0.0216 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |  34.335 ns | 0.0654 ns | 0.0612 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 | 275.157 ns | 0.9984 ns | 0.9339 ns | 0.0043 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** | **474.716 ns** | **2.2374 ns** | **2.0929 ns** | **0.0076** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 | 477.368 ns | 1.6931 ns | 1.5837 ns | 0.0076 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  33.863 ns | 0.0411 ns | 0.0385 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  33.910 ns | 0.0312 ns | 0.0261 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  32.222 ns | 0.3955 ns | 0.3302 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  33.397 ns | 0.3655 ns | 0.3240 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  39.731 ns | 0.0682 ns | 0.0637 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  39.490 ns | 0.0669 ns | 0.0626 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 396.463 ns | 0.8781 ns | 0.8213 ns | 0.0062 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 406.569 ns | 2.0207 ns | 1.8902 ns | 0.0062 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **658.998 ns** | **1.8598 ns** | **1.7396 ns** | **0.0105** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |  40.806 ns | 0.0616 ns | 0.0481 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |  39.904 ns | 0.0274 ns | 0.0229 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |  46.739 ns | 0.0365 ns | 0.0324 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 | 569.255 ns | 2.3655 ns | 2.2126 ns | 0.0086 |     776 B |
