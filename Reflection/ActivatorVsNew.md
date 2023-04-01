c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                      Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------- |-----------:|----------:|----------:|-------:|----------:|
|                   NewObject |  0.0318 ns | 0.0006 ns | 0.0006 ns |      - |         - |
|       ActivatorCreateObject | 16.0405 ns | 0.1484 ns | 0.1389 ns | 0.0010 |      24 B |
|             NewCustomObject |  0.0297 ns | 0.0003 ns | 0.0002 ns |      - |         - |
| ActivatorCreateCustomObject | 16.9281 ns | 0.0904 ns | 0.0801 ns | 0.0010 |      24 B |
