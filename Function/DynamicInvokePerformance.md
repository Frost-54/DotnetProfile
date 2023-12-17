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
| DynamicInvoke | 123.6086 ns | 0.8387 ns | 0.7846 ns |         - |
|          Call |   0.6433 ns | 0.0071 ns | 0.0066 ns |         - |
