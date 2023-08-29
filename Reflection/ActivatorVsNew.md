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
|                   NewObject |  0.0312 ns | 0.0005 ns | 0.0005 ns |      - |         - |
|       ActivatorCreateObject | 17.4778 ns | 0.0202 ns | 0.0179 ns | 0.0010 |      24 B |
|             NewCustomObject |  0.0307 ns | 0.0003 ns | 0.0003 ns |      - |         - |
| ActivatorCreateCustomObject | 17.2866 ns | 0.0758 ns | 0.0709 ns | 0.0010 |      24 B |
