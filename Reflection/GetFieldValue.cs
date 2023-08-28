using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection; 


[BenchmarkClass("Reflection")]
[Description("C# FieldInfo.GetValue performance")]
public class GetFieldValue {
      private class TestObj {
            public int field = Random.Shared.Next();
      }

      private FieldInfo field = typeof(TestObj).GetField(nameof(TestObj.field)) 
                                ?? throw new Exception("Field not found");

      private TestObj testObj = new();
      
      [Benchmark]
      public int GetValue() {
            return (int)field.GetValue(testObj)!;
      }
}