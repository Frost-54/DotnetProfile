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
|       CreateDelegateGeneric | 223.4 ns | 0.63 ns | 0.56 ns | 0.0007 |      64 B |
|          CreateDelegateType | 223.2 ns | 0.24 ns | 0.21 ns | 0.0007 |      64 B |
| CreateMemberDelegateGeneric | 226.5 ns | 0.53 ns | 0.47 ns | 0.0007 |      64 B |
|    CreateMemberDelegateType | 224.2 ns | 0.70 ns | 0.66 ns | 0.0007 |      64 B |
