C# lambda expression performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                       Method |  n |      Mean |      Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |--- |----------:|-----------:|----------:|-------:|----------:|
|            **ImmediatelyInvoke** |  **?** |  **2.544 ns** |  **0.3056 ns** | **0.0168 ns** |      **-** |         **-** |
|      StaticImmediatelyInvoke |  ? |  2.366 ns |  0.5326 ns | 0.0292 ns |      - |         - |
|                     Variable |  ? |  2.302 ns |  0.9513 ns | 0.0521 ns |      - |         - |
|               VariableStatic |  ? |  2.443 ns |  0.5316 ns | 0.0291 ns |      - |         - |
|             RepeatedlyCalled |  ? | 12.037 ns |  9.0207 ns | 0.4945 ns |      - |         - |
|       RepeatedlyCalledStatic |  ? | 12.280 ns |  7.1709 ns | 0.3931 ns |      - |         - |
|               LambdaDelegate |  ? |  2.558 ns |  0.6280 ns | 0.0344 ns |      - |         - |
|         StaticLambdaDelegate |  ? |  2.699 ns |  4.0270 ns | 0.2207 ns |      - |         - |
|               StaticDelegate |  ? | 18.164 ns | 10.9815 ns | 0.6019 ns | 0.0034 |      64 B |
| **ImmediatelyInvokeWithCapture** | **10** | **27.547 ns** | **10.6785 ns** | **0.5853 ns** | **0.0047** |      **88 B** |
|                          Sum | 10 | 19.737 ns | 25.3825 ns | 1.3913 ns |      - |         - |
|                SumWithLambda | 10 |  7.123 ns |  0.8999 ns | 0.0493 ns |      - |         - |
