C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                       Method |  n |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |--- |----------:|----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **2.765 ns** | **0.0080 ns** | **0.0075 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.757 ns | 0.0081 ns | 0.0075 ns |      - |         - |
|                     Variable |  ? |  2.772 ns | 0.0041 ns | 0.0036 ns |      - |         - |
|               VariableStatic |  ? |  2.774 ns | 0.0038 ns | 0.0036 ns |      - |         - |
|             RepeatedlyCalled |  ? | 10.846 ns | 0.0016 ns | 0.0014 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 10.847 ns | 0.0010 ns | 0.0009 ns |      - |         - |
|               LambdaDelegate |  ? |  2.773 ns | 0.0029 ns | 0.0027 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.774 ns | 0.0024 ns | 0.0022 ns |      - |         - |
|               StaticDelegate |  ? | 14.633 ns | 0.2884 ns | 0.2557 ns | 0.0025 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **20.323 ns** | **0.4376 ns** | **0.4494 ns** | **0.0035** |      **88 B** |
|                          Sum | 10 | 27.975 ns | 0.0232 ns | 0.0217 ns |      - |         - |
|                SumWithLambda | 10 |  7.629 ns | 0.0080 ns | 0.0075 ns |      - |         - |
