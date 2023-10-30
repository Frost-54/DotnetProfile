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
      public object? ActivatorCreateObjectTypeof() {
            return Activator.CreateInstance(typeof(object));
      }

      [Benchmark]
      public object ActivatorCreateObjectGeneric() {
            return Activator.CreateInstance<object>();
      }

      public class Custom {
            
      }

      [Benchmark]
      public object NewCustomObject() {
            return new Custom();
      }

      [Benchmark]
      public object? ActivatorCreateCustomObjectTypeof() {
            return Activator.CreateInstance(typeof(Custom));
      }
      

      [Benchmark]
      public object ActivatorCreateCustomObjectGeneric() {
            return Activator.CreateInstance<Custom>();
      }
}
