using System.Collections;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# Hashtable performance")]
[BenchmarkClass("Collections")]
public class HashtablePerformance {
      public object? result;

      private static Hashtable MakeHashtable(int size) {
            var dict = new Hashtable(size);

            for (int i = 0; i < size; i++) {
                  dict.Add(i, i);
            }
            return dict;
      }

      public static IEnumerable<object[]> GetHashtable() {
            return new object[][] {
                  new object[] { MakeHashtable(0), 0, 0 - 1 },
                  new object[] { MakeHashtable(10), 10, 10 - 1 },
                  new object[] { MakeHashtable(100), 100, 100 - 1 },
                  new object[] { MakeHashtable(1000), 1000, 1000 - 1 },
                  new object[] { MakeHashtable(1000), 1000, 1000 - 1 },
                  new object[] { MakeHashtable(10000), 10000, 10000 - 1 },
            };
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void Add(Hashtable hashtable, object next, object last) {
            hashtable.Add(next, next);
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void AddBySquareBracket(Hashtable hashtable, object next, object last) {
            hashtable[next] = next;
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void Update(Hashtable hashtable, object next, object last) {
            hashtable[last] = next;
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void TryGetExistingValue(Hashtable hashtable, object a, object b) {
            result = hashtable[0];
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void TryGetNonExistingValue(Hashtable hashtable, object next, object last) {
            result = hashtable[next];
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void RemoveExisting(Hashtable hashtable, object next, object last) {
            hashtable.Remove(last);
      }

      [ArgumentsSource(nameof(GetHashtable))]
      [Benchmark]
      public void RemoveNonExisting(Hashtable hashtable, object next, object last) {
            hashtable.Remove(next);
      }
}
