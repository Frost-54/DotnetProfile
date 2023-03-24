# DotnetProfile
No 'should be', just run it. 

DotnetProfile is a collection of benchmarks.
It aims to answer questions like "Is a small `List<T>` better than `HashSet<T>?`" by running benchmarks.

## How to use this repository?
Benchmarks are grouped by categories. 
Each directory contains related benchmarks. 
Each source file represents a topic, such as SmallListVsSet, which answer "Is a small `List<T>` better than `HashSet<T>`?".

For each topic, a &lt;topic&gt;.md is generated. It contains the benchmark result.

Here are the benchmarks currently available:

* Collections: Benchmarks related to containers such as List, HashSet, Dictionary
* Function: Benchmarks related to functions, such as lambda and delegates
* Reflection: Benchmarks related to reflection, such as GetType(), GetMethod()
* Wrapper: benchmarks about if wrapping a built-in type(such as int, string) will be slower

## Adding new benchmarks
If your topic already exists, simply add a new benchmark in the existing class. 

Otherwise, follow this example to add a new topic.

### Example
For example, you want to create a topic `SmallListVsSet`.

First, create a new file named SmallListVsSet.cs. The file name should be the topic name. 

Then, create a class named `SmallListVsSet`. Again, it should match the topic name. 

```c#
[BenchmarkClass("Collections")]
class SmallListVsSet {

}
```

Each benchmark should have a `BenchmarkClass` attribute, with the location of the file as it's argument. Since `SmallListVsSet` is located in &lt;root&gt;/Collections. If your file is located in `A/B`, your attribute should be 

```c#
[BenchmarkClass("A/B")]
```

You *DO NOT* need to include your local benchmark result in your commit. Please delete your local `topic.md` file. Benchmarks are run on Github Actions and the `topic.md` is populated automatically. 

Also, benchmarks should be self-contained. Prefer copy and paste over creating base classes or shared functions.
