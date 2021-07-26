using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
            string text = richTextBox1.Text;
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alphabet2 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int m = alphabet.Length;
            int d = alphabet2.Length;
            int n = 1;
            var myShift = numericUpDown1.Value;
            string s = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (!alphabet.Contains(text[i]) && !alphabet2.Contains(text[i]))
                {
                    s = s + text[i];
                }

                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        int shift = j * n + (int)myShift;
                        shift = (shift < 0) ? 66 + shift : shift;

                        while (shift >= m)
                            shift -= m;

                        s = s + alphabet[shift];
                    }
                }

                for (int h = 0; h < alphabet2.Length; h++)
                {

                    if (text[i] == alphabet2[h])
                    {
                        int shift2 = h * n + (int)myShift;
                        shift2 = (shift2 < 0) ? 66 + shift2 : shift2;

                        while (shift2 >= d)
                            shift2 -= d;

                        s = s + alphabet2[shift2];
                    }
                }
            }
            richTextBox2.Text = s;
        }
    }



}
    
