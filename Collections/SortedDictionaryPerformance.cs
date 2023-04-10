using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# SortedDictionary performance")]
[BenchmarkClass("Collections")]
public class SortedDictionaryPerformance {
      private static SortedDictionary<int, int> MakeDictionary(int size) {
            var dict = new SortedDictionary<int, int>();

            for (int i = 0; i < size; i++) {
                  dict.Add(i, i);
            }
            return dict;
      }

      public static IEnumerable<object[]> GetDictionary() {
            return new object[][] {
                  new object[] { MakeDictionary(0),0 },
                  new object[] { MakeDictionary(10),10 },
                  new object[] { MakeDictionary(100),100 },
                  new object[] { MakeDictionary(1000),1000 },
                  new object[] { MakeDictionary(1000),1000 },
                  new object[] { MakeDictionary(10000),10000 },
            };
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void Add(SortedDictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void AddBySquareBracket(SortedDictionary<int, int> dictionary, int next) {
            dictionary[next] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void Update(SortedDictionary<int, int> dictionary, int next) {
            dictionary[next - 1] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void TryGetExistingValue(SortedDictionary<int, int> dictionary, int _) {
            dictionary.TryGetValue(0, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void TryGetNonExistingValue(SortedDictionary<int, int> dictionary, int next) {
            dictionary.TryGetValue(next, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveExisting(SortedDictionary<int, int> dictionary, int next) {
            dictionary.Remove(next - 1);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveNonExisting(SortedDictionary<int, int> dictionary, int next) {
            dictionary.Remove(next);
      }
}
