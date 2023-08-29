c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                       Method |        Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------------- |------------:|---------:|---------:|-------:|----------:|
|     GetMethodWithoutOverload |    31.78 ns | 0.033 ns | 0.031 ns |      - |         - |
|       GetMethodFewOfOverload |   203.51 ns | 0.824 ns | 0.771 ns | 0.0050 |     128 B |
|      GetMethodALotOfOverload | 1,087.18 ns | 1.349 ns | 1.262 ns | 0.0191 |     504 B |
|             GetMethodGeneric |    38.40 ns | 0.036 ns | 0.032 ns |      - |         - |
| GetMethodGenericWithOverload |   684.23 ns | 1.461 ns | 1.295 ns | 0.0181 |     464 B |
