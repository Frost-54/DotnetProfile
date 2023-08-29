C# MethodInfo.CreateDelegate performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                      Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|---------------------------- |---------:|--------:|--------:|-------:|----------:|
|       CreateDelegateGeneric | 312.9 ns | 0.12 ns | 0.10 ns | 0.0024 |      64 B |
|          CreateDelegateType | 610.5 ns | 1.40 ns | 1.31 ns | 0.0019 |      64 B |
| CreateMemberDelegateGeneric | 320.9 ns | 0.13 ns | 0.10 ns | 0.0024 |      64 B |
|    CreateMemberDelegateType | 548.3 ns | 9.60 ns | 8.51 ns | 0.0019 |      64 B |
