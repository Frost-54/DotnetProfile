C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                        Method |                  set |  next |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------ |--------------------- |------ |-----------:|----------:|----------:|-------:|----------:|
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |   **4.566 ns** | **0.0555 ns** | **0.0464 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |   2.697 ns | 0.0330 ns | 0.0293 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |   2.620 ns | 0.0220 ns | 0.0206 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |   3.572 ns | 0.0103 ns | 0.0092 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |   3.568 ns | 0.0093 ns | 0.0087 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |   **4.778 ns** | **0.0686 ns** | **0.0608 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |   5.077 ns | 0.0066 ns | 0.0062 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |   3.858 ns | 0.0065 ns | 0.0061 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |   4.133 ns | 0.0072 ns | 0.0067 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |   3.855 ns | 0.0230 ns | 0.0215 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |   **4.801 ns** | **0.1302 ns** | **0.1279 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |   5.097 ns | 0.0049 ns | 0.0044 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |   3.854 ns | 0.0040 ns | 0.0034 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |   4.124 ns | 0.0109 ns | 0.0102 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |   3.790 ns | 0.0144 ns | 0.0135 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |   **4.748 ns** | **0.0685 ns** | **0.0607 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |   4.854 ns | 0.0976 ns | 0.0865 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   5.077 ns | 0.0050 ns | 0.0044 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   5.079 ns | 0.0046 ns | 0.0043 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.831 ns | 0.0093 ns | 0.0083 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.857 ns | 0.0122 ns | 0.0114 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.124 ns | 0.0119 ns | 0.0112 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.115 ns | 0.0059 ns | 0.0052 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.818 ns | 0.0264 ns | 0.0246 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.816 ns | 0.0397 ns | 0.0372 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |   **4.803 ns** | **0.1169 ns** | **0.1093 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |   5.659 ns | 0.0177 ns | 0.0165 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |   3.858 ns | 0.0082 ns | 0.0077 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |   4.132 ns | 0.0076 ns | 0.0071 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |   3.803 ns | 0.0395 ns | 0.0370 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |  **78.485 ns** | **0.6650 ns** | **0.5895 ns** | **0.0041** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |  17.445 ns | 0.0126 ns | 0.0118 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |  19.279 ns | 0.0117 ns | 0.0110 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |  29.596 ns | 0.0222 ns | 0.0197 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |  30.672 ns | 0.0357 ns | 0.0334 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** | **282.510 ns** | **1.6178 ns** | **1.5133 ns** | **0.0129** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |  27.248 ns | 0.0050 ns | 0.0047 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |  25.486 ns | 0.0068 ns | 0.0064 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |  37.918 ns | 0.0688 ns | 0.0643 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 | 200.328 ns | 1.2587 ns | 1.1774 ns | 0.0086 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** | **433.658 ns** | **2.0482 ns** | **1.9158 ns** | **0.0196** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |  34.641 ns | 0.0082 ns | 0.0077 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |  33.540 ns | 0.0064 ns | 0.0060 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |  46.329 ns | 0.0207 ns | 0.0194 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 | 336.309 ns | 1.7395 ns | 1.6271 ns | 0.0153 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** | **603.211 ns** | **3.4829 ns** | **3.2579 ns** | **0.0257** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 | 601.907 ns | 2.8345 ns | 2.6514 ns | 0.0257 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  41.906 ns | 0.0099 ns | 0.0088 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  41.911 ns | 0.0058 ns | 0.0054 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.391 ns | 0.0085 ns | 0.0075 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.004 ns | 0.0088 ns | 0.0078 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.879 ns | 0.0314 ns | 0.0294 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.957 ns | 0.0782 ns | 0.0732 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 481.977 ns | 2.4135 ns | 2.2576 ns | 0.0219 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 475.143 ns | 4.0338 ns | 3.7732 ns | 0.0219 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **851.891 ns** | **5.0120 ns** | **4.6883 ns** | **0.0353** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |  51.690 ns | 0.0105 ns | 0.0093 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |  50.351 ns | 0.0104 ns | 0.0098 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |  65.792 ns | 0.0410 ns | 0.0384 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 | 696.085 ns | 4.7361 ns | 4.4302 ns | 0.0305 |     776 B |
