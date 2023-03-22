using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Type.GetMethod performance")]
public class TypeGetMethod {
      private readonly Type type = typeof(Console);
      private readonly Type typeofSelf = typeof(TypeGetMethod);

      private static IEnumerable<object> FlushCache() {
            GC.Collect();
            return Enumerable.Empty<object>();
      }

      public static T? DoSomething<T>() {
            return default;
      }

      public static T? DoSomethingWithOverload<T>() {
            return default;
      }

      public static T? DoSomethingWithOverload<T>(T a) {
            return default;
      }

      public static T? DoSomethingWithOverload<T>(T a, T b) {
            return default;
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void GetMethodWithoutOverload() {
            type.GetMethod(nameof(Console.Clear));
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void GetMethodFewOfOverload() {
            type.GetMethod(nameof(Console.ReadKey), new[] {
                  typeof(bool)
            });
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void GetMethodALotOfOverload() {
            type.GetMethod(nameof(Console.WriteLine), new[] {
                  typeof(string)
            });
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void GetMethodGeneric() {
            typeofSelf.GetMethod(
                  nameof(DoSomething),
                  1,
                  Type.EmptyTypes
            );
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void GetMethodGenericWithOverload() {
            _ = typeofSelf.GetMethods().Single(func => {
                  return func.Name == nameof(DoSomethingWithOverload)
                        && func.GetParameters().Length == 1
                        && func.GetParameters()[0].ParameterType == func.GetGenericArguments()[0];
            });
      }
}
