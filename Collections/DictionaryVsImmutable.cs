using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# immutable dictionary vs dictionary performance")]
[BenchmarkClass("Collections")]
public class DictionaryVsImmutable {
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
      public void DictionaryPerformance(Dictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }

      private static ImmutableDictionary<int, int> MakeImmutableDictionary(int size) {
            var dict = ImmutableDictionary.CreateBuilder<int, int>();

            for (int i = 0; i < size; i++) {
                  dict.Add(i, i);
            }
            return dict.ToImmutable();
      }

      public static IEnumerable<object[]> GetImmutableDictionary() {
            return new object[][] {
                  new object[] { MakeImmutableDictionary(0),0 },
                  new object[] { MakeImmutableDictionary(10),10 },
                  new object[] { MakeImmutableDictionary(100),100 },
                  new object[] { MakeImmutableDictionary(1000),1000 },
                  new object[] { MakeImmutableDictionary(1000),1000 },
                  new object[] { MakeImmutableDictionary(10000),10000 },
            };
      }

      [ArgumentsSource(nameof(GetImmutableDictionary))]
      [Benchmark]
      public void ImmutableDictionaryPerformance(ImmutableDictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }
}
