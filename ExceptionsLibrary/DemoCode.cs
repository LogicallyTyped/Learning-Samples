using System;

namespace ExceptionsLibrary
{
    public class DemoCode
    {
        public int GrandparentMethod(int position)
        {
            int output = 0;  // Default value in case of an exception

            Console.WriteLine("Open DataBase Connection");

            // this is where we handle the exception, so we can log it or take other actions.
            try
            {
                output = ParentMethod(position);
            }
            catch (Exception ex)
            {
                // Log the exception here, if needed
                throw new ArgumentException("I have a boo boo",ex);  // this allows you to keep the traceback of the original exception
            }
            finally
            {
                Console.WriteLine("Close DataBase Connection");
            }

            return output;
        }

        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }

        public int GetNumber(int position)
        {
            int output = 0;  // Default value in case of an exception

            // We don't to try-catch at this level, the information about the exception should be handled by the caller.
            //try
            //{
            int[] numbers = new int[] { 1, 4, 7, 2 };
                output = numbers[position];
            //}
            //catch (System.Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);  // where the exception happened.

            //}

            return output; // Return the output, which will be 0 if an exception occurred This makes the program worst.
        }
    }
}