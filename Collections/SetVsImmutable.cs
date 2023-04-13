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
      public void SetAdd(HashSet<int> set, int next) {
            set.Add(next);
      }

      [ArgumentsSource(nameof(GetSet))]
      [Benchmark]
      public bool SetFindExisting(HashSet<int> set, int next) {
            return set.Contains(next - 1);
      }

      [ArgumentsSource(nameof(GetSet))]
      [Benchmark]
      public bool SetFindNonexisting(HashSet<int> set, int next) {
            return set.Contains(next);
      }

      [ArgumentsSource(nameof(GetSet))]
      [Benchmark]
      public void SetRemoveNonexisting(HashSet<int> set, int next) {
            set.Remove(next);
      }

      [ArgumentsSource(nameof(GetSet))]
      [Benchmark]
      public void SetRemoveExisting(HashSet<int> set, int next) {
            set.Remove(next - 1);
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
      public void ImmutableSetAdd(ImmutableHashSet<int> set, int next) {
            set.Add(next);
      }

      [ArgumentsSource(nameof(GetImmutableSet))]
      [Benchmark]
      public bool ImmutableSetFindExisting(ImmutableHashSet<int> set, int next) {
            return set.Contains(next - 1);
      }

      [ArgumentsSource(nameof(GetImmutableSet))]
      [Benchmark]
      public bool ImmutableSetFindNonexisting(ImmutableHashSet<int> set, int next) {
            return set.Contains(next);
      }

      [ArgumentsSource(nameof(GetImmutableSet))]
      [Benchmark]
      public void ImmutableSetRemoveNonexisting(ImmutableHashSet<int> set, int next) {
            set.Remove(next);
      }

      [ArgumentsSource(nameof(GetImmutableSet))]
      [Benchmark]
      public void ImmutableSetRemoveExisting(ImmutableHashSet<int> set, int next) {
            set.Remove(next - 1);
      }
}
