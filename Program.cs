using System.Reflection;
using BenchmarkDotNet.Running;

namespace DotnetProfile;

public class Program {
      public static void Main() {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach (var type in assembly.GetTypes()) {
                  var attribute = type.GetCustomAttribute<BenchmarkClassAttribute>();

                  if (attribute is not null) {
                        BenchmarkRunner.Run(type, new Config(attribute.location,
                                                             type.Name));
                        var fullName = type.FullName ?? type.Name;
                        var resultPath = $"{Path.Join(attribute.location, type.Name, "results", fullName)}-report-github.md";
                        File.Move(resultPath, Path.Join(attribute.location, $"{type.Name}.md"), true);
                        Directory.Delete(Path.Join(attribute.location, type.Name), true);
                  }
            }
      }
}

