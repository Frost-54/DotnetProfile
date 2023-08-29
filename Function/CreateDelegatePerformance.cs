using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Function; 

[BenchmarkClass("Reflection")]
[Description("C# MethodInfo.CreateDelegate performance")]
public class CreateDelegatePerformance {
      private readonly MethodInfo staticMethodInfo = typeof(Helper)
            .GetMethod(nameof(Helper.Hello1)) ?? throw new Exception("");
      private readonly MethodInfo methodInfo = typeof(Helper)
            .GetMethod(nameof(Helper.Hello2)) ?? throw new Exception("");

      private readonly Helper helper = new();
      
      private class Helper {
            public static void Hello1() {
                  
            }
            
            public void Hello2() {
                  
            }
      }

      private delegate void Hello();
      
      [Benchmark]
      public void CreateDelegateGeneric() {
            staticMethodInfo.CreateDelegate<Hello>()();
      }

      [Benchmark]
      public void CreateDelegateType() {
            staticMethodInfo.CreateDelegate(typeof(Hello))
                  .DynamicInvoke();
      }
      
      [Benchmark]
      public void CreateMemberDelegateGeneric() {
            methodInfo.CreateDelegate<Hello>(helper)();
      }

      [Benchmark]
      public void CreateMemberDelegateType() {
            methodInfo.CreateDelegate(typeof(Hello), helper)
                  .DynamicInvoke();
      }
}