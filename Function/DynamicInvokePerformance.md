c# Delegate.DynamicInvoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|        Method |       Mean |      Error |    StdDev | Allocated |
|-------------- |-----------:|-----------:|----------:|----------:|
| DynamicInvoke | 184.170 ns | 15.5380 ns | 0.8517 ns |         - |
|          Call |   1.184 ns |  0.0523 ns | 0.0029 ns |         - |
