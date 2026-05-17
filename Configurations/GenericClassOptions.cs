namespace Configurations;

// Must be non-abstract with a public parameterless constructor to be used with the options pattern.
// Contain public read-write properties to bind (fields are not bound)
public class GenericClassOptions
{
    public string One { get; set; } = string.Empty;
    public bool Two { get; set; } = false;
    public string Three { get; set; } = string.Empty;
}