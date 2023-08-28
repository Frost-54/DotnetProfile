C# ImmutableHashSet vs HashSet performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                        Method |                  set |  next |         Mean |      Error |     StdDev |       Median |   Gen0 | Allocated |
|------------------------------ |--------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|----------:|
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |     **6.176 ns** |  **0.1390 ns** |  **0.1232 ns** |     **6.205 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |     3.258 ns |  0.1098 ns |  0.1540 ns |     3.180 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |     3.078 ns |  0.1055 ns |  0.1256 ns |     3.035 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |     2.994 ns |  0.0862 ns |  0.0764 ns |     2.995 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |     3.113 ns |  0.0955 ns |  0.1208 ns |     3.107 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |     **8.457 ns** |  **0.2051 ns** |  **0.2194 ns** |     **8.489 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |     7.739 ns |  0.2025 ns |  0.3031 ns |     7.764 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |     4.520 ns |  0.1272 ns |  0.1904 ns |     4.464 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |     5.776 ns |  0.1603 ns |  0.2496 ns |     5.774 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |     4.863 ns |  0.1295 ns |  0.2092 ns |     4.790 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |     **5.784 ns** |  **0.1309 ns** |  **0.1093 ns** |     **5.804 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |     7.187 ns |  0.1887 ns |  0.3100 ns |     7.176 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |     4.748 ns |  0.1204 ns |  0.1127 ns |     4.699 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |     5.876 ns |  0.1476 ns |  0.2210 ns |     5.862 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |     4.921 ns |  0.1397 ns |  0.1239 ns |     4.906 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |     **5.899 ns** |  **0.1290 ns** |  **0.1535 ns** |     **5.940 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |     6.009 ns |  0.1619 ns |  0.1515 ns |     6.015 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |     7.130 ns |  0.1841 ns |  0.2811 ns |     7.068 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |     6.737 ns |  0.1733 ns |  0.1447 ns |     6.693 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |     4.878 ns |  0.1388 ns |  0.2035 ns |     4.912 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |     4.504 ns |  0.1300 ns |  0.1216 ns |     4.482 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |     5.506 ns |  0.1526 ns |  0.2189 ns |     5.554 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |     4.885 ns |  0.1023 ns |  0.0907 ns |     4.875 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |     5.269 ns |  0.1477 ns |  0.2626 ns |     5.271 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |     5.517 ns |  0.1545 ns |  0.1445 ns |     5.511 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |     **5.989 ns** |  **0.1649 ns** |  **0.2888 ns** |     **5.947 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |     6.947 ns |  0.1791 ns |  0.2133 ns |     6.917 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |     4.965 ns |  0.1392 ns |  0.1906 ns |     4.955 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |     5.421 ns |  0.1226 ns |  0.1147 ns |     5.417 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |     4.808 ns |  0.1181 ns |  0.1105 ns |     4.807 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |    **91.607 ns** |  **1.8743 ns** |  **4.7023 ns** |    **90.004 ns** | **0.0039** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |    21.444 ns |  0.4693 ns |  0.6731 ns |    21.572 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |    17.778 ns |  0.3949 ns |  0.7121 ns |    17.519 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |    31.459 ns |  0.6643 ns |  0.7108 ns |    31.523 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |    31.535 ns |  0.6556 ns |  0.7287 ns |    31.568 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** |   **333.815 ns** |  **8.0167 ns** | **23.6373 ns** |   **333.008 ns** | **0.0124** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |    27.985 ns |  0.6010 ns |  1.4399 ns |    28.083 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |    29.215 ns |  0.6248 ns |  0.8341 ns |    29.331 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |    37.005 ns |  0.5621 ns |  0.5258 ns |    37.016 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 |   238.868 ns |  4.7586 ns |  5.2892 ns |   236.949 ns | 0.0081 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** |   **530.893 ns** | **10.3649 ns** | **14.5302 ns** |   **532.795 ns** | **0.0181** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |    33.802 ns |  0.6805 ns |  0.6366 ns |    33.704 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |    32.930 ns |  0.4046 ns |  0.3587 ns |    32.891 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |    44.592 ns |  0.9032 ns |  1.2363 ns |    44.602 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 |   437.349 ns |  8.4486 ns |  9.0399 ns |   436.450 ns | 0.0143 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** |   **770.081 ns** | **15.4599 ns** | **30.5163 ns** |   **770.357 ns** | **0.0248** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 |   744.124 ns | 14.1417 ns | 13.8891 ns |   744.608 ns | 0.0248 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |    40.704 ns |  0.4264 ns |  0.3780 ns |    40.774 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |    40.579 ns |  0.8491 ns |  0.9085 ns |    40.466 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |    42.374 ns |  0.8457 ns |  0.9049 ns |    42.400 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |    40.962 ns |  0.8452 ns |  1.4352 ns |    41.083 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |    47.846 ns |  0.5951 ns |  0.5276 ns |    47.856 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |    48.992 ns |  0.9068 ns |  0.8482 ns |    49.093 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 |   645.312 ns | 12.7185 ns | 22.9341 ns |   651.107 ns | 0.0210 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 |   659.765 ns |  8.2141 ns |  7.6835 ns |   658.881 ns | 0.0210 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **1,176.229 ns** | **22.6753 ns** | **22.2702 ns** | **1,179.078 ns** | **0.0324** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |    48.606 ns |  0.5792 ns |  0.4837 ns |    48.567 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |    48.650 ns |  0.9002 ns |  0.8420 ns |    48.499 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |    59.293 ns |  1.2183 ns |  2.7747 ns |    58.768 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 |   867.448 ns | 16.5422 ns | 27.6382 ns |   864.542 ns | 0.0296 |     776 B |
