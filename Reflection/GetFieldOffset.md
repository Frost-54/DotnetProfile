c# Activator.CreateInstance vs new performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                      Method | dummy |      Mean |     Error |    StdDev |    Median | Allocated |
|---------------------------- |------ |----------:|----------:|----------:|----------:|----------:|
|                    **ILMethod** |     **?** | **1.2631 ns** | **0.0089 ns** | **0.0083 ns** | **1.2580 ns** |         **-** |
|                       **Fixed** |     **0** | **0.5631 ns** | **0.0046 ns** | **0.0043 ns** | **0.5609 ns** |         **-** |
|           FixedWithExisting |     0 | 0.3152 ns | 0.0058 ns | 0.0054 ns | 0.3146 ns |         - |
|             UnsafeAsPointer |     0 | 0.3091 ns | 0.0008 ns | 0.0008 ns | 0.3093 ns |         - |
| UnsafeAsPointerWithExisting |     0 | 0.0025 ns | 0.0023 ns | 0.0022 ns | 0.0015 ns |         - |
|                 UnsafeAsRef |     0 | 0.2603 ns | 0.0059 ns | 0.0055 ns | 0.2570 ns |         - |
|     UnsafeAsRefWithExisting |     0 | 0.0015 ns | 0.0020 ns | 0.0019 ns | 0.0009 ns |         - |
