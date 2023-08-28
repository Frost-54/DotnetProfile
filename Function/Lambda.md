C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                       Method |  n |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |--- |----------:|----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **2.511 ns** | **0.0842 ns** | **0.0788 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.759 ns | 0.0992 ns | 0.1764 ns |      - |         - |
|                     Variable |  ? |  2.439 ns | 0.0844 ns | 0.0789 ns |      - |         - |
|               VariableStatic |  ? |  2.530 ns | 0.0590 ns | 0.0523 ns |      - |         - |
|             RepeatedlyCalled |  ? | 11.579 ns | 0.2584 ns | 0.2291 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 12.347 ns | 0.2847 ns | 0.4433 ns |      - |         - |
|               LambdaDelegate |  ? |  2.561 ns | 0.0963 ns | 0.1901 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.577 ns | 0.0802 ns | 0.0750 ns |      - |         - |
|               StaticDelegate |  ? | 16.736 ns | 0.4297 ns | 1.2603 ns | 0.0024 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **25.544 ns** | **0.6943 ns** | **2.0362 ns** | **0.0033** |      **88 B** |
|                          Sum | 10 | 19.585 ns | 0.3574 ns | 0.3168 ns |      - |         - |
|                SumWithLambda | 10 |  6.920 ns | 0.1767 ns | 0.1815 ns |      - |         - |
