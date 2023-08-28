Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |                  str |              wrapper |          Mean |      Error |     StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |--------------:|-----------:|-----------:|----------:|
|  **StringDictionaryContains** |  **33IJ(...)47K2 [100]** |                    **?** |    **40.3216 ns** |  **0.5293 ns** |  **0.4692 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **0.5389 ns** |  **0.0487 ns** |  **0.0455 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.5311 ns |  0.0477 ns |  0.0423 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.7359 ns |  0.0395 ns |  0.0370 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,007.4871 ns | 15.0243 ns | 13.3186 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   103.8915 ns |  2.0423 ns |  2.0973 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    18.4178 ns |  0.4066 ns |  0.4519 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   105.8357 ns |  2.0231 ns |  1.9869 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    18.6496 ns |  0.3975 ns |  0.4253 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   998.3162 ns | 16.7358 ns | 13.9751 ns |         - |
|  **StringDictionaryContains** |           **ENJ713JYXB** |                    **?** |    **12.3953 ns** |  **0.2765 ns** |  **0.2716 ns** |         **-** |
|         **StringSetContains** | **EUKA(...)OUG7 [1000]** |                    **?** |   **308.8373 ns** |  **5.6268 ns** |  **7.8880 ns** |         **-** |
|  **StringDictionaryContains** | **FOYZ(...)GC3E [1000]** |                    **?** |   **324.2588 ns** |  **5.9721 ns** |  **5.5863 ns** |         **-** |
|          **StringComparison** |           **I63NHG2MWQ** |                    **?** |     **0.5756 ns** |  **0.0555 ns** |  **0.0760 ns** |         **-** |
|         **StringSetContains** |  **KV0M(...)OQHD [100]** |                    **?** |    **38.1766 ns** |  **0.7577 ns** |  **0.8108 ns** |         **-** |
|         **StringSetContains** |           **NHSWLPF1HG** |                    **?** |    **11.9284 ns** |  **0.2674 ns** |  **0.2502 ns** |         **-** |
|          **StringComparison** | **TY2J(...)6E0T [1000]** |                    **?** |     **0.4886 ns** |  **0.0352 ns** |  **0.0329 ns** |         **-** |
|          **StringComparison** |  **UZQP(...)VSO6 [100]** |                    **?** |     **0.6446 ns** |  **0.0556 ns** |  **0.0882 ns** |         **-** |
