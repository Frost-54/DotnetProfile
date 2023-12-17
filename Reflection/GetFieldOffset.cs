using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection; 

[BenchmarkClass("Reflection")]
[Description("c# Activator.CreateInstance vs new performance")]
public class GetFieldOffset {
      private delegate int GetOffsetFunction(int value = 0);

      private readonly GetOffsetFunction getOffsetFunction;
      private MyClass realInstance = new();

      public GetFieldOffset() {
            var method = new DynamicMethod("Hello", typeof(int), new Type[] {
                  typeof(int)
            });
            var generator = method.GetILGenerator();
            var field = typeof(MyClass).GetField(nameof(MyClass.field))!;
            
            generator.Emit(OpCodes.Ldarga, 0);
            generator.Emit(OpCodes.Ldflda, field);
            generator.Emit(OpCodes.Ldarga, 0);
            generator.Emit(OpCodes.Sub);
            generator.Emit(OpCodes.Ret);

            getOffsetFunction = method.CreateDelegate<GetOffsetFunction>();
      }
      
      public class MyClass {
            public int field;
      }

      [Benchmark]
      [Arguments(0)]
      public unsafe int Fixed(int dummy = 0) {
            var pointer = new IntPtr(&dummy); 
            var instance = Unsafe.As<IntPtr, MyClass>(ref pointer);

            fixed (int* p = &instance.field) {
                  return (int)((byte*)p - (byte*)pointer);
            }
      }
      
      [Benchmark]
      [Arguments(0)]
      public unsafe int FixedWithExisting(int dummy = 0) {
            var pointer = Unsafe.AsPointer(ref realInstance);

            fixed (int* p = &realInstance.field) {
                  return (int)((byte*)p - (byte*)pointer);
            }
      }

      [Benchmark]
      [Arguments(0)]
      public unsafe int UnsafeAsPointer(int dummy = 0) {
            var pointer = new IntPtr(&dummy); 
            var instance = Unsafe.As<IntPtr, MyClass>(ref pointer);
            var field = Unsafe.AsPointer(ref instance.field);
            
            return (int)((byte*)field - (byte*)pointer);
      }
      
      [Benchmark]
      [Arguments(0)]
      public unsafe int UnsafeAsPointerWithExisting(int dummy = 0) {
            var pointer = Unsafe.AsPointer(ref realInstance);
            var field = Unsafe.AsPointer(ref realInstance.field);
            
            return (int)((byte*)field - (byte*)pointer);
      }

      [Benchmark]
      [Arguments(0)]
      // needed to get value of readonly field
      public unsafe int UnsafeAsRef(int dummy = 0) {
            var pointer = new IntPtr(&dummy); 
            var instance = Unsafe.As<IntPtr, MyClass>(ref pointer);
            var field = Unsafe.AsPointer(ref Unsafe.AsRef(instance.field));
            
            return (int)((byte*)field - (byte*)pointer);
      }
      
      [Benchmark]
      [Arguments(0)]
      // needed to get value of readonly field
      public unsafe int UnsafeAsRefWithExisting(int dummy = 0) {
            var pointer = Unsafe.AsPointer(ref realInstance);
            var field = Unsafe.AsPointer(ref Unsafe.AsRef(realInstance.field));
            
            return (int)((byte*)field - (byte*)pointer);
      }

      [Benchmark]
      public int ILMethod() {
            return getOffsetFunction();
      }
}