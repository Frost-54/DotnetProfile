c# Delegate.DynamicInvoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|        Method |       Mean |     Error |    StdDev | Allocated |
|-------------- |-----------:|----------:|----------:|----------:|
| DynamicInvoke | 156.574 ns | 0.0685 ns | 0.0641 ns |         - |
|          Call |   1.172 ns | 0.0020 ns | 0.0019 ns |         - |
