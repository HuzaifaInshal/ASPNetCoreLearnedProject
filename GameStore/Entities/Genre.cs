namespace GameStore.Entities;

public class Genre
{
    public int Id{ get; set; }
    // { get; set; }: This part is what makes the property a "auto-implemented property". It's a shorthand syntax introduced in C# 3.0. This means that the property has both a getter and a setter, and the compiler will automatically generate the implementation for these accessors.
    // public string Name{ get; set; } = string.Empty;
    // public string? Name{ get; set; }
    public required string Name{ get; set; }
}
