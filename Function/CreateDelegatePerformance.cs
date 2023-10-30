using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Function; 

[BenchmarkClass("Function")]
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
      public object CreateDelegateGeneric() {
            return staticMethodInfo.CreateDelegate<Hello>();
      }

      [Benchmark]
      public object CreateDelegateType() {
            return staticMethodInfo.CreateDelegate(typeof(Hello));
      }
      
      [Benchmark]
      public object CreateMemberDelegateGeneric() {
            return methodInfo.CreateDelegate<Hello>(helper);
      }

      [Benchmark]
      public object CreateMemberDelegateType() {
            return methodInfo.CreateDelegate(typeof(Hello), helper);
      }
}