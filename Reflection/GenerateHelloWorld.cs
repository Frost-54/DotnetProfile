using System.Reflection;
using System.Reflection.Emit;
using BenchmarkDotNet.Attributes;

namespace DotnetProfile.Reflection; 

[BenchmarkClass("Reflection")]
[Description("C# dynamic code generation using DynamicAssembly vs DynamicMethod")]
public class GenerateHelloWorld {
    private readonly MethodInfo writeLine = typeof(Console).GetMethod(
        nameof(Console.WriteLine), 
        new Type[] {
            typeof(string)
        }
    ) ?? throw new Exception("Cannot find Console.WriteLine");
    
    private delegate void SayHi();
    
    [Benchmark]
    public void DynamicAssemblyHelloWorld() {
        var name = new AssemblyName("HelloWorld");
        var assembly = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndCollect);
        var module = assembly.DefineDynamicModule("HelloWorld");
        var typeBuilder = module.DefineType("Hello");
        var method = typeBuilder.DefineMethod(nameof(SayHi),
            MethodAttributes.Public | MethodAttributes.Static,
            CallingConventions.Standard,
            typeof(void),
            Type.EmptyTypes);
        var generator = method.GetILGenerator();
        
        generator.Emit(OpCodes.Ldstr, "Hello world!");
        generator.Emit(OpCodes.Call, writeLine);
        generator.Emit(OpCodes.Ret);

        var type = typeBuilder.CreateType();
        var callable = type!.
            GetMethod(nameof(SayHi))!
            .CreateDelegate<SayHi>();
        callable();
    }

    [Benchmark]
    public void DynamicMethodHelloWorld() {
        var method = new DynamicMethod(nameof(SayHi), typeof(void), Type.EmptyTypes);
        var generator = method.GetILGenerator();

        generator.Emit(OpCodes.Ldstr, "Hello world!");
        generator.Emit(OpCodes.Call, writeLine);
        generator.Emit(OpCodes.Ret);
    }
}