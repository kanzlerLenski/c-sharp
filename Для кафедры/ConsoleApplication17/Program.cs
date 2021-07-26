using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Normalization
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader originalText = new StreamReader(@"E:\Программирование\Для кафедры\File01.txt", Encoding.Default);
            string text = originalText.ReadToEnd();
            //string text = "   Мама  -----" + "\r\n" + "----мыла---" + "\r\n" + "ра-\r\nму - " + "\r" + "\n" + "-\r\n";
            //Console.WriteLine(text);
            text = text.normalizeReturns().normalizeSpaces().normalizeDashes().normalizeQuotations();
           // Console.WriteLine(text);
            //foreach (char c in text)
            //Console.WriteLine("{0:x}", (int)c);
            //Console.ReadKey();
            StreamWriter finalText = new StreamWriter(@"E:\Программирование\Для кафедры\File01_final.txt");
            finalText.Write(text);
            originalText.Close();
            finalText.Close();

        }
    }
}
