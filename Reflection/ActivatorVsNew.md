c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                      Method |       Mean |     Error |    StdDev |     Median |   Gen0 | Allocated |
|---------------------------- |-----------:|----------:|----------:|-----------:|-------:|----------:|
|                   NewObject |  0.0090 ns | 0.0172 ns | 0.0218 ns |  0.0000 ns |      - |         - |
|       ActivatorCreateObject | 18.3007 ns | 0.4027 ns | 1.0538 ns | 18.0397 ns | 0.0009 |      24 B |
|             NewCustomObject |  0.0578 ns | 0.0324 ns | 0.0533 ns |  0.0480 ns |      - |         - |
| ActivatorCreateCustomObject | 19.5963 ns | 0.6833 ns | 2.0148 ns | 19.4084 ns | 0.0009 |      24 B |
