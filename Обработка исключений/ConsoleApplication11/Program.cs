using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int x = Convert.ToInt16(Console.ReadLine());
            byte input;

            try
            {
                input = checked((byte)x);
            }
            catch
            {
                Console.WriteLine("The wrong result: {0}", x);
            }
            finally
            {
                input = (byte)x;
                Console.WriteLine("Your number in byteType is: {0}.", input);
            }
            Console.ReadKey();
        }
       
    }
}
