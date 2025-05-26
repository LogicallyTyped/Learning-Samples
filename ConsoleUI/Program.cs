using ExceptionsLibrary;

class Program
{
     static void Main(string[] args)
    {
        DemoCode demoCode = new DemoCode();

        int result = demoCode.GrandparentMethod(3);

        Console.WriteLine($"The value at given position is {result}");

        Console.ReadLine();
    }
}