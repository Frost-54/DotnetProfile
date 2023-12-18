c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                             Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------------------- |-----------:|----------:|----------:|-------:|----------:|
|                          NewObject |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
|        ActivatorCreateObjectTypeof | 12.0469 ns | 0.0610 ns | 0.0541 ns | 0.0003 |      24 B |
|       ActivatorCreateObjectGeneric | 14.4490 ns | 0.0547 ns | 0.0512 ns | 0.0003 |      24 B |
|                    NewCustomObject |  5.0061 ns | 0.0450 ns | 0.0421 ns | 0.0003 |      24 B |
|  ActivatorCreateCustomObjectTypeof | 12.1787 ns | 0.1114 ns | 0.0988 ns | 0.0003 |      24 B |
| ActivatorCreateCustomObjectGeneric | 14.2763 ns | 0.0725 ns | 0.0678 ns | 0.0003 |      24 B |
