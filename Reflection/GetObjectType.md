c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 5.359 ns | 0.1528 ns | 0.1986 ns |         - |
|                            GetTypePerformance | 5.220 ns | 0.1169 ns | 0.1093 ns |         - |
|                     GetGenericTypePerformance | 5.384 ns | 0.1456 ns | 0.1842 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 5.253 ns | 0.1492 ns | 0.1597 ns |         - |
|                                     GetCached | 1.510 ns | 0.0739 ns | 0.0907 ns |         - |
