using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
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
                StreamReader a = new StreamReader(@"F:\Программирование\RusCorpora.txt", Encoding.Default);
                string corpus = a.ReadToEnd();
                string str2 = corpus.Substring(corpus.IndexOf("="), corpus.IndexOf(" sem"));
                string[] str3 = str2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string text = "";
                Dictionary<string, int> dict = new Dictionary<string, int>();
            
                foreach (string currentStr in str3)
                    if (dict.ContainsKey(currentStr))
                        dict[currentStr]++;
                    else
                        dict.Add(currentStr, 1);

           
                foreach (string currentStr in dict.Keys)
            {
                text += currentStr + " - " + dict[currentStr] + "\n";
                richTextBox2.Text = text;
            
            

            


        }
    }

        
        
        }
}
