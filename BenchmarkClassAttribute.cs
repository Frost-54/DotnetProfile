namespace DotnetProfile;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class BenchmarkClassAttribute : Attribute {
      internal readonly string location;

      public BenchmarkClassAttribute(string location) {
            this.location = location;
      }
}
