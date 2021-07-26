using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonimousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new[]
            {
                new { TeaCoffee = "Tea", Sugar = "0", Milk = false },
                new { TeaCoffee = "Tea", Sugar = "1", Milk = true },
                new { TeaCoffee = "Coffee", Sugar = "2", Milk = true },
                new { TeaCoffee = "Coffee", Sugar = "2", Milk = true }
                //инициализаторы
            };
            //анонимный тип

            foreach (var cup in cups)
                Console.WriteLine(cup.ToString());
            Console.WriteLine("\r\nHash Codes:");
            foreach (var cup in cups)
                Console.WriteLine(cup.GetHashCode());
            Console.WriteLine("\r\n3 Equals 4?");
            Console.WriteLine(cups[2].Equals(cups[3])); //содержание (значени полей)
            Console.WriteLine("\r\n3==4?");
            Console.WriteLine(cups[2] == cups[3]); //ссылка (два разных объекта)
            Console.ReadKey();
        }
    }
}
