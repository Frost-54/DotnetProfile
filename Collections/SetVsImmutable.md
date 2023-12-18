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
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |   **3.628 ns** | **0.0138 ns** | **0.0129 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |   2.376 ns | 0.0014 ns | 0.0013 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |   2.378 ns | 0.0019 ns | 0.0018 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |   2.069 ns | 0.0015 ns | 0.0012 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |   2.075 ns | 0.0097 ns | 0.0091 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |   **3.618 ns** | **0.0025 ns** | **0.0020 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |   3.984 ns | 0.0117 ns | 0.0109 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |   3.117 ns | 0.0114 ns | 0.0107 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |   3.614 ns | 0.0022 ns | 0.0017 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |   3.616 ns | 0.0035 ns | 0.0031 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |   **3.617 ns** | **0.0034 ns** | **0.0027 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |   3.974 ns | 0.0116 ns | 0.0108 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |   3.122 ns | 0.0122 ns | 0.0115 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |   3.614 ns | 0.0018 ns | 0.0014 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |   3.616 ns | 0.0041 ns | 0.0034 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |   **3.625 ns** | **0.0131 ns** | **0.0122 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |   3.625 ns | 0.0135 ns | 0.0126 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   3.979 ns | 0.0140 ns | 0.0131 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   4.330 ns | 0.0067 ns | 0.0052 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.099 ns | 0.0126 ns | 0.0118 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.116 ns | 0.0138 ns | 0.0129 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   3.617 ns | 0.0027 ns | 0.0024 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   3.620 ns | 0.0112 ns | 0.0104 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.615 ns | 0.0022 ns | 0.0017 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.622 ns | 0.0098 ns | 0.0091 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |   **3.626 ns** | **0.0121 ns** | **0.0113 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |   4.012 ns | 0.0088 ns | 0.0068 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |   3.117 ns | 0.0118 ns | 0.0110 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |   3.616 ns | 0.0048 ns | 0.0038 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |   3.624 ns | 0.0105 ns | 0.0098 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |  **62.278 ns** | **0.2866 ns** | **0.2238 ns** | **0.0012** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |  16.162 ns | 0.0049 ns | 0.0041 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |  16.303 ns | 0.0295 ns | 0.0276 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |  24.047 ns | 0.0851 ns | 0.0754 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |  25.616 ns | 0.0240 ns | 0.0200 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** | **225.118 ns** | **0.5473 ns** | **0.4852 ns** | **0.0038** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |  23.504 ns | 0.0257 ns | 0.0240 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |  22.038 ns | 0.0246 ns | 0.0230 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |  30.369 ns | 0.0337 ns | 0.0316 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 | 159.928 ns | 0.8257 ns | 0.7723 ns | 0.0024 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** | **357.641 ns** | **1.4462 ns** | **1.3528 ns** | **0.0057** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |  28.589 ns | 0.0843 ns | 0.0789 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |  26.662 ns | 0.0097 ns | 0.0086 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |  34.528 ns | 0.0788 ns | 0.0699 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 | 274.865 ns | 0.9019 ns | 0.7995 ns | 0.0043 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** | **477.656 ns** | **1.6429 ns** | **1.5368 ns** | **0.0076** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 | 477.203 ns | 1.4622 ns | 1.1416 ns | 0.0076 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  34.681 ns | 0.0388 ns | 0.0363 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  34.013 ns | 0.0616 ns | 0.0546 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  32.118 ns | 0.2180 ns | 0.1933 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  32.102 ns | 0.0346 ns | 0.0323 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  40.190 ns | 0.0510 ns | 0.0477 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  40.053 ns | 0.0346 ns | 0.0306 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 399.210 ns | 1.3026 ns | 1.0877 ns | 0.0062 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 396.119 ns | 1.0400 ns | 0.9220 ns | 0.0062 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **661.015 ns** | **3.0805 ns** | **2.8815 ns** | **0.0105** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |  40.718 ns | 0.0449 ns | 0.0351 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |  39.148 ns | 0.0889 ns | 0.0742 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |  46.347 ns | 0.0512 ns | 0.0479 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 | 571.150 ns | 1.6200 ns | 1.3528 ns | 0.0086 |     776 B |
