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
|            **ImmediatelyInvoke** |  **?** |  **2.747 ns** | **0.0039 ns** | **0.0032 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.745 ns | 0.0044 ns | 0.0037 ns |      - |         - |
|                     Variable |  ? |  2.765 ns | 0.0035 ns | 0.0032 ns |      - |         - |
|               VariableStatic |  ? |  2.762 ns | 0.0034 ns | 0.0031 ns |      - |         - |
|             RepeatedlyCalled |  ? | 10.851 ns | 0.0007 ns | 0.0005 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 10.852 ns | 0.0013 ns | 0.0011 ns |      - |         - |
|               LambdaDelegate |  ? |  2.769 ns | 0.0032 ns | 0.0030 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.774 ns | 0.0017 ns | 0.0016 ns |      - |         - |
|               StaticDelegate |  ? | 13.471 ns | 0.2941 ns | 0.4311 ns | 0.0025 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **21.604 ns** | **0.4574 ns** | **0.5268 ns** | **0.0035** |      **88 B** |
|                          Sum | 10 | 27.971 ns | 0.0416 ns | 0.0389 ns |      - |         - |
|                SumWithLambda | 10 |  7.621 ns | 0.0063 ns | 0.0056 ns |      - |         - |
