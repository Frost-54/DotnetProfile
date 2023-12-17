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
|        ActivatorCreateObjectTypeof | 11.8001 ns | 0.0727 ns | 0.0808 ns | 0.0003 |      24 B |
|       ActivatorCreateObjectGeneric | 14.2960 ns | 0.0955 ns | 0.0893 ns | 0.0003 |      24 B |
|                    NewCustomObject |  5.0853 ns | 0.0784 ns | 0.0733 ns | 0.0003 |      24 B |
|  ActivatorCreateCustomObjectTypeof | 12.0571 ns | 0.0671 ns | 0.0595 ns | 0.0003 |      24 B |
| ActivatorCreateCustomObjectGeneric | 14.0256 ns | 0.0572 ns | 0.0535 ns | 0.0003 |      24 B |
