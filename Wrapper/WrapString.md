Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |                  str |              wrapper |          Mean |     Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |--------------:|----------:|----------:|----------:|
|          **StringComparison** |  **0O4R(...)08YZ [100]** |                    **?** |     **0.4271 ns** | **0.0051 ns** | **0.0045 ns** |         **-** |
|  **StringDictionaryContains** |           **43CL27IPSE** |                    **?** |    **11.8617 ns** | **0.0168 ns** | **0.0140 ns** |         **-** |
|          **StringComparison** | **4MF0(...)TTQ7 [1000]** |                    **?** |     **0.4134 ns** | **0.0028 ns** | **0.0024 ns** |         **-** |
|          **StringComparison** |           **6ID5LQNFAI** |                    **?** |     **0.4222 ns** | **0.0080 ns** | **0.0075 ns** |         **-** |
|         **StringSetContains** |           **B5IPT7N302** |                    **?** |     **9.7514 ns** | **0.0088 ns** | **0.0078 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **0.4158 ns** | **0.0046 ns** | **0.0043 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.6849 ns | 0.0546 ns | 0.0484 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.4144 ns | 0.0054 ns | 0.0050 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    13.9587 ns | 0.0057 ns | 0.0048 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,069.3657 ns | 0.1921 ns | 0.1703 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   110.0915 ns | 0.0280 ns | 0.0248 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    14.1629 ns | 0.0028 ns | 0.0023 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 1,070.1253 ns | 0.1735 ns | 0.1538 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   108.2430 ns | 0.0183 ns | 0.0153 ns |         - |
|         **StringSetContains** |  **EADV(...)UWFT [100]** |                    **?** |    **39.4488 ns** | **0.0080 ns** | **0.0075 ns** |         **-** |
|  **StringDictionaryContains** | **JCWU(...)68Z5 [1000]** |                    **?** |   **371.0612 ns** | **0.0641 ns** | **0.0536 ns** |         **-** |
|         **StringSetContains** | **K6QG(...)P6BM [1000]** |                    **?** |   **369.0600 ns** | **0.0727 ns** | **0.0644 ns** |         **-** |
|  **StringDictionaryContains** |  **PVLP(...)GCQO [100]** |                    **?** |    **36.9058 ns** | **0.0165 ns** | **0.0146 ns** |         **-** |
