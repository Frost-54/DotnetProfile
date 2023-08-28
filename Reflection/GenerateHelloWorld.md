C# dynamic code generation using DynamicAssembly vs DynamicMethod
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                    Method |         Mean |        Error |       StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------------------- |-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
| DynamicAssemblyHelloWorld | 601,621.7 ns | 19,452.92 ns | 57,357.37 ns | 3.9063 | 3.9063 | 3.9063 |    5161 B |
|   DynamicMethodHelloWorld |     620.3 ns |     12.31 ns |     29.74 ns | 0.0334 |      - |      - |     888 B |
