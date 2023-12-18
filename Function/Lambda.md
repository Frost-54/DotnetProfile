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
|            **ImmediatelyInvoke** |  **?** |  **1.880 ns** | **0.0063 ns** | **0.0059 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  1.879 ns | 0.0049 ns | 0.0046 ns |      - |         - |
|                     Variable |  ? |  2.186 ns | 0.0039 ns | 0.0033 ns |      - |         - |
|               VariableStatic |  ? |  2.189 ns | 0.0081 ns | 0.0076 ns |      - |         - |
|             RepeatedlyCalled |  ? |  8.690 ns | 0.0163 ns | 0.0144 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? |  8.072 ns | 0.0165 ns | 0.0147 ns |      - |         - |
|               LambdaDelegate |  ? |  1.879 ns | 0.0060 ns | 0.0056 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  1.876 ns | 0.0050 ns | 0.0047 ns |      - |         - |
|               StaticDelegate |  ? | 12.887 ns | 0.0683 ns | 0.0639 ns | 0.0007 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **16.645 ns** | **0.1924 ns** | **0.1799 ns** | **0.0010** |      **88 B** |
|                          Sum | 10 |  2.863 ns | 0.0021 ns | 0.0017 ns |      - |         - |
|                SumWithLambda | 10 |  5.028 ns | 0.0038 ns | 0.0029 ns |      - |         - |
