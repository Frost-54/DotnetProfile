c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                       Method |        Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------- |------------:|----------:|----------:|-------:|----------:|
|     GetMethodWithoutOverload |    38.50 ns |  0.468 ns |  0.391 ns |      - |         - |
|       GetMethodFewOfOverload |   292.06 ns |  5.849 ns | 14.014 ns | 0.0048 |     128 B |
|      GetMethodALotOfOverload | 1,450.85 ns | 27.849 ns | 37.178 ns | 0.0191 |     504 B |
|             GetMethodGeneric |    50.16 ns |  0.983 ns |  1.052 ns |      - |         - |
| GetMethodGenericWithOverload |   918.43 ns | 18.191 ns | 27.780 ns | 0.0172 |     464 B |
