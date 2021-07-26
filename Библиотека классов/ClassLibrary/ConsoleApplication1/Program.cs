using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyExternalClass NewClass = new MyExternalClass();
            Console.WriteLine(NewClass.ToString());
            Console.ReadLine();
        }
    }
}
