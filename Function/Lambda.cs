using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Function;

[Description("C# lambda expression")]
[BenchmarkClass("Function")]
public class Lambda {
      private int result = 0;

      [Benchmark]
      public void ImmediatelyInvoke() {
            result = ((Func<int>)(() => {
                  return 0;
            }))();
      }

      [Benchmark]
      public void StaticImmediatelyInvoke() {
            result = ((Func<int>)(static () => {
                  return 0;
            }))();
      }

      [Benchmark]
      [Arguments(10)]
      public void ImmediatelyInvokeWithCapture(int n) {
            result = ((Func<int>)(() => {
                  return n;
            }))();
      }

      [Benchmark]
      public void Variable() {
            var func = () => {
                  return 0;
            };
            result = func();
      }

      [Benchmark]
      public void VariableStatic() {
            var func = static () => {
                  return 0;
            };
            result = func();
      }

      [Benchmark]
      public void RepeatedlyCalled() {
            var func = () => {
                  return 0;
            };
            result = func();
            result = func();
            result = func();
            result = func();
            result = func();
      }

      [Benchmark]
      public void RepeatedlyCalledStatic() {
            var func = static () => {
                  return 0;
            };
            result = func();
            result = func();
            result = func();
            result = func();
            result = func();
      }

      [Arguments(10)]
      [Benchmark]
      public void Sum(int n) {
            for (int i = 0; i < n; i++) {
                  result += i;
            }
      }

      [Arguments(10)]
      [Benchmark]
      public void SumWithLambda(int n) {
            result = ((Func<int, int>)((int n) => {
                  int result = 0;
                  for (int i = 0; i < n; i++) {
                        result += i;
                  }
                  return result;
            }))(n);
      }

      private void UseDelegate(Func<int> func) {
            result = func();
      }

      [Benchmark]
      public void LambdaDelegate() {
            UseDelegate(() => 0);
      }

      [Benchmark]
      public void StaticLambdaDelegate() {
            UseDelegate(static () => 0);
      }

      public static int GetInt() => 0;

      [Benchmark]
      public void StaticDelegate() {
            UseDelegate(GetInt);
      }

      public void Write() {
            Console.WriteLine(result);
      }
}
