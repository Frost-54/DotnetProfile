using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# ListDictionary vs Dictionary")]
[BenchmarkClass("Collections")]
public class SmallListDictionaryVsDictionary {
      private IEnumerable<object> GetDictionary() {
            int n = 0;
            Span<int> sizes = stackalloc int[] {
                  2, 4, 6, 8, 10
            };
            var dicts = new object[sizes.Length];

            foreach (var size in sizes) {
                  var dictionary = new Dictionary<int, int>(size);
                  
                  for (int i = 0; i < size; i++) {
                        dictionary.Add(i, i);
                  }
                  dicts[n++] = dictionary;
            }

            return dicts;
      }

      private static ListDictionary GetListDictionary(int size) {
            var dict = new ListDictionary();

            for (int i = 0; i < size; i++) {
                  dict.Add(i, i);
            }
            return dict;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryAdd(Dictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryAddBySquareBracket(Dictionary<int, int> dictionary, int next) {
            dictionary[next] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryUpdate(Dictionary<int, int> dictionary, int next) {
            dictionary[next - 1] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryTryGetExistingValue(Dictionary<int, int> dictionary, int _) {
            dictionary.TryGetValue(0, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryTryGetNonExistingValue(Dictionary<int, int> dictionary, int next) {
            dictionary.TryGetValue(next, out var _);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryRemoveExisting(Dictionary<int, int> dictionary, int next) {
            dictionary.Remove(next - 1);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void DictionaryRemoveNonExisting(Dictionary<int, int> dictionary, int next) {
            dictionary.Remove(next);
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public void ListDictionaryAdd(ListDictionary dictionary, int next) {
            dictionary.Add(next, next);
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public void ListDictionaryAddBySquareBracket(ListDictionary dictionary, int next) {
            dictionary[next] = next;
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public void ListDictionaryUpdate(ListDictionary dictionary, int next) {
            dictionary[next - 1] = next;
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public object? TryGetExistingValue(ListDictionary dictionary, int _) {
            return dictionary[0];
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public object? TryGetNonExistingValue(ListDictionary dictionary, int next) {
            return dictionary[next];
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public void ListDictionaryRemoveExisting(ListDictionary dictionary, int next) {
            dictionary.Remove(next - 1);
      }

      [ArgumentsSource(nameof(GetListDictionary))]
      [Benchmark]
      public void ListDictionaryRemoveNonExisting(ListDictionary dictionary, int next) {
            dictionary.Remove(next);
      }
}
