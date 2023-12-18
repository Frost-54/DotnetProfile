C# MethodInfo.CreateDelegate performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                      Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|---------------------------- |---------:|--------:|--------:|-------:|----------:|
|       CreateDelegateGeneric | 223.7 ns | 0.70 ns | 0.66 ns | 0.0007 |      64 B |
|          CreateDelegateType | 224.3 ns | 0.76 ns | 0.67 ns | 0.0007 |      64 B |
| CreateMemberDelegateGeneric | 228.2 ns | 0.69 ns | 0.64 ns | 0.0007 |      64 B |
|    CreateMemberDelegateType | 224.1 ns | 0.37 ns | 0.31 ns | 0.0007 |      64 B |
