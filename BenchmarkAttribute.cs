namespace DotnetProfile;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class BenchmarkAttribute : Attribute {
      internal readonly string location;

      public BenchmarkAttribute(string location) {
            this.location = location;
      }
}
