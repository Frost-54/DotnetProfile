c# MethodInfo.Invoke performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                      Method | Mean | Error |
|---------------------------- |-----:|------:|
| ReflectionInvokePerformance |   NA |    NA |

Benchmarks with issues:
  ReflectionInvoke.ReflectionInvokePerformance: DefaultJob
