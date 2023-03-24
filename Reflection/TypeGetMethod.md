c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                       Method |        Mean |      Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |------------:|-----------:|----------:|-------:|----------:|
|     GetMethodWithoutOverload |    38.65 ns |   1.058 ns |  0.058 ns |      - |         - |
|       GetMethodFewOfOverload |   279.09 ns |  70.947 ns |  3.889 ns | 0.0067 |     128 B |
|      GetMethodALotOfOverload | 1,374.73 ns |  37.401 ns |  2.050 ns | 0.0267 |     504 B |
|             GetMethodGeneric |    49.25 ns |  16.009 ns |  0.878 ns |      - |         - |
| GetMethodGenericWithOverload |   921.74 ns | 317.864 ns | 17.423 ns | 0.0248 |     464 B |
