C# switch vs lookup table performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-IMKWCR : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|           Method |      Mean |     Error |   StdDev |   Median | Allocated |
|----------------- |----------:|----------:|---------:|---------:|----------:|
| LookupTableArray | 110.37 ns | 23.203 ns | 65.44 ns | 85.50 ns |     976 B |
|  LookupTableSpan |  98.75 ns |  9.408 ns | 26.07 ns | 99.50 ns |     976 B |
|           Switch |  90.19 ns |  8.991 ns | 24.76 ns | 89.50 ns |     976 B |
