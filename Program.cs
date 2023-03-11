using System.Reflection;
using BenchmarkDotNet.Running;

namespace DotnetProfile;

public class Program {
      public static void Main() {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach (var type in assembly.GetTypes()) {
                  var attribute = type.GetCustomAttribute<BenchmarkAttribute>();

                  if (attribute is not null) {
                        BenchmarkRunner.Run(type, new Config(attribute.location));
                  }
            }
      }
}

