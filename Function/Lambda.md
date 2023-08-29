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
|            **ImmediatelyInvoke** |  **?** |  **2.746 ns** | **0.0028 ns** | **0.0023 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.748 ns | 0.0041 ns | 0.0039 ns |      - |         - |
|                     Variable |  ? |  2.763 ns | 0.0028 ns | 0.0025 ns |      - |         - |
|               VariableStatic |  ? |  2.766 ns | 0.0043 ns | 0.0038 ns |      - |         - |
|             RepeatedlyCalled |  ? | 10.851 ns | 0.0020 ns | 0.0018 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 10.849 ns | 0.0015 ns | 0.0013 ns |      - |         - |
|               LambdaDelegate |  ? |  2.771 ns | 0.0018 ns | 0.0017 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.773 ns | 0.0025 ns | 0.0023 ns |      - |         - |
|               StaticDelegate |  ? | 13.097 ns | 0.2994 ns | 0.4481 ns | 0.0025 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **19.436 ns** | **0.4261 ns** | **0.4907 ns** | **0.0035** |      **88 B** |
|                          Sum | 10 | 27.911 ns | 0.1013 ns | 0.0948 ns |      - |         - |
|                SumWithLambda | 10 |  7.625 ns | 0.0035 ns | 0.0029 ns |      - |         - |
