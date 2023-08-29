using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
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
    
    [Benchmark]
    public void MetadataBuilderHelloWorld() {
        var metadata = new MetadataBuilder();
            metadata.AddModule(
            0,
            metadata.GetOrAddString("HelloWorld"),
            metadata.GetOrAddGuid(Guid.NewGuid()),
            default,
            default);
        var ilBuilder = new BlobBuilder();

        metadata.AddAssembly(
            metadata.GetOrAddString("HelloWorld"),
            version: new Version(1, 0, 0, 0),
            culture: default(StringHandle),
            publicKey: default(BlobHandle),
            flags: 0,
            hashAlgorithm: AssemblyHashAlgorithm.None);

        // Create references to System.Object and System.Console types.
        var mscorlibAssemblyRef = metadata.AddAssemblyReference(
            name: metadata.GetOrAddString("mscorlib"),
            version: new Version(4, 0, 0, 0),
            culture: default(StringHandle),
            publicKeyOrToken: metadata.GetOrAddBlob(
                new byte[] { 0xB7, 0x7A, 0x5C, 0x56, 0x19, 0x34, 0xE0, 0x89 }
                ),
            flags: default,
            hashValue: default);

        var systemObjectTypeRef = metadata.AddTypeReference(
            mscorlibAssemblyRef,
            metadata.GetOrAddString("System"),
            metadata.GetOrAddString("Object"));

        var systemConsoleTypeRefHandle = metadata.AddTypeReference(
            mscorlibAssemblyRef,
            metadata.GetOrAddString("System"),
            metadata.GetOrAddString("Console"));

        // Get reference to Console.WriteLine(string) method.
        var consoleWriteLineSignature = new BlobBuilder();

        new BlobEncoder(consoleWriteLineSignature).
            MethodSignature().
            Parameters(1,
                returnType => returnType.Void(),
                parameters => parameters.AddParameter().Type().String());

        var consoleWriteLineMemberRef = metadata.AddMemberReference(
            systemConsoleTypeRefHandle,
            metadata.GetOrAddString("WriteLine"),
            metadata.GetOrAddBlob(consoleWriteLineSignature));

        // Get reference to Object's constructor.
        var parameterlessCtorSignature = new BlobBuilder();

        new BlobEncoder(parameterlessCtorSignature).
            MethodSignature(isInstanceMethod: true).
            Parameters(0, returnType => returnType.Void(), parameters => { });

        var parameterlessCtorBlobIndex = metadata.GetOrAddBlob(parameterlessCtorSignature);

        var objectCtorMemberRef = metadata.AddMemberReference(
            systemObjectTypeRef,
            metadata.GetOrAddString(".ctor"),
            parameterlessCtorBlobIndex);

        // Create signature for "void Main()" method.
        var mainSignature = new BlobBuilder();

        new BlobEncoder(mainSignature).
            MethodSignature().
            Parameters(0, returnType => returnType.Void(), parameters => { });

        var methodBodyStream = new MethodBodyStreamEncoder(ilBuilder);

        var codeBuilder = new BlobBuilder();

        var il = new InstructionEncoder(codeBuilder);

        // ldarg.0
        il.LoadArgument(0); 

        // call instance void [mscorlib]System.Object::.ctor()
        il.Call(objectCtorMemberRef);

        // ret
        il.OpCode(ILOpCode.Ret);

        var ctorBodyOffset = methodBodyStream.AddMethodBody(il);
        codeBuilder.Clear();

        // Emit IL for Program::Main
        var flowBuilder = new ControlFlowBuilder();
        il = new InstructionEncoder(codeBuilder, flowBuilder);

        // ldstr "hello"
        il.LoadString(metadata.GetOrAddUserString("Hello world"));

        // call void [mscorlib]System.Console::WriteLine(string)
        il.Call(consoleWriteLineMemberRef);

        // ret
        il.OpCode(ILOpCode.Ret);

        var mainBodyOffset = methodBodyStream.AddMethodBody(il);
        codeBuilder.Clear();

        // Create method definition for Program::Main
        var mainMethodDef = metadata.AddMethodDefinition(
            MethodAttributes.Public | MethodAttributes.Static,
            MethodImplAttributes.IL,
            metadata.GetOrAddString(nameof(SayHi)),
            metadata.GetOrAddBlob(mainSignature),
            mainBodyOffset,
            parameterList: default);

        // Create method definition for Program::.ctor
        var ctorDef = metadata.AddMethodDefinition(
            MethodAttributes.Public | MethodAttributes.HideBySig | 
                MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
            MethodImplAttributes.IL,
            metadata.GetOrAddString(".ctor"),
            parameterlessCtorBlobIndex,
            ctorBodyOffset,
            parameterList: default);

        // Create type definition for the special <Module> type that holds global functions
        metadata.AddTypeDefinition(
            default,
            default,
            metadata.GetOrAddString("<Module>"),
            baseType: default,
            fieldList: MetadataTokens.FieldDefinitionHandle(1),
            methodList: mainMethodDef);

        // Create type definition for ConsoleApplication.Program
        metadata.AddTypeDefinition(
            TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.BeforeFieldInit,
            default,
            metadata.GetOrAddString("Hello"),
            baseType: systemObjectTypeRef,
            fieldList: MetadataTokens.FieldDefinitionHandle(1),
            methodList: mainMethodDef);
        var headerBuilder = new PEHeaderBuilder(imageCharacteristics: Characteristics.Dll);
        var peBuilder = new ManagedPEBuilder(
            headerBuilder,
            new MetadataRootBuilder(metadata),
            ilBuilder,
            flags: CorFlags.ILOnly);
        var peBlob = new BlobBuilder();
        
        peBuilder.Serialize(peBlob);
        var assembly = Assembly.Load(peBlob.ToArray());
        var type = assembly.GetType("Hello");
        var method = type!.GetMethod(nameof(SayHi))!.CreateDelegate<SayHi>();
        
        method();
    }
}