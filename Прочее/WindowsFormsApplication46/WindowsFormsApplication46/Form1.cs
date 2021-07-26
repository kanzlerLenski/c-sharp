using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication46
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
            StreamReader a = new StreamReader(@"E:\Программирование\RusCorpora.txt", Encoding.Default);

    {
        Lex m = new Lex("Маша", "Маша", "S sing Nom", "pers hum");
        Lex k = new Lex("кошкой", "кошка", "S sing f Inst", "com anim");

        List<Lex> le = new List<Lex> {m, k};
        
        foreach (Lex l in le)
        {
            richTextBox1.Text = ("word: " + l.word + ", lex: " + l.lex + ", gr: " + l.gr + ", sem: " + l.sem);

    }

        }
    }
}

}