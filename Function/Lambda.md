C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                       Method |  n |      Mean |     Error |    StdDev |    Median |   Gen0 | Allocated |
|----------------------------- |--- |----------:|----------:|----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **2.775 ns** | **0.0015 ns** | **0.0014 ns** |  **2.775 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  3.582 ns | 0.1219 ns | 0.3596 ns |  3.789 ns |      - |         - |
|                     Variable |  ? |  2.778 ns | 0.0018 ns | 0.0016 ns |  2.778 ns |      - |         - |
|               VariableStatic |  ? |  3.188 ns | 0.0011 ns | 0.0010 ns |  3.187 ns |      - |         - |
|             RepeatedlyCalled |  ? | 10.685 ns | 0.0371 ns | 0.0329 ns | 10.681 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 10.761 ns | 0.0520 ns | 0.0486 ns | 10.756 ns |      - |         - |
|               LambdaDelegate |  ? |  2.767 ns | 0.0047 ns | 0.0044 ns |  2.768 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  3.187 ns | 0.0004 ns | 0.0003 ns |  3.187 ns |      - |         - |
|               StaticDelegate |  ? | 13.267 ns | 0.0805 ns | 0.0753 ns | 13.268 ns | 0.0025 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **17.825 ns** | **0.1985 ns** | **0.1760 ns** | **17.813 ns** | **0.0035** |      **88 B** |
|                          Sum | 10 | 27.958 ns | 0.0056 ns | 0.0050 ns | 27.959 ns |      - |         - |
|                SumWithLambda | 10 |  7.632 ns | 0.0071 ns | 0.0066 ns |  7.629 ns |      - |         - |
