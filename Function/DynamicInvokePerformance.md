c# Delegate.DynamicInvoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|        Method |       Mean |     Error |    StdDev | Allocated |
|-------------- |-----------:|----------:|----------:|----------:|
| DynamicInvoke | 200.725 ns | 3.6276 ns | 3.2158 ns |         - |
|          Call |   1.014 ns | 0.0375 ns | 0.0333 ns |         - |
