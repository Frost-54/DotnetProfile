c# Type.GetMethod performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                       Method |      Mean |     Error |   StdDev |   Gen0 | Allocated |
|----------------------------- |----------:|----------:|---------:|-------:|----------:|
|     GetMethodWithoutOverload |  21.18 ns |  0.018 ns | 0.016 ns |      - |         - |
|       GetMethodFewOfOverload | 148.79 ns |  0.722 ns | 0.675 ns | 0.0014 |     128 B |
|      GetMethodALotOfOverload | 796.83 ns | 10.639 ns | 9.952 ns | 0.0057 |     504 B |
|             GetMethodGeneric |  27.83 ns |  0.061 ns | 0.057 ns |      - |         - |
| GetMethodGenericWithOverload | 515.90 ns |  3.816 ns | 3.569 ns | 0.0048 |     464 B |
