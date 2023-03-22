using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# StackTrace performance")]
public class StackTracePerformance {
      [Benchmark]
      public void Performance() {
            new StackTrace().GetFrames();
      }
}
