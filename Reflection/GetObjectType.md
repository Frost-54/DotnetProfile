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
|                             TypeofPerformance | 4.014 ns | 0.0175 ns | 0.0155 ns |         - |
|                            GetTypePerformance | 4.013 ns | 0.0143 ns | 0.0127 ns |         - |
|                     GetGenericTypePerformance | 4.010 ns | 0.0100 ns | 0.0094 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 4.011 ns | 0.0154 ns | 0.0144 ns |         - |
|                                     GetCached | 1.571 ns | 0.0048 ns | 0.0044 ns |         - |
