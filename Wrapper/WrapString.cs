using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Wrapper;

[BenchmarkClass("Wrapper")]
[Description("Will wrapping a string in a struct be slower c#")]
public class WrapString {
      private readonly Dictionary<string, int> stringDictionary = new() {
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
            { MakeString(9999), 0 },
      };
      private readonly HashSet<string> stringSet = new() {
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
            MakeString(9999),
      };
       private readonly Dictionary<Wrapper, int> wrapperDictionary = new() {
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
            { new(MakeString(9999)), 0 },
      };
      private readonly HashSet<Wrapper> wrapperSet = new() {
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
            new(MakeString(9999)),
      };
      
      private readonly string stringCompare = MakeString(9999);
      private readonly Wrapper wrapperCompare = new(MakeString(9999));
      public bool result;

      public readonly struct Wrapper : IEquatable<Wrapper> {
            private readonly string value;

            public Wrapper(string value) {
                  this.value = value;
            }

            public bool Equals(Wrapper other) {
                  return other.value == value;
            }

            public override bool Equals(object?obj) {
                  if (obj is not Wrapper wrapper) {
                        return false;
                  }
                  return wrapper.value == value;
            }

            public override int GetHashCode() {
                  return value.GetHashCode();
            }

            public static bool operator==(Wrapper lhs, Wrapper rhs) {
                  return lhs.value == rhs.value;
            }

            public static bool operator!=(Wrapper lhs, Wrapper rhs) {
                  return lhs.value != rhs.value;
            }
      }

      private static string MakeString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
      }

      public static IEnumerable<object> MakeStringData() {
            for (int i = 10; i < 10000; i *= 10) {
                  yield return MakeString(i);
            }
      }

      public static IEnumerable<object> MakeWrapperData() {
            for (int i = 10; i < 10000; i *= 10) {
                  yield return new Wrapper(MakeString(i));
            }
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeStringData))]
      public void StringComparison(string str) {
            result = str == stringCompare;
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeStringData))]
      public void StringSetContains(string str) {
            stringSet.Contains(str);
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeStringData))]
      public void StringDictionaryContains(string str) {
            stringDictionary.ContainsKey(str);
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeWrapperData))]
      public void WrapperComparison(Wrapper wrapper) {
            result = wrapper == wrapperCompare;
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeWrapperData))]
      public void WrapperSetContains(Wrapper wrapper) {
            result = wrapperSet.Contains(wrapper);
      }

      [Benchmark]
      [ArgumentsSource(nameof(MakeWrapperData))]
      public void WrapperDictionaryContains(Wrapper wrapper) {
            result = wrapperDictionary.ContainsKey(wrapper);
      }
}
