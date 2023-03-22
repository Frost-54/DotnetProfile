using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection;

[BenchmarkClass("Reflection")]
[Description("c# Type.GetEvent performance")]
public class TypeGetEvent {
      private readonly Type type = typeof(Console);

      private static IEnumerable<object> FlushCache() {
            GC.Collect();
            return Enumerable.Empty<object>();
      }

      [ArgumentsSource(nameof(FlushCache))]
      [Benchmark]
      public void Performance() {
            type.GetEvent(nameof(Console.CancelKeyPress));
      }
}
