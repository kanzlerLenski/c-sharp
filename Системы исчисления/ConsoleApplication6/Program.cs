
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            //int x = Convert.ToInt16(Console.ReadLine());
            int x = Convert.ToInt16(args[0]);
            int y = Convert.ToInt16(args[1]);
            string s = "";

            while (x > 0)
            {
                switch (x % y)
                {
                    case 10:
                        s += "A";
                        break;
                    case 11:
                        s += "B";
                        break;
                    case 12:
                        s += "C";
                        break;
                    case 13:
                        s += "D";
                        break;
                    case 14:
                        s += "E";
                        break;
                    case 15:
                        s += "F";
                        break;
                    default:
                        s += Convert.ToString(x % 16);
                        break;
                }
                x = x / y;
            }

            string s2 = "";
            for (int i = 0; i < s.Length; i++)
                s2 += s[s.Length - i - 1];
            
            Console.WriteLine("Your number in {1}-decimal number system is: {0}", s2, y);

            foreach (char k in s2)
            {
                switch (k)
                {

                    case '0':
                        s2 = s2.Replace("0", "0000");
                        break;
                    case '1':
                        s2 = s2.Replace("1", "0001");
                        break;
                    case '2':
                        s2 = s2.Replace("2", "0010");
                        break;
                    case '3':
                        s2 = s2.Replace("3", "0011");
                        break;
                    case '4':
                        s2 = s2.Replace("4", "0100");
                        break;
                    case '5':
                        s2 = s2.Replace("5", "0101");
                        break;
                    case '6':
                        s2 = s2.Replace("6", "0110");
                        break;
                    case '7':
                        s2 = s2.Replace("7", "0111");
                        break;
                    case '8':
                        s2 = s2.Replace("8", "1000");
                        break;
                    case '9':
                        s2 = s2.Replace("9", "1001");
                        break;
                    case 'A':
                        s2 = s2.Replace("A", "1010");
                        break;
                    case 'B':
                        s2 = s2.Replace("B", "1011");
                        break;
                    case 'C':
                        s2 = s2.Replace("C", "1100");
                        break;
                    case 'D':
                        s2 = s2.Replace("D", "1101");
                        break;
                    case 'E':
                        s2 = s2.Replace("E", "1110");
                        break;
                    case 'F':
                        s2 = s2.Replace("F", "1111");
                        break;
                }
            }

            Console.WriteLine("Your number in binary numeral system is: {0}", s2);
            Console.ReadKey();

        }
    }
}
