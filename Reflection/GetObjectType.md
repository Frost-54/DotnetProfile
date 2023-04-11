c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 3.812 ns | 0.0008 ns | 0.0007 ns |         - |
|                            GetTypePerformance | 4.145 ns | 0.0007 ns | 0.0006 ns |         - |
|                     GetGenericTypePerformance | 3.807 ns | 0.0007 ns | 0.0006 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 3.808 ns | 0.0010 ns | 0.0008 ns |         - |
|                                     GetCached | 1.399 ns | 0.0009 ns | 0.0009 ns |         - |
