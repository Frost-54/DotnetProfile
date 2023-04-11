C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                       Method |  n |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |--- |----------:|----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **2.157 ns** | **0.0014 ns** | **0.0012 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.299 ns | 0.0013 ns | 0.0012 ns |      - |         - |
|                     Variable |  ? |  2.031 ns | 0.0016 ns | 0.0015 ns |      - |         - |
|               VariableStatic |  ? |  2.029 ns | 0.0011 ns | 0.0009 ns |      - |         - |
|             RepeatedlyCalled |  ? |  9.919 ns | 0.0020 ns | 0.0018 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? |  9.728 ns | 0.0013 ns | 0.0011 ns |      - |         - |
|               LambdaDelegate |  ? |  2.304 ns | 0.0004 ns | 0.0003 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.038 ns | 0.0007 ns | 0.0006 ns |      - |         - |
|               StaticDelegate |  ? | 13.084 ns | 0.2896 ns | 0.4153 ns | 0.0034 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **19.421 ns** | **0.2550 ns** | **0.1991 ns** | **0.0047** |      **88 B** |
|                          Sum | 10 | 15.914 ns | 0.0019 ns | 0.0017 ns |      - |         - |
|                SumWithLambda | 10 |  6.290 ns | 0.0134 ns | 0.0125 ns |      - |         - |
