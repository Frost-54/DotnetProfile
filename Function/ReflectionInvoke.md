c# MethodInfo.Invoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                      Method | Mean | Error |
|---------------------------- |-----:|------:|
| ReflectionInvokePerformance |   NA |    NA |

Benchmarks with issues:
  ReflectionInvoke.ReflectionInvokePerformance: DefaultJob
