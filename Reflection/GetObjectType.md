c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 5.282 ns | 0.4524 ns | 0.0248 ns |         - |
|                            GetTypePerformance | 4.231 ns | 0.3696 ns | 0.0203 ns |         - |
|                     GetGenericTypePerformance | 4.996 ns | 0.0606 ns | 0.0033 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 5.284 ns | 0.6230 ns | 0.0341 ns |         - |
