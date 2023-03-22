using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Function;

[BenchmarkClass("Function")]
[Description("c# MethodInfo.Invoke performance")]
public class ReflectionInvoke {
      private readonly Action function = () => {};
      private readonly MethodInfo methodInfo;

      public ReflectionInvoke() {
            methodInfo = function.Method;
      }

      [Benchmark]
      public void ReflectionInvokePerformance() {
            methodInfo.Invoke(null, Array.Empty<object>());
      }
}
