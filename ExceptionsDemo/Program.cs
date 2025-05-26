using ExceptionsLibrary;
using System;

namespace ExceptionsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DemoCode demo = new DemoCode();

            // global exception handler to tell the user about the exception.
            try
            {
                int result = demo.GrandparentMethod(4); // This will throw an exception if the index is out of bounds with a 4
                Console.WriteLine($"The Value at the given position is: {result}");
            }
            catch (ArgumentException)
            {
                // Handle the specific ArgumentException
                Console.WriteLine("You gave us Bad information bad user");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                // Traverse through the inner exceptions to get the full stack trace
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.StackTrace);
                    innerException = innerException.InnerException; // Traverse through the inner exceptions
                }
            }

            Console.ReadLine();
        }
    }
}
