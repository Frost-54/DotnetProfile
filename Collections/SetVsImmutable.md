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
|                        **SetAdd** | **Syste(...)nt32] [50]** |     **0** |   **5.824 ns** | **0.0047 ns** | **0.0044 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |     0 |   2.709 ns | 0.0077 ns | 0.0072 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |     0 |   2.626 ns | 0.0150 ns | 0.0140 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |     0 |   3.587 ns | 0.0157 ns | 0.0146 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |     0 |   3.602 ns | 0.0154 ns | 0.0144 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |    **10** |   **4.717 ns** | **0.0264 ns** | **0.0247 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |    10 |   5.082 ns | 0.0055 ns | 0.0052 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |    10 |   3.975 ns | 0.0101 ns | 0.0085 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |    10 |   4.128 ns | 0.0101 ns | 0.0090 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |    10 |   3.775 ns | 0.0235 ns | 0.0220 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |   **100** |   **4.731 ns** | **0.0745 ns** | **0.0661 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] |   100 |   5.081 ns | 0.0073 ns | 0.0068 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |   100 |   3.824 ns | 0.0070 ns | 0.0065 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |   100 |   4.138 ns | 0.0082 ns | 0.0077 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |   100 |   3.770 ns | 0.0147 ns | 0.0137 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** |  **1000** |   **4.728 ns** | **0.0295 ns** | **0.0261 ns** |      **-** |         **-** |
|                        SetAdd | Syste(...)nt32] [50] |  1000 |   4.788 ns | 0.1155 ns | 0.1081 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   5.082 ns | 0.0047 ns | 0.0044 ns |      - |         - |
|               SetFindExisting | Syste(...)nt32] [50] |  1000 |   5.082 ns | 0.0066 ns | 0.0062 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   4.775 ns | 0.0016 ns | 0.0015 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] |  1000 |   3.823 ns | 0.0087 ns | 0.0068 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.240 ns | 0.0096 ns | 0.0089 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] |  1000 |   4.131 ns | 0.0049 ns | 0.0041 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.849 ns | 0.0321 ns | 0.0301 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] |  1000 |   3.797 ns | 0.0211 ns | 0.0198 ns |      - |         - |
|                        **SetAdd** | **Syste(...)nt32] [50]** | **10000** |   **4.806 ns** | **0.0636 ns** | **0.0531 ns** |      **-** |         **-** |
|               SetFindExisting | Syste(...)nt32] [50] | 10000 |   5.079 ns | 0.0036 ns | 0.0032 ns |      - |         - |
|            SetFindNonexisting | Syste(...)nt32] [50] | 10000 |   3.846 ns | 0.0191 ns | 0.0179 ns |      - |         - |
|          SetRemoveNonexisting | Syste(...)nt32] [50] | 10000 |   4.128 ns | 0.0077 ns | 0.0068 ns |      - |         - |
|             SetRemoveExisting | Syste(...)nt32] [50] | 10000 |   3.853 ns | 0.0347 ns | 0.0325 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |     **0** |  **80.073 ns** | **0.4505 ns** | **0.4214 ns** | **0.0041** |     **104 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |     0 |  17.440 ns | 0.0125 ns | 0.0111 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |     0 |  17.447 ns | 0.0114 ns | 0.0106 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |     0 |  30.145 ns | 0.0351 ns | 0.0329 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |     0 |  30.049 ns | 0.0271 ns | 0.0254 ns |      - |         - |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |    **10** | **288.086 ns** | **0.6753 ns** | **0.6316 ns** | **0.0129** |     **328 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |    10 |  26.851 ns | 0.0026 ns | 0.0022 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |    10 |  25.863 ns | 0.0090 ns | 0.0080 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |    10 |  38.486 ns | 0.0724 ns | 0.0642 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |    10 | 198.475 ns | 1.4070 ns | 1.1749 ns | 0.0086 |     216 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |   **100** | **430.382 ns** | **3.4311 ns** | **3.2095 ns** | **0.0196** |     **496 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |   100 |  34.221 ns | 0.0109 ns | 0.0102 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |   100 |  32.922 ns | 0.0082 ns | 0.0068 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |   100 |  46.732 ns | 0.0166 ns | 0.0156 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |   100 | 326.799 ns | 2.6912 ns | 2.5173 ns | 0.0153 |     384 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** |  **1000** | **601.174 ns** | **1.8890 ns** | **1.6745 ns** | **0.0257** |     **664 B** |
|               ImmutableSetAdd | Syste(...)nt32] [61] |  1000 | 598.465 ns | 2.0419 ns | 1.9100 ns | 0.0257 |     664 B |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  41.962 ns | 0.0071 ns | 0.0063 ns |      - |         - |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] |  1000 |  42.926 ns | 0.0038 ns | 0.0035 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.423 ns | 0.0065 ns | 0.0061 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] |  1000 |  40.441 ns | 0.0323 ns | 0.0286 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.260 ns | 0.0319 ns | 0.0298 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] |  1000 |  54.027 ns | 0.0428 ns | 0.0401 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 470.437 ns | 4.3525 ns | 4.0713 ns | 0.0219 |     552 B |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] |  1000 | 475.238 ns | 2.8750 ns | 2.5486 ns | 0.0219 |     552 B |
|               **ImmutableSetAdd** | **Syste(...)nt32] [61]** | **10000** | **854.787 ns** | **3.6590 ns** | **3.4227 ns** | **0.0353** |     **888 B** |
|      ImmutableSetFindExisting | Syste(...)nt32] [61] | 10000 |  51.684 ns | 0.0183 ns | 0.0162 ns |      - |         - |
|   ImmutableSetFindNonexisting | Syste(...)nt32] [61] | 10000 |  50.313 ns | 0.0118 ns | 0.0110 ns |      - |         - |
| ImmutableSetRemoveNonexisting | Syste(...)nt32] [61] | 10000 |  63.171 ns | 0.0430 ns | 0.0381 ns |      - |         - |
|    ImmutableSetRemoveExisting | Syste(...)nt32] [61] | 10000 | 682.944 ns | 2.0853 ns | 1.8486 ns | 0.0305 |     776 B |
