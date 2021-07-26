using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace ObjectStore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product[] chocolates = new Product[]
                {
                    new Product(1, "Аленка", 55.0, "не очень"),
                    new Product(2, "Россия щедрая душа", 40.0, "Nestle, на самом деле"),
                    new Product(4, "Lindt", 112.0, "очень хороший")
                };
                Console.WriteLine("Список продуктов для сериализации:");
                foreach (Product c in chocolates)
                    Console.WriteLine(c);
                IFormatter serializer = new SoapFormatter();
                FileStream fs =
                  new FileStream("Products.txt", FileMode.Create, FileAccess.Write);
                serializer.Serialize(fs, chocolates);
                fs.Close();

                fs = new FileStream("Products.txt", FileMode.Open, FileAccess.Read);
                Product[] products =
                   serializer.Deserialize(fs) as Product[];
                fs.Close();
                Console.WriteLine("\r\nЗагружено:");
                foreach (Product p in products)
                    Console.WriteLine(p);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("A serialization exception has been thrown!");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
