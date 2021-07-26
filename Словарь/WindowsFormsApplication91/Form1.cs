using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication91
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*StreamReader a = new StreamReader(@"C:\Users\User\Desktop\чушу\мои документы\временные\text.txt", Encoding.Default);
            string str = a.ReadToEnd();
            richTextBox1.Text = str;

            List<string> letters = new List<string>();


            /* for (int i = 0; i < str.Length; i++)
             {
                 string current = str[i].ToString().ToLower();
                 if (!letters.Contains(current))
                     letters.Add(current);
             }

             foreach (char letter in str)
             {
                 if (!letters.Contains(letter.ToString()))
                     letters.Add(letter.ToString());
             }
             
            int j = 0;
            while (j < str.Length)
            {
                string current1 = str[j].ToString();
                if (!letters.Contains(current1))
                    letters.Add(current1);
                j++;
            }

            int n = 100;

            bool myParam = true;
            myParam = letters.Contains("к");

            int x = 0;
            while ((n < 108) && (myParam))
            {
                n++;
                x++;
            }
            richTextBox2.Text = x.ToString();

            richTextBox1.Text = "";

            foreach (string letter in letters)
                richTextBox1.Text += letter + "\n";*/

            var d = new Dictionary<char, int>();

            foreach (char c in File.ReadAllText(@"C:\Users\eUser\Desktop\Новый текстовый документ1.txt", Encoding.Default))
                if (d.ContainsKey(c))
                    d[c]++;
                else
                    d.Add(c, 1);

            string text = "";
            foreach (char c in d.Keys)
            {
                text += c + " - " + d[c]+ "\n";
                richTextBox2.Text = text;

            }




        }
    }
}
