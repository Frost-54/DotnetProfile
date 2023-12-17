C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-HPQQFE : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |          Mean |      Error |    StdDev |        Median | Allocated |
|------------------- |------ |--------------:|-----------:|----------:|--------------:|----------:|
|       **ListCreation** |    **10** |   **2,229.01 ns** | **118.078 ns** | **344.44 ns** |   **2,328.50 ns** |    **1192 B** |
|            ListAdd |    10 |   5,410.36 ns | 111.776 ns | 263.47 ns |   5,450.50 ns |   81008 B |
|         ListInsert |    10 |   6,090.43 ns | 114.506 ns | 101.51 ns |   6,062.00 ns |   81008 B |
|          ListGetAt |    10 |      97.00 ns |   7.103 ns |  16.88 ns |     100.00 ns |     976 B |
|          ListSetAt |    10 |     110.92 ns |   8.728 ns |  24.47 ns |     110.00 ns |     976 B |
|         ListRemove |    10 |   2,188.22 ns |  77.180 ns | 213.87 ns |   2,253.00 ns |     976 B |
|       ListRemoveAt |    10 |   1,326.53 ns |  29.241 ns |  27.35 ns |   1,332.00 ns |     976 B |
|        ListIndexOf |    10 |     279.99 ns |   9.814 ns |  26.20 ns |     280.00 ns |     976 B |
| LinkedListCreation |    10 |   1,056.38 ns |  25.963 ns |  51.25 ns |   1,053.00 ns |    1496 B |
|      LinkedListAdd |    10 |   1,588.45 ns |  93.028 ns | 271.37 ns |   1,713.00 ns |    1024 B |
|   LinkedListInsert |    10 |   1,022.23 ns |  24.866 ns |  44.20 ns |   1,021.50 ns |    1024 B |
|    LinkedListGetAt |    10 |      54.39 ns |   6.667 ns |  10.57 ns |      51.00 ns |     976 B |
|    LinkedListSetAt |    10 |      73.11 ns |   6.016 ns |  11.73 ns |      71.00 ns |     976 B |
| LinkedListRemoveAt |    10 |     230.86 ns |   8.649 ns |  10.62 ns |     235.50 ns |     976 B |
|   LinkedListRemove |    10 |     254.21 ns |  14.109 ns |  41.16 ns |     261.00 ns |     976 B |
|  LinkedListIndexOf |    10 |     108.30 ns |  12.332 ns |  34.17 ns |     111.00 ns |     976 B |
|       **ListCreation** |   **100** |   **1,823.48 ns** |  **42.088 ns** |  **79.05 ns** |   **1,829.50 ns** |    **2160 B** |
|            ListAdd |   100 |   4,172.88 ns |  85.287 ns |  83.76 ns |   4,173.00 ns |   81008 B |
|         ListInsert |   100 |   4,679.43 ns |  91.115 ns |  80.77 ns |   4,704.00 ns |   81008 B |
|          ListGetAt |   100 |     108.97 ns |   7.900 ns |  17.99 ns |     110.00 ns |     976 B |
|          ListSetAt |   100 |      70.78 ns |   7.244 ns |  19.59 ns |      70.00 ns |     976 B |
|         ListRemove |   100 |   1,582.50 ns |  35.773 ns |  38.28 ns |   1,583.50 ns |     976 B |
|       ListRemoveAt |   100 |   1,348.41 ns |  31.185 ns |  38.30 ns |   1,342.00 ns |     976 B |
|        ListIndexOf |   100 |     297.20 ns |  11.040 ns |  22.55 ns |     301.00 ns |     976 B |
| LinkedListCreation |   100 |   2,210.26 ns |  47.864 ns |  56.98 ns |   2,219.50 ns |    5816 B |
|      LinkedListAdd |   100 |   1,035.72 ns |  24.703 ns |  62.88 ns |   1,033.00 ns |    1024 B |
|   LinkedListInsert |   100 |   1,765.72 ns |  39.694 ns |  73.57 ns |   1,753.00 ns |    1024 B |
|    LinkedListGetAt |   100 |     262.07 ns |  10.736 ns |  20.68 ns |     260.50 ns |     976 B |
|    LinkedListSetAt |   100 |     222.30 ns |   9.412 ns |  14.93 ns |     221.00 ns |     976 B |
| LinkedListRemoveAt |   100 |     333.65 ns |  10.916 ns |  12.57 ns |     331.00 ns |     976 B |
|   LinkedListRemove |   100 |     358.36 ns |  11.632 ns |  22.69 ns |     360.00 ns |     976 B |
|  LinkedListIndexOf |   100 |     249.03 ns |   9.942 ns |  15.18 ns |     250.00 ns |     976 B |
|       **ListCreation** |  **1000** |   **5,889.94 ns** | **113.554 ns** | **111.53 ns** |   **5,885.50 ns** |    **9400 B** |
|            ListAdd |  1000 |   4,148.31 ns |  50.716 ns |  42.35 ns |   4,159.00 ns |   81008 B |
|         ListInsert |  1000 |   4,786.33 ns |  76.027 ns |  71.12 ns |   4,778.00 ns |   81008 B |
|          ListGetAt |  1000 |     134.26 ns |  13.538 ns |  37.29 ns |     125.00 ns |     976 B |
|          ListSetAt |  1000 |     132.48 ns |   7.757 ns |  16.53 ns |     135.50 ns |     976 B |
|         ListRemove |  1000 |   1,710.82 ns |  37.471 ns |  46.02 ns |   1,703.00 ns |     976 B |
|       ListRemoveAt |  1000 |   1,884.75 ns |  42.842 ns |  42.08 ns |   1,883.50 ns |     976 B |
|        ListIndexOf |  1000 |     500.00 ns |  14.974 ns |  17.24 ns |     496.50 ns |     976 B |
| LinkedListCreation |  1000 |  14,314.93 ns | 111.623 ns | 104.41 ns |  14,306.00 ns |   49016 B |
|      LinkedListAdd |  1000 |   1,153.18 ns |  26.929 ns |  43.49 ns |   1,151.50 ns |    1024 B |
|   LinkedListInsert |  1000 |   1,775.65 ns |  37.511 ns |  60.57 ns |   1,778.50 ns |    1024 B |
|    LinkedListGetAt |  1000 |   1,441.76 ns |  33.541 ns |  37.28 ns |   1,437.50 ns |     976 B |
|    LinkedListSetAt |  1000 |   2,062.13 ns |  34.424 ns |  32.20 ns |   2,064.00 ns |     976 B |
| LinkedListRemoveAt |  1000 |   2,208.65 ns |  48.901 ns |  56.31 ns |   2,188.50 ns |     976 B |
|   LinkedListRemove |  1000 |   1,710.17 ns |  38.507 ns |  36.02 ns |   1,718.50 ns |     976 B |
|  LinkedListIndexOf |  1000 |   1,525.77 ns |  23.954 ns |  22.41 ns |   1,523.50 ns |     976 B |
|       **ListCreation** | **10000** |  **16,731.33 ns** | **168.642 ns** | **157.75 ns** |  **16,721.00 ns** |  **132376 B** |
|            ListAdd | 10000 |   5,170.95 ns | 170.518 ns | 502.78 ns |   5,375.50 ns |   81008 B |
|         ListInsert | 10000 |   5,345.96 ns | 264.688 ns | 780.44 ns |   5,675.00 ns |   81008 B |
|          ListGetAt | 10000 |      88.65 ns |   6.941 ns |  17.41 ns |      91.00 ns |     976 B |
|          ListSetAt | 10000 |     137.46 ns |   8.689 ns |  24.37 ns |     140.00 ns |     976 B |
|         ListRemove | 10000 |   2,141.80 ns |  25.257 ns |  23.63 ns |   2,125.00 ns |     976 B |
|       ListRemoveAt | 10000 |     178.97 ns |   8.098 ns |  17.77 ns |     174.50 ns |     976 B |
|        ListIndexOf | 10000 |   2,077.97 ns |  30.490 ns |  28.52 ns |   2,074.50 ns |     976 B |
| LinkedListCreation | 10000 | 134,177.50 ns | 162.087 ns | 126.55 ns | 134,150.50 ns |  481016 B |
|      LinkedListAdd | 10000 |   1,347.25 ns | 114.437 ns | 337.42 ns |   1,143.00 ns |    1024 B |
|   LinkedListInsert | 10000 |   7,927.93 ns |  60.691 ns |  53.80 ns |   7,909.00 ns |    1024 B |
|    LinkedListGetAt | 10000 |  13,650.86 ns |  42.571 ns |  37.74 ns |  13,651.00 ns |     976 B |
|    LinkedListSetAt | 10000 |  16,597.60 ns |  84.389 ns |  78.94 ns |  16,601.00 ns |     976 B |
| LinkedListRemoveAt | 10000 |  13,773.53 ns |  46.436 ns |  43.44 ns |  13,787.00 ns |     976 B |
|   LinkedListRemove | 10000 |  14,915.27 ns |  49.156 ns |  45.98 ns |  14,917.00 ns |     976 B |
|  LinkedListIndexOf | 10000 |  15,300.40 ns | 150.320 ns | 140.61 ns |  15,339.00 ns |     976 B |
