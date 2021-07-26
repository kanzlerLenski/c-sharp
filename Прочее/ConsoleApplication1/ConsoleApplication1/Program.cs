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
            string text = "Hello, world!";
            StringBuilder text2 = new StringBuilder(text);

            Console.WriteLine("text: {0}", text);
            Console.WriteLine("text: {0}", text2.ToString());
            Console.WriteLine("Starting text...");

            StringChanger(text);
            Console.WriteLine("StringChanger. text: {0}, text");
            BuilderChanger(text2);
            Console.WriteLine("BuilderChanger. text2: {0}, text2");
            BuilderChanger2(text2);
            Console.WriteLine("BuilderChanger2. text2: {0}, text2");
            BuilderChanger3(text2);
            Console.WriteLine("BuilderChanger3. text2: {0}, text2");
            BuilderChanger4(ref text2);
            Console.WriteLine("BuilderChanger4. text2: {0}, text2");

            Console.ReadKey();

        }

        static void StringChanger(String text)
        {

            text = "StringChanger has been here!";
        }
        static void BuilderChanger(StringBuilder text2)
        {
            text2.Clear();
            text2.AppendLine("BuilderChanger has been here!");

        }

        static void BuilderChanger2(StringBuilder text2)
        {

            StringBuilder stb = new StringBuilder();
            stb = text2;
            stb.Clear();
            stb.AppendLine("BuilderChanger has been here!");
        }

        static void BuilderChanger3(StringBuilder text2)
        {
            text2 = new StringBuilder("BuilderChanger has been here!");
        }

            static void BuilderChanger4(ref StringBuilder text2)
            {
            text2 = new StringBuilder("BuilderChanger has been here!");
        }
    }
}
