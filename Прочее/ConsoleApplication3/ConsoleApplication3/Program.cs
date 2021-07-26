using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    public struct Lexem
    {
        public string word;
        public string lex;
        public string gr;
        public string sem;

        public Lexem(string w, string l, string g, string se)
        {
            word = w;
            lex = l;
            gr = g;
            sem = se;

        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Lexem le = new Lexem("1", "2", "3", "4");
                Console.WriteLine("word = {0}, sem = {1}", le.word, le.sem);
                Console.ReadKey();

                /*List<Lexem>  lexems = new List<Lexem>();

                for (){
                string lex = 
                string gr = 
                string sem = 
                string word = 
                    lexems.Add(new Lexem(word,lexems,gr,sem));

                 * srtring[] mas = new string[]{};
                foreach (Lexem l in lexems){
                 if (word == "mama")

            }
                 
                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Max(P => P.Key) алфавит
                dic.OrderBy(Descending) обратный порядок - (p => p.Value);
                слева входные параметры - справа 
                */
            }
        }
    }


