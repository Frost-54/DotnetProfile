c# Delegate.DynamicInvoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|        Method |       Mean |     Error |    StdDev | Allocated |
|-------------- |-----------:|----------:|----------:|----------:|
| DynamicInvoke | 154.857 ns | 0.0739 ns | 0.0617 ns |         - |
|          Call |   1.130 ns | 0.0005 ns | 0.0005 ns |         - |
