using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# typeof() performance, c# GetType() performance")]
public class GetObjectType {
      public Type type = typeof(Type);

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
}
