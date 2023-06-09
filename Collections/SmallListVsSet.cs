using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# List vs HashSet performance")]
[BenchmarkClass("Collections")]
public class SmallListVsSet {
      private const int MAX_SIZE = 20;

      [ParamsSource(nameof(Sizes))]
      public int Size { get; set; }

      public static IEnumerable<int> Sizes() {
            for (int i = 0; i <= MAX_SIZE; i += 10) {
                  yield return i;
            }
      }

      [Benchmark]
      public void MemoryOfList() {
            _ = new List<int>(Size);
      }

      [Benchmark]
      public void MemoryOfSet() {
            _ = new HashSet<int>(Size);
      }

      [Benchmark]
      public void InsertSpeedOfList() {
            var list = new List<int>();

            for (int i = 0; i <= Size; i++) {
                  list.Add(i);
            }
      }

      [Benchmark]
      public void InsertSpeedOfSet() {
            var set = new HashSet<int>();

            for (int i = 0; i <= Size; i++) {
                  set.Add(i);
            }
      }

      public static IEnumerable<object[]> GetLists() {
            foreach (var size in Sizes()) {
                  var list = new List<int>(size);

                  for (int i = 0; i <= size; i++) {
                        list.Add(i);
                  }
                  yield return new object[] {
                        list,
                        size
                  };
            }
      }

      public static IEnumerable<object[]> GetSets() {
            foreach (var size in Sizes()) {
                  var set = new HashSet<int>(size);

                  for (int i = 0; i <= size; i++) {
                        set.Add(i);
                  }
                  yield return new object[] {
                        set,
                        size
                  };
            }
      }

      [Benchmark]
      [ArgumentsSource(nameof(GetLists))]
      public void FindSpeedOfList(List<int> list, int doesNotExist) {
            list.IndexOf(doesNotExist);
      }

      [Benchmark]
      [ArgumentsSource(nameof(GetSets))]
      public void FindSpeedOfSet(HashSet<int> set, int doesNotExist) {
            set.Contains(doesNotExist);
      }
}
