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
      public void Performance(Dictionary<int, int> dictionary, int next) {
            dictionary.Add(next, next);
      }
}
