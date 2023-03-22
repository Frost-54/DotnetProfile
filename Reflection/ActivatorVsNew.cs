using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Activator.CreateInstance vs new performance")]
public class ActivatorVsNew {
      [Benchmark]
      public static void NewObject() {
            _ = new object();
      }

      [Benchmark]
      public static void ActivatorCreateObject() {
            Activator.CreateInstance<object>();
      }

      public class Custom {
            
      }

      [Benchmark]
      public static void NewCustomObject() {
            _ = new Custom();
      }

      [Benchmark]
      public static void ActivatorCreateCustomObject() {
            Activator.CreateInstance<Custom>();
      }
}
