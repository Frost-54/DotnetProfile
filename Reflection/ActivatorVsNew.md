c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                      Method |       Mean |      Error |    StdDev |     Median |   Gen0 | Allocated |
|---------------------------- |-----------:|-----------:|----------:|-----------:|-------:|----------:|
|                   NewObject |  0.0176 ns |  0.0433 ns | 0.0024 ns |  0.0183 ns |      - |         - |
|       ActivatorCreateObject | 22.8090 ns |  1.3688 ns | 0.0750 ns | 22.8098 ns | 0.0013 |      24 B |
|             NewCustomObject |  0.0038 ns |  0.0500 ns | 0.0027 ns |  0.0047 ns |      - |         - |
| ActivatorCreateCustomObject | 23.7249 ns | 19.8123 ns | 1.0860 ns | 23.1783 ns | 0.0013 |      24 B |
