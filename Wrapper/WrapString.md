Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                    Method |                  str |              wrapper |        Mean |     Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |------------:|----------:|----------:|----------:|
|  **StringDictionaryContains** | **80GR(...)2067 [1000]** |                    **?** | **241.3521 ns** | **0.7487 ns** | **0.6637 ns** |         **-** |
|          **StringComparison** |           **BC63NGKWNJ** |                    **?** |   **0.6246 ns** | **0.0099 ns** | **0.0093 ns** |         **-** |
|         **StringSetContains** |  **DP59(...)I3UF [100]** |                    **?** |  **26.7579 ns** | **0.0975 ns** | **0.0912 ns** |         **-** |
|          **StringComparison** | **DQ1K(...)N4Y3 [1000]** |                    **?** |   **0.7254 ns** | **0.0218 ns** | **0.0182 ns** |         **-** |
|         **StringSetContains** | **DWTM(...)PIAM [1000]** |                    **?** | **243.1116 ns** | **0.3427 ns** | **0.3205 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |   **0.6408 ns** | **0.0088 ns** | **0.0082 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |   0.6195 ns | 0.0092 ns | 0.0077 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |   0.6974 ns | 0.0299 ns | 0.0280 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 777.6032 ns | 0.1895 ns | 0.1680 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |  10.2503 ns | 0.0119 ns | 0.0106 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |  79.4401 ns | 0.0255 ns | 0.0213 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |  79.0112 ns | 0.0384 ns | 0.0321 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |  10.3593 ns | 0.0329 ns | 0.0308 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 775.5604 ns | 0.2167 ns | 0.1921 ns |         - |
|  **StringDictionaryContains** |  **JEIM(...)ZHZB [100]** |                    **?** |  **31.3988 ns** | **0.0972 ns** | **0.0862 ns** |         **-** |
|  **StringDictionaryContains** |           **K4VRYLD4BQ** |                    **?** |   **9.1853 ns** | **0.0041 ns** | **0.0034 ns** |         **-** |
|         **StringSetContains** |           **OPAHE821ZQ** |                    **?** |   **7.3549 ns** | **0.0310 ns** | **0.0290 ns** |         **-** |
|          **StringComparison** |  **UQ7B(...)71YR [100]** |                    **?** |   **0.7211 ns** | **0.0134 ns** | **0.0119 ns** |         **-** |
