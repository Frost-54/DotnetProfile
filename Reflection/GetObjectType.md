c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 4.008 ns | 0.0096 ns | 0.0090 ns |         - |
|                            GetTypePerformance | 4.003 ns | 0.0044 ns | 0.0039 ns |         - |
|                     GetGenericTypePerformance | 4.010 ns | 0.0113 ns | 0.0106 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 4.004 ns | 0.0029 ns | 0.0027 ns |         - |
|                                     GetCached | 1.565 ns | 0.0020 ns | 0.0018 ns |         - |
