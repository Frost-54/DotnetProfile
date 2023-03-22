using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Activator.CreateInstance vs new performance")]
public class ActivatorVsNew {
      [Benchmark]
      public void NewObject() {
            _ = new object();
      }

      [Benchmark]
      public void ActivatorCreateObject() {
            Activator.CreateInstance<object>();
      }

      public class Custom {
            
      }

      [Benchmark]
      public void NewCustomObject() {
            _ = new Custom();
      }

      [Benchmark]
      public void ActivatorCreateCustomObject() {
            Activator.CreateInstance<Custom>();
      }
}
