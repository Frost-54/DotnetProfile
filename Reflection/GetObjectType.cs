using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# typeof() performance, c# GetType() performance")]
public class GetObjectType {
      public Type type = typeof(Type);
      private readonly Type cache = typeof(object);

      [Benchmark]
      public void TypeofPerformance() {
            type = typeof(GetObjectType);
      }

      [Benchmark]
      public void GetTypePerformance() {
            type = GetType();
      }

      [Benchmark]
      public void GetGenericTypePerformance() {
            type = typeof(IEnumerable<>);
      }

      [Benchmark]
      public void GetGenericTypeWithGenericParameterPerformance() {
            type = typeof(IEnumerable<int>);
      }

      [Benchmark]
      public void GetCached() {
            type = cache;
      }
}
