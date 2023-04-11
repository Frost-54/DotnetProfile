c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                      Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------- |-----------:|----------:|----------:|-------:|----------:|
|                   NewObject |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
|       ActivatorCreateObject | 18.2036 ns | 0.3586 ns | 0.4404 ns | 0.0013 |      24 B |
|             NewCustomObject |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| ActivatorCreateCustomObject | 22.2770 ns | 0.3524 ns | 0.3296 ns | 0.0013 |      24 B |
