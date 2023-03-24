Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                    Method |                  str |              wrapper |         Mean |       Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |-------------:|------------:|----------:|----------:|
|         **StringSetContains** | **0237(...)UWQW [1000]** |                    **?** |   **366.942 ns** | **161.9127 ns** | **8.8750 ns** |         **-** |
|          **StringComparison** |  **3DRO(...)LDVB [100]** |                    **?** |     **1.608 ns** |   **0.3633 ns** | **0.0199 ns** |         **-** |
|         **StringSetContains** |           **4O9KZGF1XP** |                    **?** |    **11.761 ns** |   **2.0119 ns** | **0.1103 ns** |         **-** |
|         **StringSetContains** |  **6K08(...)RLP2 [100]** |                    **?** |    **40.609 ns** |  **35.4158 ns** | **1.9413 ns** |         **-** |
|  **StringDictionaryContains** |  **BTDU(...)FI1B [100]** |                    **?** |    **40.107 ns** |   **3.8979 ns** | **0.2137 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **1.602 ns** |   **0.5849 ns** | **0.0321 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     1.599 ns |   0.5125 ns | 0.0281 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     1.576 ns |   0.5532 ns | 0.0303 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   115.457 ns |  20.3622 ns | 1.1161 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,090.590 ns | 123.6075 ns | 6.7753 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    25.120 ns |   1.4531 ns | 0.0796 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 1,108.237 ns |  18.6540 ns | 1.0225 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    15.722 ns |   1.1721 ns | 0.0642 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   122.316 ns |  17.0553 ns | 0.9349 ns |         - |
|  **StringDictionaryContains** | **GEZ9(...)S551 [1000]** |                    **?** |   **340.456 ns** |  **65.0530 ns** | **3.5658 ns** |         **-** |
|          **StringComparison** |           **IUV12BTFU4** |                    **?** |     **1.518 ns** |   **0.7370 ns** | **0.0404 ns** |         **-** |
|  **StringDictionaryContains** |           **UMHQVG6R5C** |                    **?** |    **12.974 ns** |   **3.8035 ns** | **0.2085 ns** |         **-** |
|          **StringComparison** | **YASP(...)44D1 [1000]** |                    **?** |     **1.597 ns** |   **0.3192 ns** | **0.0175 ns** |         **-** |
