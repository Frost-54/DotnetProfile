using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Type.GetField performance")]
public class TypeGetField {
      private readonly Type type = typeof(Console);

      private static IEnumerable<object> FlushCache() {
            GC.Collect();
            return Enumerable.Empty<object>();
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void Performance() {
            type.GetField(nameof(Console.Out));
      }
}
