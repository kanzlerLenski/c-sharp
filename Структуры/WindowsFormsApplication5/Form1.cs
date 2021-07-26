using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    struct Lex

    {
        public string word;
        public string lex;
        public string gr;
        public string sem;


        public Lex(string word, string lex, string gr, string sem)

        {
            this.word = word;
            this.lex = lex;
            this.gr = gr;
            this.sem = sem;

        }

    }

    public partial class Form1 : Form

    {
        public Form1()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            StreamReader a = new StreamReader(@"F:\Программирование\RusCorpora.txt", Encoding.Default);

            string corpus = a.ReadToEnd();
            string corpus2 = corpus.Remove(corpus.IndexOf("<"), corpus.IndexOf("lex"));
            string[] str = corpus2.Split(new string[] { "lex=\"" }, StringSplitOptions.RemoveEmptyEntries);
            string lex = "";
            List<Lex> myList = new List<Lex>();

            foreach (string s in str)
            {
                lex = s.Remove(s.IndexOf("\""));
                string sem = (s.IndexOf("sem=\"") >=0) ? s.Substring(s.IndexOf("sem=\"") + 5, s.IndexOf("\"", s.IndexOf("sem") + 5) - s.IndexOf("sem=\"") - 5)  : "";
                string gr = s.Substring(s.IndexOf("gr=\"") + 4, s.IndexOf("\"", s.IndexOf("gr=\"") + 4) - s.IndexOf("gr=\"") - 4);
                string word = s.Substring(s.IndexOf(">") + 1, s.IndexOf("<") - s.IndexOf(">") - 1);

                myList.Add(new Lex(word, lex, gr, sem));
            }


            foreach (Lex l in myList)
            {
                richTextBox1.Text += ("word: " + l.word + ", lex: " + l.lex + ", gr: " + l.gr + ", sem: " + l.sem + "\n");
            }
        }

        
    }
}