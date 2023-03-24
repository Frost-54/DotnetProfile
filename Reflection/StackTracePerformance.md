c# StackTrace performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]   : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|      Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------ |---------:|---------:|---------:|-------:|----------:|
| Performance | 13.13 μs | 1.857 μs | 0.102 μs | 0.2289 |    4.2 KB |
