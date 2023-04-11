c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                       Method |        Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------------- |------------:|---------:|---------:|-------:|----------:|
|     GetMethodWithoutOverload |    32.28 ns | 0.005 ns | 0.004 ns |      - |         - |
|       GetMethodFewOfOverload |   218.28 ns | 2.464 ns | 2.304 ns | 0.0067 |     128 B |
|      GetMethodALotOfOverload | 1,150.15 ns | 3.760 ns | 3.517 ns | 0.0267 |     504 B |
|             GetMethodGeneric |    39.98 ns | 0.034 ns | 0.029 ns |      - |         - |
| GetMethodGenericWithOverload |   736.34 ns | 6.316 ns | 5.908 ns | 0.0248 |     464 B |
