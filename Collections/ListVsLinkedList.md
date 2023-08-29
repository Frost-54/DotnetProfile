C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  Job-IDGIOI : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |          Mean |       Error |      StdDev |          Median | Allocated |
|------------------- |------ |--------------:|------------:|------------:|----------------:|----------:|
|       **ListCreation** |    **10** |   **1,847.06 ns** |    **39.59 ns** |    **80.88 ns** |   **1,800.0000 ns** |    **1192 B** |
|            ListAdd |    10 |   7,609.97 ns |   155.51 ns |   232.76 ns |   7,550.0000 ns |   81008 B |
|         ListInsert |    10 |   7,621.43 ns |   141.16 ns |   125.14 ns |   7,650.0000 ns |   81008 B |
|          ListGetAt |    10 |     324.00 ns |    29.37 ns |    86.60 ns |     300.0000 ns |     976 B |
|          ListSetAt |    10 |     267.71 ns |    19.80 ns |    57.11 ns |     300.0000 ns |     976 B |
|         ListRemove |    10 |  17,528.64 ns |   200.02 ns |   177.31 ns |  17,550.0000 ns |     976 B |
|       ListRemoveAt |    10 |  17,066.75 ns |    63.14 ns |    49.30 ns |  17,100.0000 ns |     976 B |
|        ListIndexOf |    10 |     590.91 ns |    34.82 ns |   102.11 ns |     600.0000 ns |     976 B |
| LinkedListCreation |    10 |   1,435.53 ns |    32.53 ns |    82.79 ns |   1,400.0000 ns |    1496 B |
|      LinkedListAdd |    10 |   1,425.00 ns |    34.46 ns |    85.17 ns |   1,400.0000 ns |    1024 B |
|   LinkedListInsert |    10 |   1,269.79 ns |    34.34 ns |    99.07 ns |   1,250.0000 ns |    1024 B |
|    LinkedListGetAt |    10 |     161.01 ns |    27.65 ns |    81.51 ns |     200.0000 ns |     976 B |
|    LinkedListSetAt |    10 |      39.00 ns |    20.39 ns |    60.13 ns |       0.0000 ns |     976 B |
| LinkedListRemoveAt |    10 |     187.37 ns |    30.26 ns |    88.74 ns |     150.0000 ns |     976 B |
|   LinkedListRemove |    10 |     246.00 ns |    23.82 ns |    70.24 ns |     200.0000 ns |     976 B |
|  LinkedListIndexOf |    10 |     190.91 ns |    24.88 ns |    72.97 ns |     200.0000 ns |     976 B |
|       **ListCreation** |   **100** |   **2,260.53 ns** |    **43.76 ns** |    **75.48 ns** |   **2,300.0000 ns** |    **2160 B** |
|            ListAdd |   100 |   6,776.92 ns |   139.60 ns |   116.58 ns |   6,800.0000 ns |   81008 B |
|         ListInsert |   100 |   7,328.57 ns |   103.09 ns |    91.39 ns |   7,300.0000 ns |   81008 B |
|          ListGetAt |   100 |     157.29 ns |    26.96 ns |    77.79 ns |     200.0000 ns |     976 B |
|          ListSetAt |   100 |      75.00 ns |    15.81 ns |    43.55 ns |     100.0000 ns |     976 B |
|         ListRemove |   100 |  17,520.20 ns |   140.98 ns |   131.88 ns |  17,501.0000 ns |     976 B |
|       ListRemoveAt |   100 |  17,180.07 ns |   129.12 ns |   120.78 ns |  17,200.0000 ns |     976 B |
|        ListIndexOf |   100 |     534.69 ns |    33.42 ns |    97.50 ns |     500.0000 ns |     976 B |
| LinkedListCreation |   100 |   2,640.00 ns |    58.10 ns |   103.28 ns |   2,600.0000 ns |    5816 B |
|      LinkedListAdd |   100 |   1,632.26 ns |    36.24 ns |    82.53 ns |   1,600.0000 ns |    1024 B |
|   LinkedListInsert |   100 |   1,527.78 ns |    38.43 ns |    81.07 ns |   1,500.0000 ns |    1024 B |
|    LinkedListGetAt |   100 |     370.00 ns |    21.29 ns |    62.76 ns |     400.0000 ns |     976 B |
|    LinkedListSetAt |   100 |     466.01 ns |    23.73 ns |    69.95 ns |     500.0000 ns |     976 B |
| LinkedListRemoveAt |   100 |     486.01 ns |    22.63 ns |    66.71 ns |     500.0000 ns |     976 B |
|   LinkedListRemove |   100 |     479.00 ns |    24.24 ns |    71.48 ns |     500.0000 ns |     976 B |
|  LinkedListIndexOf |   100 |     449.47 ns |    30.87 ns |    88.57 ns |     400.0000 ns |     976 B |
|       **ListCreation** |  **1000** |   **6,114.34 ns** |   **125.41 ns** |   **206.06 ns** |   **6,100.0000 ns** |    **9400 B** |
|            ListAdd |  1000 |   6,680.68 ns |   138.85 ns |   212.04 ns |   6,700.0000 ns |   81008 B |
|         ListInsert |  1000 |   7,221.43 ns |   147.93 ns |   131.14 ns |   7,200.0000 ns |   81008 B |
|          ListGetAt |  1000 |     200.00 ns |    28.11 ns |    82.88 ns |     200.0000 ns |     976 B |
|          ListSetAt |  1000 |      86.67 ns |    13.54 ns |    34.22 ns |     100.0000 ns |     976 B |
|         ListRemove |  1000 |  16,446.80 ns |   139.02 ns |   130.04 ns |  16,400.0000 ns |     976 B |
|       ListRemoveAt |  1000 |  15,285.71 ns |   164.71 ns |   146.01 ns |  15,250.0000 ns |     976 B |
|        ListIndexOf |  1000 |     922.68 ns |    30.06 ns |    87.21 ns |     900.0000 ns |     976 B |
| LinkedListCreation |  1000 |  19,666.73 ns |   164.83 ns |   154.18 ns |  19,700.0000 ns |   49016 B |
|      LinkedListAdd |  1000 |   1,550.75 ns |    36.90 ns |    87.69 ns |   1,500.0000 ns |    1024 B |
|   LinkedListInsert |  1000 |   2,847.18 ns |    60.80 ns |    62.43 ns |   2,800.0000 ns |    1024 B |
|    LinkedListGetAt |  1000 |   3,043.75 ns |    64.06 ns |    62.92 ns |   3,050.0000 ns |     976 B |
|    LinkedListSetAt |  1000 |   3,147.06 ns |    59.84 ns |   122.23 ns |   3,100.0000 ns |     976 B |
| LinkedListRemoveAt |  1000 |   3,236.84 ns |    68.46 ns |    76.09 ns |   3,200.0000 ns |     976 B |
|   LinkedListRemove |  1000 |   3,100.00 ns |    65.74 ns |    96.36 ns |   3,100.0000 ns |     976 B |
|  LinkedListIndexOf |  1000 |   2,774.19 ns |    60.89 ns |    92.98 ns |   2,800.0000 ns |     976 B |
|       **ListCreation** | **10000** |  **38,217.82 ns** |   **745.18 ns** |   **765.25 ns** |  **38,200.0000 ns** |  **132376 B** |
|            ListAdd | 10000 |   7,512.54 ns |   138.56 ns |   180.17 ns |   7,600.0000 ns |   81008 B |
|         ListInsert | 10000 |   7,738.46 ns |   158.82 ns |   217.40 ns |   7,700.0000 ns |   81008 B |
|          ListGetAt | 10000 |     312.24 ns |    35.24 ns |   102.81 ns |     300.0000 ns |     976 B |
|          ListSetAt | 10000 |     127.84 ns |    26.67 ns |    77.38 ns |     100.0000 ns |     976 B |
|         ListRemove | 10000 |   3,625.03 ns |    77.57 ns |   129.60 ns |   3,650.0000 ns |     976 B |
|       ListRemoveAt | 10000 |     153.06 ns |    23.71 ns |    69.17 ns |     200.0000 ns |     976 B |
|        ListIndexOf | 10000 |   3,693.33 ns |    76.34 ns |   114.27 ns |   3,700.0000 ns |     976 B |
| LinkedListCreation | 10000 | 163,254.46 ns | 1,585.59 ns | 1,324.04 ns | 163,701.0000 ns |  481016 B |
|      LinkedListAdd | 10000 |   1,542.87 ns |    36.43 ns |    83.70 ns |   1,600.0000 ns |    1024 B |
|   LinkedListInsert | 10000 |  15,725.25 ns |   205.28 ns |   160.27 ns |  15,700.0000 ns |    1024 B |
|    LinkedListGetAt | 10000 |  28,421.50 ns |    78.98 ns |    70.02 ns |  28,400.0000 ns |     976 B |
|    LinkedListSetAt | 10000 |  28,215.46 ns |   118.29 ns |    98.78 ns |  28,200.0000 ns |     976 B |
| LinkedListRemoveAt | 10000 |  28,991.75 ns |   158.94 ns |   124.09 ns |  29,000.0000 ns |     976 B |
|   LinkedListRemove | 10000 |  28,050.07 ns |   151.70 ns |   134.48 ns |  28,050.0000 ns |     976 B |
|  LinkedListIndexOf | 10000 |  29,093.53 ns |   215.37 ns |   201.45 ns |  29,100.0000 ns |     976 B |
