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
|     GetMethodWithoutOverload |    28.28 ns | 0.124 ns | 0.104 ns |      - |         - |
|       GetMethodFewOfOverload |   198.78 ns | 1.204 ns | 1.127 ns | 0.0050 |     128 B |
|      GetMethodALotOfOverload | 1,085.06 ns | 0.715 ns | 0.597 ns | 0.0191 |     504 B |
|             GetMethodGeneric |    40.25 ns | 0.074 ns | 0.069 ns |      - |         - |
| GetMethodGenericWithOverload |   681.39 ns | 2.959 ns | 2.768 ns | 0.0181 |     464 B |
