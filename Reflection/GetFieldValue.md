C# FieldInfo.GetValue performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|   Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------- |---------:|---------:|---------:|-------:|----------:|
| GetValue | 72.38 ns | 0.153 ns | 0.143 ns | 0.0010 |      24 B |
