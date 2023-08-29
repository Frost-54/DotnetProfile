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
|          **StringComparison** |  **07FB(...)HHDW [100]** |                    **?** |     **0.4377 ns** | **0.0104 ns** | **0.0097 ns** |         **-** |
|  **StringDictionaryContains** |  **13S9(...)8OQX [100]** |                    **?** |    **40.5695 ns** | **0.0599 ns** | **0.0531 ns** |         **-** |
|         **StringSetContains** |  **26XW(...)C5T4 [100]** |                    **?** |    **39.5724 ns** | **0.1225 ns** | **0.1146 ns** |         **-** |
|          **StringComparison** |           **8FC5WENCGR** |                    **?** |     **0.4169 ns** | **0.0051 ns** | **0.0045 ns** |         **-** |
|  **StringDictionaryContains** | **D8RB(...)S5BT [1000]** |                    **?** |   **371.0414 ns** | **0.0982 ns** | **0.0766 ns** |         **-** |
|         **StringSetContains** |           **DGANGVK1AZ** |                    **?** |     **9.7753 ns** | **0.0090 ns** | **0.0079 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **0.4115 ns** | **0.0057 ns** | **0.0053 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.4150 ns | 0.0062 ns | 0.0058 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.6659 ns | 0.0530 ns | 0.0496 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    14.2761 ns | 0.0110 ns | 0.0103 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   108.1519 ns | 0.0105 ns | 0.0082 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,067.7988 ns | 0.1591 ns | 0.1328 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   109.7045 ns | 0.0134 ns | 0.0112 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    15.5759 ns | 0.0049 ns | 0.0041 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 1,070.0429 ns | 0.0836 ns | 0.0698 ns |         - |
|         **StringSetContains** | **JXLC(...)3JYM [1000]** |                    **?** |   **370.4386 ns** | **0.0838 ns** | **0.0700 ns** |         **-** |
|          **StringComparison** | **PEBY(...)PIV0 [1000]** |                    **?** |     **0.4096 ns** | **0.0024 ns** | **0.0023 ns** |         **-** |
|  **StringDictionaryContains** |           **Y9ZXZUA13R** |                    **?** |    **10.2743 ns** | **0.0114 ns** | **0.0095 ns** |         **-** |
