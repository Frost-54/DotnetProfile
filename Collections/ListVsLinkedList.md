C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-IMKWCR : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |          Mean |        Error |       StdDev |        Median | Allocated |
|------------------- |------ |--------------:|-------------:|-------------:|--------------:|----------:|
|       **ListCreation** |    **10** |   **2,208.92 ns** |   **103.678 ns** |   **292.426 ns** |   **2,314.00 ns** |    **1192 B** |
|            ListAdd |    10 |   5,658.98 ns |   264.926 ns |   764.371 ns |   5,595.50 ns |   81008 B |
|         ListInsert |    10 |   7,127.65 ns |   435.710 ns | 1,270.985 ns |   7,084.00 ns |   81008 B |
|          ListGetAt |    10 |     137.88 ns |     7.612 ns |     7.817 ns |     141.00 ns |     976 B |
|          ListSetAt |    10 |      70.93 ns |     6.070 ns |    15.561 ns |      65.50 ns |     976 B |
|         ListRemove |    10 |   1,570.00 ns |    27.034 ns |    23.965 ns |   1,567.50 ns |     976 B |
|       ListRemoveAt |    10 |   1,304.12 ns |    30.396 ns |    81.658 ns |   1,287.50 ns |     976 B |
|        ListIndexOf |    10 |     553.86 ns |    72.595 ns |   211.764 ns |     440.50 ns |     976 B |
| LinkedListCreation |    10 |   1,070.36 ns |    25.422 ns |    61.396 ns |   1,072.00 ns |    1496 B |
|      LinkedListAdd |    10 |   1,488.97 ns |   132.325 ns |   385.997 ns |   1,362.00 ns |    1024 B |
|   LinkedListInsert |    10 |   1,510.51 ns |   114.448 ns |   332.035 ns |   1,584.00 ns |    1024 B |
|    LinkedListGetAt |    10 |      74.30 ns |     9.246 ns |    25.621 ns |      70.00 ns |     976 B |
|    LinkedListSetAt |    10 |     107.53 ns |    11.610 ns |    33.124 ns |      95.00 ns |     976 B |
| LinkedListRemoveAt |    10 |     190.19 ns |     8.487 ns |     7.087 ns |     190.50 ns |     976 B |
|   LinkedListRemove |    10 |     218.31 ns |     8.967 ns |    19.870 ns |     220.00 ns |     976 B |
|  LinkedListIndexOf |    10 |     140.62 ns |    10.152 ns |    26.387 ns |     141.00 ns |     976 B |
|       **ListCreation** |   **100** |   **2,037.44 ns** |    **62.306 ns** |   **172.650 ns** |   **1,983.00 ns** |    **2160 B** |
|            ListAdd |   100 |   5,418.84 ns |   113.766 ns |   242.445 ns |   5,339.00 ns |   81008 B |
|         ListInsert |   100 |   6,414.42 ns |   322.025 ns |   913.532 ns |   6,402.00 ns |   81008 B |
|          ListGetAt |   100 |     145.56 ns |     7.858 ns |    18.523 ns |     140.00 ns |     976 B |
|          ListSetAt |   100 |     216.19 ns |    35.007 ns |    95.239 ns |     170.00 ns |     976 B |
|         ListRemove |   100 |   2,766.32 ns |   128.475 ns |   362.366 ns |   2,655.00 ns |     976 B |
|       ListRemoveAt |   100 |   2,465.88 ns |   243.265 ns |   709.616 ns |   2,389.50 ns |     976 B |
|        ListIndexOf |   100 |     294.32 ns |    13.662 ns |    37.398 ns |     280.00 ns |     976 B |
| LinkedListCreation |   100 |   3,585.38 ns |    77.562 ns |    76.176 ns |   3,607.00 ns |    5816 B |
|      LinkedListAdd |   100 |   1,619.48 ns |   118.251 ns |   348.667 ns |   1,743.00 ns |    1024 B |
|   LinkedListInsert |   100 |   1,610.35 ns |   102.436 ns |   293.907 ns |   1,722.50 ns |    1024 B |
|    LinkedListGetAt |   100 |     217.97 ns |     9.816 ns |    16.669 ns |     221.00 ns |     976 B |
|    LinkedListSetAt |   100 |     223.09 ns |     9.159 ns |    20.295 ns |     220.50 ns |     976 B |
| LinkedListRemoveAt |   100 |     568.19 ns |    81.968 ns |   239.105 ns |     476.00 ns |     976 B |
|   LinkedListRemove |   100 |     345.71 ns |    11.673 ns |    25.623 ns |     341.00 ns |     976 B |
|  LinkedListIndexOf |   100 |     238.50 ns |    10.204 ns |    20.142 ns |     241.00 ns |     976 B |
|       **ListCreation** |  **1000** |   **3,407.26 ns** |    **71.863 ns** |   **153.145 ns** |   **3,376.50 ns** |    **9400 B** |
|            ListAdd |  1000 |   6,545.00 ns |   462.784 ns | 1,349.962 ns |   6,643.00 ns |   81008 B |
|         ListInsert |  1000 |   6,873.57 ns |   195.235 ns |   547.460 ns |   6,782.50 ns |   81008 B |
|          ListGetAt |  1000 |     201.16 ns |    22.738 ns |    64.872 ns |     179.50 ns |     976 B |
|          ListSetAt |  1000 |     193.78 ns |     8.813 ns |    22.109 ns |     190.00 ns |     976 B |
|         ListRemove |  1000 |   2,975.13 ns |   104.328 ns |   302.674 ns |   2,975.00 ns |     976 B |
|       ListRemoveAt |  1000 |   1,726.19 ns |   215.163 ns |   624.228 ns |   1,412.00 ns |     976 B |
|        ListIndexOf |  1000 |     488.00 ns |     7.896 ns |     6.164 ns |     490.00 ns |     976 B |
| LinkedListCreation |  1000 |  14,640.22 ns |   215.247 ns |   472.472 ns |  14,497.50 ns |   49016 B |
|      LinkedListAdd |  1000 |   1,133.71 ns |    27.077 ns |    49.512 ns |   1,122.50 ns |    1024 B |
|   LinkedListInsert |  1000 |   2,088.65 ns |   113.352 ns |   325.227 ns |   1,944.00 ns |    1024 B |
|    LinkedListGetAt |  1000 |   1,484.38 ns |    22.476 ns |    18.768 ns |   1,482.00 ns |     976 B |
|    LinkedListSetAt |  1000 |   2,147.63 ns |   106.772 ns |   301.154 ns |   2,235.00 ns |     976 B |
| LinkedListRemoveAt |  1000 |   1,988.57 ns |   119.776 ns |   347.493 ns |   1,995.00 ns |     976 B |
|   LinkedListRemove |  1000 |   2,941.86 ns |    64.181 ns |    78.820 ns |   2,931.00 ns |     976 B |
|  LinkedListIndexOf |  1000 |   1,576.64 ns |    26.491 ns |    44.260 ns |   1,563.00 ns |     976 B |
|       **ListCreation** | **10000** |  **29,185.17 ns** | **1,963.730 ns** | **5,759.279 ns** |  **30,376.00 ns** |  **132376 B** |
|            ListAdd | 10000 |   5,784.10 ns |   322.700 ns |   931.064 ns |   5,715.00 ns |   81008 B |
|         ListInsert | 10000 |   5,845.55 ns |   329.947 ns |   962.471 ns |   5,541.00 ns |   81008 B |
|          ListGetAt | 10000 |     177.32 ns |    54.057 ns |   150.691 ns |     110.00 ns |     976 B |
|          ListSetAt | 10000 |     134.75 ns |    21.812 ns |    61.877 ns |     110.50 ns |     976 B |
|         ListRemove | 10000 |   3,574.64 ns |    76.462 ns |   200.087 ns |   3,531.00 ns |     976 B |
|       ListRemoveAt | 10000 |     169.98 ns |    29.478 ns |    84.103 ns |     170.00 ns |     976 B |
|        ListIndexOf | 10000 |   2,136.68 ns |    62.377 ns |   175.934 ns |   2,064.50 ns |     976 B |
| LinkedListCreation | 10000 | 134,830.00 ns | 1,510.996 ns | 1,179.686 ns | 134,525.50 ns |  481016 B |
|      LinkedListAdd | 10000 |   1,181.46 ns |    29.450 ns |    80.620 ns |   1,172.00 ns |    1024 B |
|   LinkedListInsert | 10000 |   9,355.99 ns |   383.886 ns | 1,089.020 ns |   9,297.00 ns |    1024 B |
|    LinkedListGetAt | 10000 |  13,680.83 ns |   149.827 ns |   116.975 ns |  13,630.00 ns |     976 B |
|    LinkedListSetAt | 10000 |  16,517.04 ns |   401.597 ns | 1,085.740 ns |  16,521.00 ns |     976 B |
| LinkedListRemoveAt | 10000 |  13,774.15 ns |    66.129 ns |    55.221 ns |  13,775.00 ns |     976 B |
|   LinkedListRemove | 10000 |  15,283.62 ns |   263.582 ns |   481.975 ns |  15,098.00 ns |     976 B |
|  LinkedListIndexOf | 10000 |  15,142.65 ns |   284.544 ns |   513.092 ns |  14,967.50 ns |     976 B |
