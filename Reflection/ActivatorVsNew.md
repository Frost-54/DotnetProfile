c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                      Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------- |-----------:|----------:|----------:|-------:|----------:|
|                   NewObject |  0.0292 ns | 0.0003 ns | 0.0002 ns |      - |         - |
|       ActivatorCreateObject | 15.9872 ns | 0.1096 ns | 0.1025 ns | 0.0010 |      24 B |
|             NewCustomObject |  0.0315 ns | 0.0009 ns | 0.0008 ns |      - |         - |
| ActivatorCreateCustomObject | 15.9637 ns | 0.1033 ns | 0.0966 ns | 0.0010 |      24 B |
