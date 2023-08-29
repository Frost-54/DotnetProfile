c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 4.448 ns | 0.0007 ns | 0.0006 ns |         - |
|                            GetTypePerformance | 4.448 ns | 0.0004 ns | 0.0003 ns |         - |
|                     GetGenericTypePerformance | 4.447 ns | 0.0006 ns | 0.0006 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 5.250 ns | 0.0011 ns | 0.0010 ns |         - |
|                                     GetCached | 1.967 ns | 0.0031 ns | 0.0029 ns |         - |
