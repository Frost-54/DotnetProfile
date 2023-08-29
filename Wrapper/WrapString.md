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
|         **StringSetContains** |  **44P0(...)YVDA [100]** |                    **?** |    **38.3429 ns** | **0.0609 ns** | **0.0540 ns** |         **-** |
|          **StringComparison** |  **5YHH(...)FIEE [100]** |                    **?** |     **0.4107 ns** | **0.0026 ns** | **0.0023 ns** |         **-** |
|  **StringDictionaryContains** | **AF16(...)GYJI [1000]** |                    **?** |   **369.7832 ns** | **0.1640 ns** | **0.1454 ns** |         **-** |
|          **StringComparison** | **DG3A(...)36A7 [1000]** |                    **?** |     **0.4125 ns** | **0.0031 ns** | **0.0029 ns** |         **-** |
|         **WrapperComparison** |                    **?** | **Dotne(...)apper [40]** |     **0.4098 ns** | **0.0038 ns** | **0.0034 ns** |         **-** |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     0.4057 ns | 0.0024 ns | 0.0022 ns |         - |
|         WrapperComparison |                    ? | Dotne(...)apper [40] |     1.7597 ns | 0.0068 ns | 0.0064 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |    18.0638 ns | 0.0179 ns | 0.0149 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] |   111.7562 ns | 0.0189 ns | 0.0158 ns |         - |
|        WrapperSetContains |                    ? | Dotne(...)apper [40] | 1,069.3980 ns | 0.1123 ns | 0.0996 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |    14.3640 ns | 0.0040 ns | 0.0035 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] | 1,068.5958 ns | 0.1794 ns | 0.1590 ns |         - |
| WrapperDictionaryContains |                    ? | Dotne(...)apper [40] |   108.1073 ns | 0.0172 ns | 0.0144 ns |         - |
|  **StringDictionaryContains** |  **ELC3(...)6MF3 [100]** |                    **?** |    **43.9153 ns** | **0.0069 ns** | **0.0061 ns** |         **-** |
|         **StringSetContains** | **F6PM(...)FKFH [1000]** |                    **?** |   **371.8284 ns** | **0.1042 ns** | **0.0924 ns** |         **-** |
|  **StringDictionaryContains** |           **LF9G6O0KN9** |                    **?** |    **12.5416 ns** | **0.0225 ns** | **0.0199 ns** |         **-** |
|          **StringComparison** |           **VMXHMEK324** |                    **?** |     **0.4083 ns** | **0.0024 ns** | **0.0023 ns** |         **-** |
|         **StringSetContains** |           **Z7W1W719MI** |                    **?** |     **9.7726 ns** | **0.0064 ns** | **0.0057 ns** |         **-** |
