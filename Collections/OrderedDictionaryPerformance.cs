using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# OrderedDictionary performance")]
[BenchmarkClass("Collections")]
public class OrderedDictionaryPerformance {
      private static OrderedDictionary MakeDictionary(int size) {
            var dict = new OrderedDictionary(size);

            for (int i = 0; i < size; i++) {
                  dict.Add(i, i);
            }
            return dict;
      }

      public static IEnumerable<object[]> GetDictionary() {
            return new object[][] {
                  new object[] { MakeDictionary(0),0 },
                  new object[] { MakeDictionary(10),10 },
                  new object[] { MakeDictionary(20),20 },
                  new object[] { MakeDictionary(40),40 },
                  new object[] { MakeDictionary(80),80 },
                  new object[] { MakeDictionary(100),100 },
                  new object[] { MakeDictionary(1000),1000 },
                  new object[] { MakeDictionary(1000),1000 },
                  new object[] { MakeDictionary(10000),10000 },
            };
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void Add(OrderedDictionary dictionary, int next) {
            dictionary.Add(next, next);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void AddBySquareBracket(OrderedDictionary dictionary, int next) {
            dictionary[next] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void Update(OrderedDictionary dictionary, int next) {
            dictionary[next - 1] = next;
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public object? TryGetExistingValue(OrderedDictionary dictionary, int _) {
            return dictionary[0];
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public object? TryGetNonExistingValue(OrderedDictionary dictionary, int next) {
            return dictionary[next];
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveExisting(OrderedDictionary dictionary, int next) {
            dictionary.Remove(next - 1);
      }

      [ArgumentsSource(nameof(GetDictionary))]
      [Benchmark]
      public void RemoveNonExisting(OrderedDictionary dictionary, int next) {
            dictionary.Remove(next);
      }
}
