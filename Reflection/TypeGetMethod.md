c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                       Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------------- |----------:|---------:|---------:|-------:|----------:|
|     GetMethodWithoutOverload |  21.30 ns | 0.074 ns | 0.062 ns |      - |         - |
|       GetMethodFewOfOverload | 161.77 ns | 1.028 ns | 0.859 ns | 0.0014 |     128 B |
|      GetMethodALotOfOverload | 793.09 ns | 4.415 ns | 4.130 ns | 0.0057 |     504 B |
|             GetMethodGeneric |  27.91 ns | 0.085 ns | 0.130 ns |      - |         - |
| GetMethodGenericWithOverload | 549.76 ns | 3.383 ns | 2.999 ns | 0.0048 |     464 B |
