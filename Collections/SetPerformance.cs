using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# HashSet performance")]
[BenchmarkClass("Collections")]
public class SetPerformance {
      private static HashSet<int> MakeSet(int size) {
            var set = new HashSet<int>(size);

            for (int i = 0; i < size; i++) {
                  set.Add(i);
            }
            return set;
      }

      private static IEnumerable<object[]> GetSet() {
            return new object[][] {
                  new object[] { MakeSet(0),0 },
                  new object[] { MakeSet(10),10 },
                  new object[] { MakeSet(100),100 },
                  new object[] { MakeSet(1000),1000 },
                  new object[] { MakeSet(1000),1000 },
                  new object[] { MakeSet(10000),10000 },
            };
      }

      [ArgumentsSource(nameof(GetSet))]
      [Benchmark]
      public static void Performance(HashSet<int> set, int next) {
            set.Add(next);
      }
}
