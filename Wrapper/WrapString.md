Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                    Method |                  str |              wrapper |          Mean |     Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |--------------:|----------:|----------:|----------:|
|          **StringComparison** |           **6BREMHXEGW** |                    **?** |     **0.4174 ns** | **0.0055 ns** | **0.0049 ns** |         **-** |
|          **StringComparison** |  **8NJ1(...)DOHO [100]** |                    **?** |     **1.2480 ns** | **0.0014 ns** | **0.0013 ns** |         **-** |
|  **StringDictionaryContains** | **C3NO(...)2HNV [1000]** |                    **?** |   **371.1087 ns** | **0.0627 ns** | **0.0556 ns** |         **-** |
|         **StringSetContains** | **CXQA(...)WZ1H [1000]** |                    **?** |   **372.9437 ns** | **0.2217 ns** | **0.1965 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **0.4074 ns** | **0.0031 ns** | **0.0029 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.4204 ns | 0.0056 ns | 0.0052 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.4222 ns | 0.0076 ns | 0.0071 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,069.4988 ns | 0.3443 ns | 0.3052 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   108.3228 ns | 0.0167 ns | 0.0148 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    14.3043 ns | 0.0184 ns | 0.0163 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   108.2983 ns | 0.0165 ns | 0.0146 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    14.1883 ns | 0.0027 ns | 0.0024 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 1,070.1459 ns | 0.1901 ns | 0.1778 ns |         - |
|         **StringSetContains** |  **GN8A(...)G53L [100]** |                    **?** |    **39.1272 ns** | **0.1421 ns** | **0.1260 ns** |         **-** |
|  **StringDictionaryContains** |  **MI5K(...)TKUF [100]** |                    **?** |    **37.1249 ns** | **0.0385 ns** | **0.0360 ns** |         **-** |
|          **StringComparison** | **UJ7H(...)JVYX [1000]** |                    **?** |     **0.4173 ns** | **0.0075 ns** | **0.0070 ns** |         **-** |
|  **StringDictionaryContains** |           **W96488OFEY** |                    **?** |    **10.3009 ns** | **0.0284 ns** | **0.0265 ns** |         **-** |
|         **StringSetContains** |           **X4C10D0U50** |                    **?** |    **10.9599 ns** | **0.0081 ns** | **0.0072 ns** |         **-** |
