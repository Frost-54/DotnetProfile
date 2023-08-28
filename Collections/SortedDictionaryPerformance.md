C# SortedDictionary performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |           dictionary |     _ |  next |       Mean |     Error |     StdDev | Allocated |
|----------------------- |--------------------- |------ |------ |-----------:|----------:|-----------:|----------:|
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |     **0** |     **?** |   **8.975 ns** | **0.2232 ns** |  **0.3668 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |     **0** |         **NA** |        **NA** |         **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |     0 |  19.696 ns | 0.3723 ns |  0.3483 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |     0 |  19.509 ns | 0.3597 ns |  0.3365 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |     0 |   8.174 ns | 0.1985 ns |  0.1857 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |     0 |   7.284 ns | 0.1269 ns |  0.1059 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |     0 |   7.929 ns | 0.1982 ns |  0.3256 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |    **10** |     **?** |  **41.530 ns** | **0.5708 ns** |  **0.4767 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |    **10** |         **NA** |        **NA** |         **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |    10 |  67.554 ns | 1.3486 ns |  1.4430 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |    10 |  65.971 ns | 1.3427 ns |  1.3789 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |    10 |  64.433 ns | 0.9975 ns |  0.9330 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |    10 |  66.949 ns | 1.2172 ns |  1.1386 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |    10 |  80.325 ns | 1.6201 ns |  1.8008 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |   **100** |     **?** |  **69.299 ns** | **0.7748 ns** |  **0.7247 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |   **100** |         **NA** |        **NA** |         **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |   100 | 112.570 ns | 2.2476 ns |  3.9951 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |   100 | 103.980 ns | 1.5813 ns |  1.4018 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |   100 | 103.583 ns | 1.9469 ns |  1.8211 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |   100 | 120.045 ns | 1.7037 ns |  1.5937 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |   100 | 133.137 ns | 2.4664 ns |  2.1864 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** |  **1000** |     **?** | **101.831 ns** | **1.9791 ns** |  **1.9437 ns** |         **-** |
|    TryGetExistingValue | Syste(...)nt32] [72] |  1000 |     ? | 104.532 ns | 2.0808 ns |  3.1144 ns |         - |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** |  **1000** |         **NA** |        **NA** |         **NA** |         **-** |
|                    Add | Syste(...)nt32] [72] |     ? |  1000 |         NA |        NA |         NA |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 180.520 ns | 3.2117 ns |  3.0042 ns |         - |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? |  1000 | 192.147 ns | 3.8925 ns |  7.6834 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 195.861 ns | 3.9233 ns |  7.8353 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? |  1000 | 189.161 ns | 2.4247 ns |  1.8931 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 176.736 ns | 3.5874 ns |  7.0811 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? |  1000 | 186.051 ns | 3.6637 ns |  6.3197 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 217.501 ns | 4.3629 ns |  8.8132 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? |  1000 | 225.395 ns | 4.5410 ns | 10.8799 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 229.184 ns | 4.5424 ns |  6.7989 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? |  1000 | 226.006 ns | 4.5042 ns |  7.8888 ns |         - |
|    **TryGetExistingValue** | **Syste(...)nt32] [72]** | **10000** |     **?** | **166.151 ns** | **3.3833 ns** |  **7.8412 ns** |         **-** |
|                    **Add** | **Syste(...)nt32] [72]** |     **?** | **10000** |         **NA** |        **NA** |         **NA** |         **-** |
|     AddBySquareBracket | Syste(...)nt32] [72] |     ? | 10000 | 231.499 ns | 4.6910 ns | 10.3949 ns |         - |
|                 Update | Syste(...)nt32] [72] |     ? | 10000 | 236.162 ns | 6.7573 ns | 19.7114 ns |         - |
| TryGetNonExistingValue | Syste(...)nt32] [72] |     ? | 10000 | 200.719 ns | 3.7142 ns |  4.1283 ns |         - |
|         RemoveExisting | Syste(...)nt32] [72] |     ? | 10000 | 282.471 ns | 5.8210 ns | 17.1635 ns |         - |
|      RemoveNonExisting | Syste(...)nt32] [72] |     ? | 10000 | 291.314 ns | 5.8579 ns | 10.5631 ns |         - |

Benchmarks with issues:
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=0]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=100]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=1000]
  SortedDictionaryPerformance.Add: DefaultJob [dictionary=Syste(...)nt32] [72], next=10000]
