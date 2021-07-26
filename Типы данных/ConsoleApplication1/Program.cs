using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   

    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Введите 2 числа:");
            string s = Console.ReadLine();
            string s2 = Console.ReadLine();

            byte a = Convert.ToByte(s);
            byte b = Convert.ToByte(s2);
            int c = a + b;
            int d = a * b;

            Console.WriteLine("The answer is {0}.", d);
            Console.ReadKey();
             
        }
    }

}