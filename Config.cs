using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;

namespace DotnetProfile;

public class Config : ManualConfig {
      public Config(string artifactPath) {
            AddExporter(MarkdownExporter.GitHub);
            ArtifactsPath = artifactPath;
      }
}
