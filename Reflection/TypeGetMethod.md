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
|     GetMethodWithoutOverload |    28.70 ns | 0.051 ns | 0.048 ns |      - |         - |
|       GetMethodFewOfOverload |   202.75 ns | 0.229 ns | 0.191 ns | 0.0050 |     128 B |
|      GetMethodALotOfOverload | 1,090.71 ns | 1.211 ns | 1.133 ns | 0.0191 |     504 B |
|             GetMethodGeneric |    39.41 ns | 0.046 ns | 0.043 ns |      - |         - |
| GetMethodGenericWithOverload |   681.83 ns | 1.081 ns | 1.011 ns | 0.0181 |     464 B |
