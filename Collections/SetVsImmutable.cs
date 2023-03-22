using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# ImmutableHashSet vs HashSet performance")]
[BenchmarkClass("Collections")]
public class SetVsImmutable {
      private static HashSet<int> MakeSet(int size) {
            var set = new HashSet<int>(size);

            for (int i = 0; i < size; i++) {
                  set.Add(i);
            }
            return set;
      }

      public static IEnumerable<object[]> GetSet() {
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
      public static void SetPerformance(HashSet<int> set, int next) {
            set.Add(next);
      }

      private static ImmutableHashSet<int> MakeImmutableSet(int size) {
            var set = ImmutableHashSet.CreateBuilder<int>();

            for (int i = 0; i < size; i++) {
                  set.Add(i);
            }
            return set.ToImmutable();
      }

      public static IEnumerable<object[]> GetImmutableSet() {
            return new object[][] {
                  new object[] { MakeImmutableSet(0),0 },
                  new object[] { MakeImmutableSet(10),10 },
                  new object[] { MakeImmutableSet(100),100 },
                  new object[] { MakeImmutableSet(1000),1000 },
                  new object[] { MakeImmutableSet(1000),1000 },
                  new object[] { MakeImmutableSet(10000),10000 },
            };
      }

      [ArgumentsSource(nameof(GetImmutableSet))]
      [Benchmark]
      public static void ImmutableSetPerformance(ImmutableHashSet<int> set, int next) {
            set.Add(next);
      }
}
