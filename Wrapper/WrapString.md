Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                    Method |                  str |              wrapper |       Mean |     Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |-----------:|----------:|----------:|----------:|
|         **StringSetContains** | **028W(...)Z3AV [1000]** |                    **?** | **295.948 ns** | **0.4813 ns** | **0.4266 ns** |         **-** |
|  **StringDictionaryContains** | **7NFE(...)5DZR [1000]** |                    **?** | **293.178 ns** | **0.7347 ns** | **0.6873 ns** |         **-** |
|         **StringSetContains** |           **DFVL6M7YAA** |                    **?** |  **10.616 ns** | **0.0078 ns** | **0.0069 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |   **1.381 ns** | **0.0089 ns** | **0.0083 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |   1.374 ns | 0.0209 ns | 0.0196 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |   1.391 ns | 0.0046 ns | 0.0043 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |  97.175 ns | 0.0098 ns | 0.0082 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |  15.816 ns | 0.0038 ns | 0.0032 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 929.473 ns | 0.0820 ns | 0.0727 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |  15.880 ns | 0.0131 ns | 0.0123 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 931.095 ns | 0.0858 ns | 0.0670 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |  98.887 ns | 0.0279 ns | 0.0233 ns |         - |
|  **StringDictionaryContains** |  **F4U1(...)H5IG [100]** |                    **?** |  **36.834 ns** | **0.0090 ns** | **0.0080 ns** |         **-** |
|          **StringComparison** |  **G1LV(...)GWYF [100]** |                    **?** |   **1.389 ns** | **0.0059 ns** | **0.0056 ns** |         **-** |
|  **StringDictionaryContains** |           **JQ30U5DPFQ** |                    **?** |  **13.190 ns** | **0.0325 ns** | **0.0271 ns** |         **-** |
|          **StringComparison** | **KLRQ(...)GX2Z [1000]** |                    **?** |   **1.384 ns** | **0.0113 ns** | **0.0106 ns** |         **-** |
|          **StringComparison** |           **X244B9B0RL** |                    **?** |   **1.380 ns** | **0.0075 ns** | **0.0070 ns** |         **-** |
|         **StringSetContains** |  **YFZW(...)N5XU [100]** |                    **?** |  **33.688 ns** | **0.0030 ns** | **0.0027 ns** |         **-** |
