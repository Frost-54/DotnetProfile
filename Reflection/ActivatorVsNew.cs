namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Activator.CreateInstance vs new performance")]
public class ActivatorVsNew {
      public static void NewObject() {
            _ = new object();
      }

      public static void ActivatorCreateObject() {
            Activator.CreateInstance<object>();
      }

      public class Custom {
            
      }

      public static void NewCustomObject() {
            _ = new Custom();
      }

      public static void ActivatorCreateCustomObject() {
            Activator.CreateInstance<Custom>();
      }
}
