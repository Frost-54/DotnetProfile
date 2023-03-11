using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace DotnetProfile;

public class Config : ManualConfig {
      public Config(string artifactPath, string name) {
            AddExporter(MarkdownExporter.GitHub);
            AddDiagnoser(new IDiagnoser[] {
                  new MemoryDiagnoser(new MemoryDiagnoserConfig()),
            });
            AddJob(Job.ShortRun);
            AddLogger(new ConsoleLogger());
            AddColumnProvider(DefaultColumnProviders.Instance);
            ArtifactsPath = Path.Join(artifactPath, name);
      }
}
