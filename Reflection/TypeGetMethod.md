c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                       Method |        Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------------- |------------:|---------:|---------:|-------:|----------:|
|     GetMethodWithoutOverload |    29.41 ns | 0.045 ns | 0.040 ns |      - |         - |
|       GetMethodFewOfOverload |   210.36 ns | 0.636 ns | 0.595 ns | 0.0050 |     128 B |
|      GetMethodALotOfOverload | 1,129.72 ns | 1.501 ns | 1.330 ns | 0.0191 |     504 B |
|             GetMethodGeneric |    38.81 ns | 0.129 ns | 0.108 ns |      - |         - |
| GetMethodGenericWithOverload |   670.69 ns | 2.151 ns | 2.012 ns | 0.0181 |     464 B |
