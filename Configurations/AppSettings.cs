internal class AppSettings
{
    public int KeyOne { get; set; }
    public bool KeyTwo { get; set; }
    public KeyThreeSettings KeyThree { get; set; } = new();
    public string Greeting { get; set; } = string.Empty;
}

public class KeyThreeSettings
{
    public string Message { get; set; } = string.Empty;
}