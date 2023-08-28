using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Collections;

[Description("C# List<T> performance")]
[BenchmarkClass("Collections")]
public class ListVsLinkedList {
      [Params(10, 100, 1000, 10000)]
      public int Count { get; set; }

      private int Value { get; } = Random.Shared.Next();

      private List<int> numberList = Enumerable.Range(0, 10001).ToList();
      private LinkedList<int> numberLinkedList = new(Enumerable.Range(0, 10001));

      [IterationSetup]
      public void Setup() {
            numberList = Enumerable.Range(0, 10001).ToList();
            numberLinkedList = new(Enumerable.Range(0, 10001));
      }
      
      [Benchmark]
      public List<int> ListCreation() {
            var list = new List<int>();

            for (int i = 0; i < Count; i++) {
                  list.Add(i);
            }
            return list;
      }

      [Benchmark]
      public void ListAdd() {
            numberList.Add(Value);
      }

      [Benchmark]
      public void ListInsert() {
            numberList.Insert(Count / 2, Count);
      }

      [Benchmark]
      public int ListGetAt() {
            return numberList[Count];
      }

      [Benchmark]
      public void ListSetAt() {
            numberList[Count] = Count;
      }

      [Benchmark]
      public void ListRemove() {
            numberList.Remove(Count);
      }

      [Benchmark]
      public void ListRemoveAt() {
            numberList.RemoveAt(Count);
      }

      [Benchmark]
      public int ListIndexOf() {
            return numberList.IndexOf(Count);
      }

      [Benchmark]
      public LinkedList<int> LinkedListCreation() {
            var list = new LinkedList<int>();

            for (int i = 0; i < Count; i++) {
                  list.AddLast(i);
            }
            return list;
      }

      [Benchmark]
      public void LinkedListAdd() {
            numberLinkedList.AddLast(Value);
      }

      [Benchmark]
      public void LinkedListInsert() {
            var node = numberLinkedList.First!;
            var otherNode = new LinkedListNode<int>(Count);
            
            for (int i = 0; i < Count / 2; i++) {
                  node = node.Next!;
            }
            numberLinkedList.AddAfter(node, otherNode);            
      }

      [Benchmark]
      public int LinkedListGetAt() {
            var node = numberLinkedList.First!;

            for (int i = 0; i < Count - 1; i++) {
                  node = node.Next!;
            }
            return node.Value;
      }

      [Benchmark]
      public void LinkedListSetAt() {
            var node = numberLinkedList.First!;

            for (int i = 0; i < Count - 1; i++) {
                  node = node.Next!;
            }
            node.Value = Count;
      }

      [Benchmark]
      public void LinkedListRemoveAt() {
            var node = numberLinkedList.First!;

            for (int i = 0; i < Count - 1; i++) {
                  node = node.Next!;
            }
            numberLinkedList.Remove(node);
      }

      [Benchmark]
      public void LinkedListRemove() {
            var node = numberLinkedList.First!;

            while (node is not null) {
                  if (node.Value == Count) {
                        numberLinkedList.Remove(node);
                  }
                  node = node.Next;
            }
      }

      [Benchmark]
      public LinkedListNode<int>? LinkedListIndexOf() {
            var node = numberLinkedList.First;

            for (; node is not null; node = node.Next) {
                  if (node.Value == Count) {
                        return node;
                  }
            }
            return null;
      }
}
