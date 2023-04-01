c# typeof() performance, c# GetType() performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|----------:|
|                             TypeofPerformance | 5.266 ns | 0.0008 ns | 0.0007 ns |         - |
|                            GetTypePerformance | 4.861 ns | 0.0024 ns | 0.0019 ns |         - |
|                     GetGenericTypePerformance | 5.258 ns | 0.0006 ns | 0.0006 ns |         - |
| GetGenericTypeWithGenericParameterPerformance | 5.257 ns | 0.0011 ns | 0.0010 ns |         - |
