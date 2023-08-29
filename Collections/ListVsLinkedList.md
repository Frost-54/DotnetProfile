C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  Job-YPAUQS : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |          Mean |       Error |      StdDev |       Median | Allocated |
|------------------- |------ |--------------:|------------:|------------:|-------------:|----------:|
|       **ListCreation** |    **10** |   **1,717.86 ns** |    **37.96 ns** |   **101.98 ns** |   **1,700.0 ns** |    **1192 B** |
|            ListAdd |    10 |   6,821.43 ns |   134.05 ns |   118.83 ns |   6,800.0 ns |   81008 B |
|         ListInsert |    10 |   7,399.94 ns |   153.20 ns |   150.47 ns |   7,400.0 ns |   81008 B |
|          ListGetAt |    10 |     182.65 ns |    30.15 ns |    87.96 ns |     150.0 ns |     976 B |
|          ListSetAt |    10 |     276.47 ns |    16.78 ns |    45.37 ns |     300.0 ns |     976 B |
|         ListRemove |    10 |  17,483.08 ns |   107.14 ns |    83.65 ns |  17,500.0 ns |     976 B |
|       ListRemoveAt |    10 |  17,156.93 ns |   105.84 ns |    93.82 ns |  17,199.5 ns |     976 B |
|        ListIndexOf |    10 |     415.15 ns |    33.87 ns |    99.35 ns |     400.0 ns |     976 B |
| LinkedListCreation |    10 |   1,474.53 ns |    33.08 ns |    73.31 ns |   1,500.0 ns |    1496 B |
|      LinkedListAdd |    10 |   1,466.67 ns |    34.96 ns |    80.32 ns |   1,500.0 ns |    1024 B |
|   LinkedListInsert |    10 |   1,388.52 ns |    31.43 ns |    70.94 ns |   1,400.0 ns |    1024 B |
|    LinkedListGetAt |    10 |     131.99 ns |    28.87 ns |    85.12 ns |     100.0 ns |     976 B |
|    LinkedListSetAt |    10 |     135.35 ns |    24.02 ns |    70.44 ns |     100.0 ns |     976 B |
| LinkedListRemoveAt |    10 |     221.98 ns |    20.21 ns |    59.60 ns |     200.0 ns |     976 B |
|   LinkedListRemove |    10 |     269.14 ns |    17.64 ns |    46.48 ns |     300.0 ns |     976 B |
|  LinkedListIndexOf |    10 |      89.53 ns |    11.32 ns |    30.79 ns |     100.0 ns |     976 B |
|       **ListCreation** |   **100** |   **2,192.70 ns** |    **48.82 ns** |   **140.85 ns** |   **2,200.0 ns** |    **2160 B** |
|            ListAdd |   100 |   6,573.27 ns |   136.93 ns |   128.09 ns |   6,600.0 ns |   81008 B |
|         ListInsert |   100 |   7,246.08 ns |    78.98 ns |    65.96 ns |   7,200.0 ns |   81008 B |
|          ListGetAt |   100 |     234.99 ns |    27.00 ns |    79.61 ns |     200.0 ns |     976 B |
|          ListSetAt |   100 |     185.99 ns |    20.46 ns |    60.32 ns |     200.0 ns |     976 B |
|         ListRemove |   100 |  17,600.00 ns |   171.37 ns |   151.91 ns |  17,600.0 ns |     976 B |
|       ListRemoveAt |   100 |  16,549.83 ns |   102.32 ns |    79.89 ns |  16,550.0 ns |     976 B |
|        ListIndexOf |   100 |     526.98 ns |    42.80 ns |   126.20 ns |     500.0 ns |     976 B |
| LinkedListCreation |   100 |   2,528.57 ns |    56.48 ns |    81.00 ns |   2,500.0 ns |    5816 B |
|      LinkedListAdd |   100 |   1,426.15 ns |    34.05 ns |    79.60 ns |   1,400.0 ns |    1024 B |
|   LinkedListInsert |   100 |   1,456.16 ns |    37.83 ns |   109.75 ns |   1,450.0 ns |    1024 B |
|    LinkedListGetAt |   100 |     369.98 ns |    18.35 ns |    54.11 ns |     400.0 ns |     976 B |
|    LinkedListSetAt |   100 |     477.00 ns |    22.01 ns |    64.91 ns |     500.0 ns |     976 B |
| LinkedListRemoveAt |   100 |     564.99 ns |    23.80 ns |    70.18 ns |     550.0 ns |     976 B |
|   LinkedListRemove |   100 |     545.92 ns |    24.70 ns |    72.04 ns |     600.0 ns |     976 B |
|  LinkedListIndexOf |   100 |     290.82 ns |    24.16 ns |    70.47 ns |     300.0 ns |     976 B |
|       **ListCreation** |  **1000** |   **5,551.81 ns** |   **114.31 ns** |   **160.25 ns** |   **5,600.0 ns** |    **9400 B** |
|            ListAdd |  1000 |   7,156.25 ns |   143.84 ns |   141.27 ns |   7,200.0 ns |   81008 B |
|         ListInsert |  1000 |   7,852.24 ns |   158.42 ns |   188.59 ns |   7,800.0 ns |   81008 B |
|          ListGetAt |  1000 |      69.15 ns |    22.42 ns |    63.97 ns |     100.0 ns |     976 B |
|          ListSetAt |  1000 |     245.99 ns |    25.70 ns |    75.76 ns |     300.0 ns |     976 B |
|         ListRemove |  1000 |  16,226.53 ns |   182.74 ns |   170.93 ns |  16,100.0 ns |     976 B |
|       ListRemoveAt |  1000 |  15,546.60 ns |   160.98 ns |   150.58 ns |  15,500.0 ns |     976 B |
|        ListIndexOf |  1000 |     803.00 ns |    42.42 ns |   125.09 ns |     800.0 ns |     976 B |
| LinkedListCreation |  1000 |  17,573.20 ns |   219.28 ns |   205.12 ns |  17,500.0 ns |   49016 B |
|      LinkedListAdd |  1000 |   1,504.00 ns |    34.95 ns |    70.60 ns |   1,500.0 ns |    1024 B |
|   LinkedListInsert |  1000 |   2,752.88 ns |    60.84 ns |    62.48 ns |   2,700.0 ns |    1024 B |
|    LinkedListGetAt |  1000 |   2,873.68 ns |    58.78 ns |    65.34 ns |   2,900.0 ns |     976 B |
|    LinkedListSetAt |  1000 |   3,004.45 ns |    63.86 ns |    78.43 ns |   3,000.0 ns |     976 B |
| LinkedListRemoveAt |  1000 |   3,037.44 ns |    62.97 ns |    61.85 ns |   3,000.0 ns |     976 B |
|   LinkedListRemove |  1000 |   3,057.89 ns |    62.30 ns |    69.25 ns |   3,100.0 ns |     976 B |
|  LinkedListIndexOf |  1000 |   2,774.07 ns |    54.52 ns |    76.42 ns |   2,800.0 ns |     976 B |
|       **ListCreation** | **10000** |  **37,228.50 ns** |   **739.72 ns** |   **655.75 ns** |  **37,100.0 ns** |  **132376 B** |
|            ListAdd | 10000 |   7,280.00 ns |   150.67 ns |   173.51 ns |   7,300.0 ns |   81008 B |
|         ListInsert | 10000 |   7,521.32 ns |   149.89 ns |   214.97 ns |   7,500.0 ns |   81008 B |
|          ListGetAt | 10000 |     218.00 ns |    29.08 ns |    85.73 ns |     200.0 ns |     976 B |
|          ListSetAt | 10000 |     170.71 ns |    24.96 ns |    73.20 ns |     200.0 ns |     976 B |
|         ListRemove | 10000 |   3,633.33 ns |    77.37 ns |    72.37 ns |   3,600.0 ns |     976 B |
|       ListRemoveAt | 10000 |     263.00 ns |    19.67 ns |    58.01 ns |     300.0 ns |     976 B |
|        ListIndexOf | 10000 |   3,397.06 ns |    69.86 ns |    71.74 ns |   3,350.0 ns |     976 B |
| LinkedListCreation | 10000 | 157,448.57 ns | 1,161.48 ns | 1,029.62 ns | 157,749.0 ns |  481016 B |
|      LinkedListAdd | 10000 |   1,303.19 ns |    29.28 ns |    83.54 ns |   1,300.0 ns |    1024 B |
|   LinkedListInsert | 10000 |  15,961.31 ns |   142.76 ns |   119.21 ns |  15,900.0 ns |    1024 B |
|    LinkedListGetAt | 10000 |  28,969.00 ns |   185.62 ns |   155.00 ns |  28,900.0 ns |     976 B |
|    LinkedListSetAt | 10000 |  28,900.00 ns |   196.92 ns |   153.74 ns |  28,900.0 ns |     976 B |
| LinkedListRemoveAt | 10000 |  28,969.15 ns |   171.96 ns |   143.59 ns |  29,000.0 ns |     976 B |
|   LinkedListRemove | 10000 |  27,550.00 ns |   153.27 ns |   135.87 ns |  27,500.0 ns |     976 B |
|  LinkedListIndexOf | 10000 |  27,613.07 ns |   133.23 ns |   124.63 ns |  27,600.0 ns |     976 B |
