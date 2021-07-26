using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication98
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader a = new StreamReader(@"E:\Программирование\Прочее\RusCorpora.txt", Encoding.Default);

            string corpus = a.ReadToEnd();
            string[] str = corpus.Split(new string[] { "</w>" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stb = new StringBuilder();

            foreach (string s in str)
            {
                stb.Append(s.Remove(s.IndexOf("<"), s.LastIndexOf(">") - s.IndexOf("<") + 1));

            }

            richTextBox1.Text = stb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            StreamReader a = new StreamReader(@"E:\Программирование\Прочее\RusCorpora.txt", Encoding.Default);

            string corpus = a.ReadToEnd();
            string corpus2 = corpus.Remove(corpus.IndexOf("<"), corpus.IndexOf("lex"));
            string[] str2 = corpus2.Split(new string[] { "lex=\"" }, StringSplitOptions.RemoveEmptyEntries);
            string word2 = "";
            Dictionary<string, int> dict2 = new Dictionary<string, int>();

            foreach (string s2 in str2)
            {
                word2 = s2.Remove(s2.IndexOf("\""));
                if (dict2.ContainsKey(word2))
                    dict2[word2]++;
                else
                    dict2.Add(word2, 1);
            }

            string text20 = "";
            foreach (string currentStr2 in dict2.Keys)
            {
                text20 = currentStr2 + " - " + dict2[currentStr2] + "\n";
                listBox1.Items.Add(text20);

            }

            string corpus3 = corpus.Remove(corpus.IndexOf("<"), corpus.IndexOf("sem"));
            string[] str3 = corpus3.Split(new string[] { "sem=\"" }, StringSplitOptions.RemoveEmptyEntries);
            string word3 = "";
            Dictionary<string, int> dict3 = new Dictionary<string, int>();

            foreach (string s3 in str3)
            {
                word3 = s3.Remove(s3.IndexOf("\""));
                if (dict3.ContainsKey(word3))
                    dict3[word3]++;
                else
                    dict3.Add(word3, 1);
            }

            string text30 = "";
            foreach (string currentStr3 in dict3.Keys)
            {
                text30 = currentStr3 + " - " + dict3[currentStr3] + "\n";
                listBox2.Items.Add(text30);


                string corpus4 = corpus.Remove(corpus.IndexOf("<"), corpus.IndexOf("gr"));
                string[] str4 = corpus4.Split(new string[] { "gr=\"" }, StringSplitOptions.RemoveEmptyEntries);
                string word4 = "";
                Dictionary<string, int> dict4 = new Dictionary<string, int>();

                foreach (string s4 in str4)
                {
                    word4 = s4.Remove(s4.IndexOf("\""));
                    if (dict4.ContainsKey(word4))
                        dict4[word4]++;
                    else
                        dict4.Add(word4, 1);
                }

                string text40 = "";
                foreach (string currentStr4 in dict4.Keys)
                {
                    text40 = currentStr4 + " - " + dict4[currentStr4] + "\n";
                    listBox3.Items.Add(text40);

                }
            }
        }

    }
}

    
