using ExceptionsLibrary;
using System;

namespace ExceptionsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DemoCode demo = new DemoCode();

            try
            {
                int result = demo.GrandparentMethod(4); // This will throw an exception if the index is out of bounds with a 4
                Console.WriteLine($"The Value at the given position is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
