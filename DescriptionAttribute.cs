namespace DotnetProfile;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class DescriptionAttribute : Attribute {
      public readonly string Description;

      public DescriptionAttribute(string description) {
            Description = description;
      }
}
