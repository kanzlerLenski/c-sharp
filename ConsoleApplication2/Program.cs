using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"E:\НКРЯ.xml");

            XmlElement root = myDoc.DocumentElement;
            RecursiveMethod(root);
            Console.ReadKey();

        }

        static void RecursiveMethod(XmlNode node)
        {
            if (node is XmlElement)
            {
                Console.WriteLine("element {0}", node.Name);
                Attributes(node);

                if (node.HasChildNodes)
                    RecursiveMethod(node.FirstChild);

                if (node.NextSibling != null)
                    RecursiveMethod(node.NextSibling);
            }
            else if (node is XmlText)
            {
                string text = "text" + " " + ((XmlText)node).Value;
                Console.WriteLine(text);
            }
        }

        static void Attributes(XmlNode node)
        {
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                for (int y = 0; y < node.Attributes.Count; y++)
                {
                    Console.WriteLine(" " + "attribute" + " " + node.Attributes[y].Name.ToString()
                    + " " + "=" + " " + node.Attributes[y].Value.ToString());
                }
            }

        }
    }
}




   
