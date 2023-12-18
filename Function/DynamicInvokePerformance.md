c# Delegate.DynamicInvoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|        Method |        Mean |     Error |    StdDev | Allocated |
|-------------- |------------:|----------:|----------:|----------:|
| DynamicInvoke | 122.9565 ns | 0.2368 ns | 0.2215 ns |         - |
|          Call |   0.6416 ns | 0.0052 ns | 0.0049 ns |         - |
