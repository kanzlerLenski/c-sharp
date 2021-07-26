using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] text = new string[] { };
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader corpus = new StreamReader(@"E:\Программирование\Прочее\Bulgakov__Master_i_Margarita.txt", Encoding.Default);
            string firstStep = corpus.ReadToEnd().ToLower();
            text = firstStep.Split(new string[] { " ", ".", ",", "!", "?", "(", ")", ":", ";", "\"", "\n", "\r", "–", "…" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
            richTextBox2.Text = String.Empty;
            var maxShift = numericUpDown1.Value;
            Dictionary<string, int> dictLeft = new Dictionary<string, int>();
            Dictionary<string, int> dictRight = new Dictionary<string, int>();

            for (var i = 0; i < text.Length; i++)
            {
                if (text.Contains(richTextBox3.Text.ToLower()))
                {
                }
                else
                {
                    MessageBox.Show("Слово не найдено");
                    break;
                }

                if (text[i] == richTextBox3.Text.ToLower())
                {

                    for (var shift = -maxShift; shift < 0; shift++)
                        if (i + shift >= 0 && i + shift < text.Length)
                            richTextBox1.Text += text[i + (int)shift] + " ";

                    for (var shift = 1; shift <= maxShift; shift++)
                        if (i + shift >= 0 && i + shift < text.Length)
                            richTextBox2.Text += text[i + (int)shift] + " ";

                    richTextBox1.Text += "\n";
                    richTextBox2.Text += "\n";
                }

            }
            string exit = "";
            string newOne = richTextBox1.Text;
            string[] lastOne = newOne.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in lastOne)
            {
                if (dictLeft.ContainsKey(str))
                    dictLeft[str]++;
                else
                    dictLeft.Add(str, 1);
            }

            foreach (string k in dictLeft.Keys)
            {
                exit += k + " - " + dictLeft[k] + "\n";
                richTextBox4.Text = exit;

            }

            string exit2 = "";
            string newOne2 = richTextBox2.Text;
            string[] lastOne2 = newOne2.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in lastOne2)
            {
                if (dictRight.ContainsKey(str))
                    dictRight[str]++;
                else
                    dictRight.Add(str, 1);
            }

            foreach (string k in dictRight.Keys)
            {
                exit2 += k + " - " + dictRight[k] + "\n";
                richTextBox5.Text = exit2;

            }
        }
    }



}

        

    










        
    







