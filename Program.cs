using System.Reflection;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Running;

namespace DotnetProfile;

public class Program {
      private readonly struct CommandLineArgs {
            public bool SaveAllFile { get; init; }
            public Regex[] SavePatterns { get; init; }

            public bool ShouldSaveFile(string file) {
                  if (SaveAllFile) {
                        return true;
                  }
                  foreach (var regex in SavePatterns) {
                        if (regex.IsMatch(file)) {
                              return true;
                        }
                  }
                  return false;
            }
      }

      private static CommandLineArgs ParseCommandLine(string[] args) {
            bool saveAllFile = false;
            var savePatterns = new List<string>();

            foreach (var arg in args) {
                  if (arg == "--save-all-file") {
                        saveAllFile = true;
                  }
                  else if (arg == "--save-pattern") {
                        savePatterns.Add(arg);              
                  }
            }

            var patterns = savePatterns.Select(pattern => {
                  pattern = "^" + Regex.Escape(pattern).Replace("\\?", ".").Replace("\\*", ".*") + "$";
                  return new Regex(pattern, RegexOptions.None);
            });
            return new CommandLineArgs {
                  SaveAllFile = saveAllFile,
                  SavePatterns = patterns.ToArray()
            };
      }

      public static void Main(string[] args) {
            var assembly = Assembly.GetExecutingAssembly();
            var commandLine = ParseCommandLine(args);

            foreach (var type in assembly.GetTypes()) {
                  var attribute = type.GetCustomAttribute<BenchmarkClassAttribute>();

                  if (attribute is null) {
                        continue;
                  }
                  BenchmarkRunner.Run(type, new Config(attribute.location,
                                                            type.Name));
                  var fullName = type.FullName ?? type.Name;
                  var resultPath = $"{Path.Join(attribute.location, type.Name, "results", fullName)}-report-github.md";

                  // empty benchmark class
                  if (!File.Exists(resultPath)) {
                        goto deleteDir;
                  }
                  var file = Path.Join(attribute.location, $"{type.Name}.md");

                  if (commandLine.ShouldSaveFile(file)) {
                        var description = type.GetCustomAttribute<DescriptionAttribute>();
                        
                        if (description is null || description.Description.Length == 0) {
                              File.Move(resultPath, file, true);
                              continue;
                        }
                        using var stream = File.Open(file, FileMode.OpenOrCreate);
                        using var writer = new StreamWriter(stream);
                        
                        stream.SetLength(0);
                        writer.Write(description.Description);
                        if (description.Description[^1] != '\n') {
                              writer.Write('\n');
                        }
                        writer.Write(File.ReadAllText(resultPath));
                  }

deleteDir:
                  var path = Path.Join(attribute.location, type.Name);
                  if (Directory.Exists(path)) {
                        Directory.Delete(path, true);
                  } 
            }
      }
}

