C# List<T> performance
``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  Job-JGETNC : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | Count |            Mean |         Error |        StdDev |          Median | Allocated |
|------------------- |------ |----------------:|--------------:|--------------:|----------------:|----------:|
|       **ListCreation** |    **10** |   **2,228.2828 ns** |    **80.1923 ns** |   **235.1901 ns** |   **2,200.0000 ns** |    **1192 B** |
|            ListAdd |    10 |   7,338.2353 ns |   149.6042 ns |   153.6325 ns |   7,350.0000 ns |   81008 B |
|         ListInsert |    10 |   8,556.6667 ns |   148.2803 ns |   138.7015 ns |   8,550.0000 ns |   81008 B |
|          ListGetAt |    10 |     284.7059 ns |    13.3922 ns |    36.2067 ns |     300.0000 ns |     976 B |
|          ListSetAt |    10 |     166.3265 ns |    21.9832 ns |    64.1260 ns |     200.0000 ns |     976 B |
|         ListRemove |    10 |  17,866.7333 ns |   164.9764 ns |   154.3190 ns |  17,900.0000 ns |     976 B |
|       ListRemoveAt |    10 |  16,942.9286 ns |   114.7000 ns |   101.6786 ns |  16,950.0000 ns |     976 B |
|        ListIndexOf |    10 |     489.0000 ns |    32.6570 ns |    96.2898 ns |     500.0000 ns |     976 B |
| LinkedListCreation |    10 |   1,660.8696 ns |    37.0464 ns |    89.4713 ns |   1,700.0000 ns |    1496 B |
|      LinkedListAdd |    10 |   1,641.1765 ns |    38.3176 ns |    91.8066 ns |   1,600.0000 ns |    1024 B |
|   LinkedListInsert |    10 |   1,464.1975 ns |    34.6391 ns |    91.2533 ns |   1,500.0000 ns |    1024 B |
|    LinkedListGetAt |    10 |     215.0000 ns |    36.5136 ns |   107.6611 ns |     200.0000 ns |     976 B |
|    LinkedListSetAt |    10 |     187.0000 ns |    21.9081 ns |    64.5967 ns |     150.0000 ns |     976 B |
| LinkedListRemoveAt |    10 |     247.0000 ns |    20.7086 ns |    61.0597 ns |     200.0000 ns |     976 B |
|   LinkedListRemove |    10 |     281.4433 ns |    26.0090 ns |    75.4568 ns |     300.0000 ns |     976 B |
|  LinkedListIndexOf |    10 |       0.0000 ns |     0.0000 ns |     0.0000 ns |       0.0000 ns |     976 B |
|       **ListCreation** |   **100** |   **2,788.4058 ns** |    **61.3066 ns** |   **148.0622 ns** |   **2,800.0000 ns** |    **2160 B** |
|            ListAdd |   100 |   7,427.7778 ns |   153.3899 ns |   323.5514 ns |   7,300.0000 ns |   81008 B |
|         ListInsert |   100 |   8,443.7500 ns |   170.2492 ns |   167.2075 ns |   8,450.0000 ns |   80336 B |
|          ListGetAt |   100 |     270.0000 ns |    27.2689 ns |    80.4030 ns |     250.0000 ns |     976 B |
|          ListSetAt |   100 |     253.5354 ns |    19.0611 ns |    55.9029 ns |     300.0000 ns |     976 B |
|         ListRemove |   100 |  17,780.0000 ns |   218.3458 ns |   204.2408 ns |  17,800.0000 ns |     976 B |
|       ListRemoveAt |   100 |  16,685.7143 ns |    84.0348 ns |    74.4946 ns |  16,650.0000 ns |     976 B |
|        ListIndexOf |   100 |     474.4787 ns |    24.0752 ns |    68.6878 ns |     500.0000 ns |     976 B |
| LinkedListCreation |   100 |   2,818.6047 ns |    59.1648 ns |   109.6658 ns |   2,800.0000 ns |    5816 B |
|      LinkedListAdd |   100 |   1,647.2222 ns |    36.4380 ns |    60.8798 ns |   1,600.0000 ns |    1024 B |
|   LinkedListInsert |   100 |   1,471.4286 ns |    32.0773 ns |    46.0044 ns |   1,500.0000 ns |    1024 B |
|    LinkedListGetAt |   100 |     421.0000 ns |    30.5998 ns |    90.2242 ns |     400.0000 ns |     976 B |
|    LinkedListSetAt |   100 |     428.0000 ns |    22.6513 ns |    66.7878 ns |     400.0000 ns |     976 B |
| LinkedListRemoveAt |   100 |     580.0000 ns |    21.0121 ns |    61.9547 ns |     600.0000 ns |     976 B |
|   LinkedListRemove |   100 |     447.3333 ns |     6.4180 ns |    16.2192 ns |     450.0000 ns |     976 B |
|  LinkedListIndexOf |   100 |     389.8305 ns |    13.7568 ns |    30.4841 ns |     400.0000 ns |     976 B |
|       **ListCreation** |  **1000** |   **6,281.5789 ns** |   **126.3343 ns** |   **217.9205 ns** |   **6,200.0000 ns** |    **9400 B** |
|            ListAdd |  1000 |   7,183.3333 ns |   140.6458 ns |   150.4894 ns |   7,200.0000 ns |   81008 B |
|         ListInsert |  1000 |   7,916.6667 ns |   161.4264 ns |   209.8999 ns |   7,900.0000 ns |   81008 B |
|          ListGetAt |  1000 |     206.0000 ns |    20.0617 ns |    59.1523 ns |     250.0000 ns |     976 B |
|          ListSetAt |  1000 |     241.4141 ns |    21.2377 ns |    62.2865 ns |     200.0000 ns |     976 B |
|         ListRemove |  1000 |  15,950.0000 ns |   123.1766 ns |   109.1928 ns |  15,950.0000 ns |     976 B |
|       ListRemoveAt |  1000 |  15,513.3333 ns |   184.5780 ns |   172.6543 ns |  15,500.0000 ns |     976 B |
|        ListIndexOf |  1000 |     846.8085 ns |    36.2369 ns |   103.3858 ns |     800.0000 ns |     976 B |
| LinkedListCreation |  1000 |  17,586.6667 ns |   126.9225 ns |   118.7234 ns |  17,600.0000 ns |   49016 B |
|      LinkedListAdd |  1000 |   1,679.7101 ns |    37.2922 ns |    90.0649 ns |   1,700.0000 ns |    1024 B |
|   LinkedListInsert |  1000 |   2,934.6154 ns |    60.9213 ns |    83.3897 ns |   2,950.0000 ns |    1024 B |
|    LinkedListGetAt |  1000 |   3,011.1111 ns |    65.2159 ns |    69.7802 ns |   3,050.0000 ns |     976 B |
|    LinkedListSetAt |  1000 |   2,956.2500 ns |    64.0598 ns |    62.9153 ns |   2,950.0000 ns |     976 B |
| LinkedListRemoveAt |  1000 |   3,056.2500 ns |    64.0598 ns |    62.9153 ns |   3,050.0000 ns |     976 B |
|   LinkedListRemove |  1000 |   3,025.9259 ns |    64.3909 ns |    90.2671 ns |   3,000.0000 ns |     976 B |
|  LinkedListIndexOf |  1000 |   2,871.4286 ns |    52.8845 ns |    46.8807 ns |   2,900.0000 ns |     976 B |
|       **ListCreation** | **10000** |  **38,506.6667 ns** |   **560.5716 ns** |   **524.3590 ns** |  **38,400.0000 ns** |  **132376 B** |
|            ListAdd | 10000 |   7,128.5714 ns |   135.8627 ns |   120.4388 ns |   7,150.0000 ns |   81008 B |
|         ListInsert | 10000 |   7,700.0000 ns |   146.8997 ns |   157.1810 ns |   7,700.0000 ns |   81008 B |
|          ListGetAt | 10000 |     251.5152 ns |    26.8406 ns |    78.7189 ns |     200.0000 ns |     976 B |
|          ListSetAt | 10000 |     249.0100 ns |    18.3497 ns |    54.1046 ns |     200.0000 ns |     976 B |
|         ListRemove | 10000 |   3,521.1538 ns |    73.8643 ns |   152.5426 ns |   3,500.0000 ns |     976 B |
|       ListRemoveAt | 10000 |     236.0000 ns |    21.2977 ns |    62.7968 ns |     200.0000 ns |     976 B |
|        ListIndexOf | 10000 |   3,473.6842 ns |    72.4861 ns |    80.5682 ns |   3,500.0000 ns |     976 B |
| LinkedListCreation | 10000 | 158,773.4667 ns | 1,379.2138 ns | 1,290.1174 ns | 159,000.0000 ns |  481016 B |
|      LinkedListAdd | 10000 |   1,670.3243 ns |    38.9173 ns |    66.0846 ns |   1,700.0000 ns |    1024 B |
|   LinkedListInsert | 10000 |  15,565.3846 ns |    66.4276 ns |    55.4700 ns |  15,550.0000 ns |    1024 B |
|    LinkedListGetAt | 10000 |  29,507.1429 ns |   169.7254 ns |   150.4572 ns |  29,550.0000 ns |     976 B |
|    LinkedListSetAt | 10000 |  28,900.1333 ns |   189.4384 ns |   177.2008 ns |  28,900.0000 ns |     976 B |
| LinkedListRemoveAt | 10000 |  28,923.1538 ns |   155.6923 ns |   130.0102 ns |  28,900.0000 ns |     976 B |
|   LinkedListRemove | 10000 |  27,078.5714 ns |   172.3823 ns |   152.8125 ns |  27,100.0000 ns |     976 B |
|  LinkedListIndexOf | 10000 |  27,200.0000 ns |   197.9516 ns |   185.1640 ns |  27,200.0000 ns |     976 B |
