using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# Dictionary performance")]
[BenchmarkClass("Collections")]
public class DictionaryPerformance {
      private static Dictionary<int, int> MakeDictionary(int size) {
            var dict = new Dictionary<int, int>(size);

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
      public void Add(Dictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void AddBySquareBracket(Dictionary<int, int> dictionary, int next) {
            dictionary[next] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void Update(Dictionary<int, int> dictionary, int next) {
            dictionary[next - 1] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void TryGetExistingValue(Dictionary<int, int> dictionary, int _) {
            dictionary.TryGetValue(0, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void TryGetNonExistingValue(Dictionary<int, int> dictionary, int next) {
            dictionary.TryGetValue(next, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveExisting(Dictionary<int, int> dictionary, int next) {
            dictionary.Remove(next - 1);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveNonExisting(Dictionary<int, int> dictionary, int next) {
            dictionary.Remove(next);
      }
}
