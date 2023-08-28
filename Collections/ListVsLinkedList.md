C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  Job-AUSYLB : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |         Mean |       Error |       StdDev |       Median | Allocated |
|------------------- |------ |-------------:|------------:|-------------:|-------------:|----------:|
|       **ListCreation** |    **10** |   **2,835.4 ns** |   **121.94 ns** |    **351.84 ns** |   **2,800.0 ns** |    **1192 B** |
|            ListAdd |    10 |  10,135.9 ns |   208.61 ns |    483.49 ns |  10,100.0 ns |   81008 B |
|         ListInsert |    10 |  11,871.4 ns |   203.28 ns |    371.70 ns |  11,800.0 ns |   81008 B |
|          ListGetAt |    10 |     245.2 ns |    30.09 ns |     85.36 ns |     200.0 ns |     976 B |
|          ListSetAt |    10 |     238.5 ns |    29.91 ns |     86.29 ns |     250.0 ns |     976 B |
|         ListRemove |    10 |   3,238.7 ns |    81.52 ns |    231.27 ns |   3,200.0 ns |     976 B |
|       ListRemoveAt |    10 |   2,765.0 ns |    60.83 ns |    159.19 ns |   2,800.0 ns |     976 B |
|        ListIndexOf |    10 |     439.8 ns |    31.24 ns |     88.64 ns |     400.0 ns |     976 B |
| LinkedListCreation |    10 |   1,888.4 ns |    79.85 ns |    234.18 ns |   1,850.0 ns |    1496 B |
|      LinkedListAdd |    10 |   2,190.8 ns |   123.56 ns |    360.44 ns |   2,200.0 ns |    1024 B |
|   LinkedListInsert |    10 |   1,928.9 ns |    68.21 ns |    197.88 ns |   1,900.0 ns |    1024 B |
|    LinkedListGetAt |    10 |     109.2 ns |    27.45 ns |     80.06 ns |     100.0 ns |     976 B |
|    LinkedListSetAt |    10 |     213.1 ns |    29.08 ns |     85.29 ns |     200.0 ns |     976 B |
| LinkedListRemoveAt |    10 |     425.8 ns |    37.51 ns |    103.93 ns |     400.0 ns |     976 B |
|   LinkedListRemove |    10 |     289.9 ns |    34.95 ns |    102.51 ns |     300.0 ns |     976 B |
|  LinkedListIndexOf |    10 |     218.4 ns |    26.21 ns |     76.45 ns |     200.0 ns |     976 B |
|       **ListCreation** |   **100** |   **2,980.9 ns** |   **165.30 ns** |    **471.62 ns** |   **2,900.0 ns** |    **2160 B** |
|            ListAdd |   100 |  15,810.0 ns | 3,094.24 ns |  9,123.44 ns |  10,350.0 ns |   81008 B |
|         ListInsert |   100 |  22,198.9 ns | 3,286.54 ns |  9,638.85 ns |  28,700.0 ns |   81008 B |
|          ListGetAt |   100 |     260.2 ns |    30.81 ns |     87.40 ns |     200.0 ns |     976 B |
|          ListSetAt |   100 |     214.1 ns |    44.11 ns |    129.37 ns |     200.0 ns |     976 B |
|         ListRemove |   100 |   3,467.7 ns |    93.89 ns |    270.88 ns |   3,400.0 ns |     976 B |
|       ListRemoveAt |   100 |   2,870.1 ns |    72.64 ns |    210.73 ns |   2,900.0 ns |     976 B |
|        ListIndexOf |   100 |     603.1 ns |    50.31 ns |    146.75 ns |     600.0 ns |     976 B |
| LinkedListCreation |   100 |   3,167.0 ns |    94.09 ns |    272.98 ns |   3,100.0 ns |    5816 B |
|      LinkedListAdd |   100 |   2,004.2 ns |   102.53 ns |    292.53 ns |   2,000.0 ns |    1024 B |
|   LinkedListInsert |   100 |   2,145.3 ns |    67.78 ns |    194.48 ns |   2,100.0 ns |    1024 B |
|    LinkedListGetAt |   100 |     634.0 ns |    30.62 ns |     88.84 ns |     600.0 ns |     976 B |
|    LinkedListSetAt |   100 |     605.1 ns |    28.56 ns |     83.76 ns |     600.0 ns |     976 B |
| LinkedListRemoveAt |   100 |     868.5 ns |    36.01 ns |    101.56 ns |     900.0 ns |     976 B |
|   LinkedListRemove |   100 |     838.5 ns |    33.10 ns |     92.82 ns |     800.0 ns |     976 B |
|  LinkedListIndexOf |   100 |     589.7 ns |    25.60 ns |     74.28 ns |     600.0 ns |     976 B |
|       **ListCreation** |  **1000** |   **6,101.6 ns** |   **216.16 ns** |    **606.15 ns** |   **5,950.0 ns** |    **9400 B** |
|            ListAdd |  1000 |   9,719.3 ns |   197.46 ns |    449.71 ns |   9,750.0 ns |   81008 B |
|         ListInsert |  1000 |  18,483.8 ns | 3,248.90 ns |  9,528.45 ns |  12,700.0 ns |   81008 B |
|          ListGetAt |  1000 |     241.2 ns |    33.65 ns |     97.63 ns |     200.0 ns |     976 B |
|          ListSetAt |  1000 |     282.0 ns |    43.22 ns |    127.43 ns |     300.0 ns |     976 B |
|         ListRemove |  1000 |   2,966.6 ns |   134.36 ns |    381.15 ns |   2,900.0 ns |     976 B |
|       ListRemoveAt |  1000 |   2,333.3 ns |    75.73 ns |    214.84 ns |   2,300.0 ns |     976 B |
|        ListIndexOf |  1000 |     904.1 ns |    40.39 ns |    117.19 ns |     900.0 ns |     976 B |
| LinkedListCreation |  1000 |  27,343.9 ns | 3,513.56 ns | 10,359.81 ns |  21,600.0 ns |   49016 B |
|      LinkedListAdd |  1000 |   2,028.4 ns |    66.41 ns |    190.56 ns |   2,000.0 ns |    1024 B |
|   LinkedListInsert |  1000 |   4,003.2 ns |   145.75 ns |    413.48 ns |   4,000.0 ns |    1024 B |
|    LinkedListGetAt |  1000 |   3,945.6 ns |    84.57 ns |    160.90 ns |   3,950.0 ns |     976 B |
|    LinkedListSetAt |  1000 |   4,303.3 ns |    89.14 ns |     83.38 ns |   4,350.0 ns |     976 B |
| LinkedListRemoveAt |  1000 |   4,227.3 ns |    84.03 ns |    103.20 ns |   4,200.0 ns |     976 B |
|   LinkedListRemove |  1000 |   4,197.3 ns |    88.32 ns |    149.97 ns |   4,200.0 ns |     976 B |
|  LinkedListIndexOf |  1000 |   3,938.1 ns |    84.71 ns |    194.63 ns |   3,900.0 ns |     976 B |
|       **ListCreation** | **10000** |  **47,270.3 ns** | **3,909.04 ns** | **11,402.87 ns** |  **41,350.0 ns** |  **132376 B** |
|            ListAdd | 10000 |  10,164.4 ns |   401.05 ns |  1,020.80 ns |  10,000.0 ns |   81008 B |
|         ListInsert | 10000 |  15,692.0 ns | 2,642.39 ns |  7,791.16 ns |  11,050.0 ns |   81008 B |
|          ListGetAt | 10000 |     324.7 ns |    31.47 ns |     89.27 ns |     300.0 ns |     976 B |
|          ListSetAt | 10000 |     243.9 ns |    43.91 ns |    128.08 ns |     250.0 ns |     976 B |
|         ListRemove | 10000 |   3,564.9 ns |   113.86 ns |    324.84 ns |   3,500.0 ns |     976 B |
|       ListRemoveAt | 10000 |     237.5 ns |    65.42 ns |    188.76 ns |     200.0 ns |     976 B |
|        ListIndexOf | 10000 |   3,471.1 ns |    77.33 ns |    147.13 ns |   3,500.0 ns |     976 B |
| LinkedListCreation | 10000 | 220,363.2 ns | 5,605.60 ns | 15,993.10 ns | 213,699.5 ns |  481016 B |
|      LinkedListAdd | 10000 |   2,006.3 ns |    57.47 ns |    164.90 ns |   2,000.0 ns |    1024 B |
|   LinkedListInsert | 10000 |  30,130.5 ns | 3,338.77 ns |  9,739.35 ns |  35,300.0 ns |    1024 B |
|    LinkedListGetAt | 10000 |  37,813.2 ns | 3,691.62 ns | 10,768.63 ns |  31,700.0 ns |     976 B |
|    LinkedListSetAt | 10000 |  42,758.6 ns | 4,200.33 ns | 12,185.91 ns |  46,699.0 ns |     976 B |
| LinkedListRemoveAt | 10000 |  39,568.6 ns | 3,608.38 ns | 10,582.76 ns |  32,800.0 ns |     976 B |
|   LinkedListRemove | 10000 |  45,298.8 ns | 4,106.40 ns | 11,913.40 ns |  48,500.0 ns |     976 B |
|  LinkedListIndexOf | 10000 |  39,936.9 ns | 3,889.80 ns | 11,469.16 ns |  31,700.0 ns |     976 B |
