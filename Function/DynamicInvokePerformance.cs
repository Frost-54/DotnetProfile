using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Function;

[Description("c# Delegate.DynamicInvoke performance")]
[BenchmarkClass("Function")]
public class DynamicInvokePerformance {
      private readonly Action function = () => {};

      public static void DynamicInvokeDelegate(Action func) {
            func.DynamicInvoke(Array.Empty<object>());
      }

      public static void CallDelegate(Action func) {
            func();
      }

      [Benchmark]
      public void DynamicInvoke() {
            DynamicInvokeDelegate(function);
      }

      [Benchmark]
      public void Call() {
            CallDelegate(function);
      }
}
