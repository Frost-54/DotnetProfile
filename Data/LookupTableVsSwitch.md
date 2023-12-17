C# switch vs lookup table performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-HPQQFE : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|           Method |     Mean |    Error |   StdDev | Allocated |
|----------------- |---------:|---------:|---------:|----------:|
| LookupTableArray | 83.70 ns | 7.735 ns | 22.56 ns |     976 B |
|  LookupTableSpan | 88.17 ns | 8.305 ns | 24.49 ns |     976 B |
|           Switch | 78.00 ns | 6.130 ns | 12.80 ns |     976 B |
