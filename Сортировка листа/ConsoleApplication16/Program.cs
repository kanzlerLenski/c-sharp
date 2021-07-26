using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader text = new StreamReader(@"E:\Сказка.txt", Encoding.Default);

            string myText = text.ReadToEnd().ToLower();
            string[] myNewText = myText.Split(new string [] {".", "?", ",", "!", "(", ")", "–", " "}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stb = new StringBuilder();

            //string final = "";
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string currentStr in myNewText)
            {
                if (dict.ContainsKey(currentStr))
                    dict[currentStr]++;
                else
                    dict.Add(currentStr, 1);
            }

            /*foreach (string currentStr in dict.Keys)
            {
                final += currentStr + " – " + dict[currentStr] + "\n";
            }
                Console.WriteLine(final);
                Console.ReadKey();

            foreach (var key in dict.OrderBy(key => key.Key))
            {
                Console.WriteLine(key);
            }

            Console.ReadKey();
         
            foreach (var value in dict.OrderBy(value => value.Value).ThenBy(key => key.Key))
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();*/

            List<string> MyKeys = new List<string>();
            List<int> MyValues = new List<int>();


            foreach (string s in dict.Keys)
            {
                MyKeys.Add(s);
            }
            MyKeys.Sort();

            foreach (string k in MyKeys)
            {
                Console.WriteLine(k);
            }
            Console.ReadKey();

            foreach (int i in dict.Values)
            {
                MyValues.Add(i);
            }

            string final2 = "";
            Dictionary<string, int> newDict = new Dictionary<string, int>();
            foreach (string str in MyKeys)
            {
                if (newDict.ContainsKey(str))
                    newDict[str]++;
                else
                    newDict.Add(str, 1);
            }

            /*List<int> UniqueVal = new List<int>();

            foreach (int d in MyValues)
            {
                foreach (int t in MyValues)
            {
                if (d != t)
                    UniqueVal.Add(d);        
            }

            }

            foreach (int k in dict.Values)
            {
                foreach (int d in UniqueVal)
                {
                    if (newDict[d] == k)
                        newDict[d]++;
                    else
                        newDict.Add(k, 1);
                }
            }

            newDict.Values.Reverse();
                       
            foreach (string currentStr in newDict.Keys) 
           {
                final2 += currentStr + " – " + newDict[currentStr] + "\n";
           }
               Console.WriteLine(final2);
               Console.ReadKey();*/

        }
    }
}
