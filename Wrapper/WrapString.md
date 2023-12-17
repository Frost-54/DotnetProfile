Will wrapping a string in a struct be slower c#
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                    Method |              wrapper |                  str |        Mean |     Error |    StdDev | Allocated |
|-------------------------- |--------------------- |--------------------- |------------:|----------:|----------:|----------:|
|         **WrapperComparison** | **Dotne(...)apper [40]** |                    **?** |   **0.7609 ns** | **0.0118 ns** | **0.0105 ns** |         **-** |
|         WrapperComparison | Dotne(...)apper [40] |                    ? |   0.6417 ns | 0.0068 ns | 0.0064 ns |         - |
|         WrapperComparison | Dotne(...)apper [40] |                    ? |   0.6144 ns | 0.0035 ns | 0.0031 ns |         - |
|        WrapperSetContains | Dotne(...)apper [40] |                    ? | 775.6001 ns | 0.2495 ns | 0.2212 ns |         - |
|        WrapperSetContains | Dotne(...)apper [40] |                    ? |  77.9804 ns | 0.0726 ns | 0.0643 ns |         - |
|        WrapperSetContains | Dotne(...)apper [40] |                    ? |  11.5612 ns | 0.0323 ns | 0.0302 ns |         - |
| WrapperDictionaryContains | Dotne(...)apper [40] |                    ? |  10.3426 ns | 0.0117 ns | 0.0098 ns |         - |
| WrapperDictionaryContains | Dotne(...)apper [40] |                    ? |  79.6265 ns | 0.0495 ns | 0.0439 ns |         - |
| WrapperDictionaryContains | Dotne(...)apper [40] |                    ? | 774.5733 ns | 0.1699 ns | 0.1506 ns |         - |
|         **StringSetContains** |                    **?** | **EMJO(...)TNV2 [1000]** | **240.3529 ns** | **0.0724 ns** | **0.0642 ns** |         **-** |
|  **StringDictionaryContains** |                    **?** |  **NBNF(...)OTGV [100]** |  **26.9658 ns** | **0.0542 ns** | **0.0453 ns** |         **-** |
|          **StringComparison** |                    **?** | **PCNT(...)LFCC [1000]** |   **0.7419 ns** | **0.0170 ns** | **0.0159 ns** |         **-** |
|         **StringSetContains** |                    **?** |  **QGHZ(...)MLN7 [100]** |  **29.0337 ns** | **0.1434 ns** | **0.1341 ns** |         **-** |
|          **StringComparison** |                    **?** |           **S8EOVB0KMQ** |   **0.7142 ns** | **0.0139 ns** | **0.0130 ns** |         **-** |
|  **StringDictionaryContains** |                    **?** |           **SC5V8L1GST** |   **8.2609 ns** | **0.0122 ns** | **0.0102 ns** |         **-** |
|  **StringDictionaryContains** |                    **?** | **UBTB(...)AX3C [1000]** | **240.8286 ns** | **0.0791 ns** | **0.0618 ns** |         **-** |
|          **StringComparison** |                    **?** |  **W8CG(...)XY71 [100]** |   **0.6145 ns** | **0.0054 ns** | **0.0048 ns** |         **-** |
|         **StringSetContains** |                    **?** |           **XV12DE72Z0** |   **9.2020 ns** | **0.0196 ns** | **0.0164 ns** |         **-** |
