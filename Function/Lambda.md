C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                       Method |  n |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |--- |----------:|----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **1.881 ns** | **0.0041 ns** | **0.0038 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  1.880 ns | 0.0054 ns | 0.0047 ns |      - |         - |
|                     Variable |  ? |  2.192 ns | 0.0081 ns | 0.0076 ns |      - |         - |
|               VariableStatic |  ? |  2.184 ns | 0.0021 ns | 0.0019 ns |      - |         - |
|             RepeatedlyCalled |  ? |  8.073 ns | 0.0217 ns | 0.0203 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? |  8.058 ns | 0.0060 ns | 0.0047 ns |      - |         - |
|               LambdaDelegate |  ? |  1.873 ns | 0.0009 ns | 0.0007 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  1.878 ns | 0.0051 ns | 0.0048 ns |      - |         - |
|               StaticDelegate |  ? | 12.295 ns | 0.1198 ns | 0.1120 ns | 0.0008 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **15.521 ns** | **0.0686 ns** | **0.0608 ns** | **0.0010** |      **88 B** |
|                          Sum | 10 |  2.862 ns | 0.0030 ns | 0.0028 ns |      - |         - |
|                SumWithLambda | 10 |  5.045 ns | 0.0171 ns | 0.0160 ns |      - |         - |
