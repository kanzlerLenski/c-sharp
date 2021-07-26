using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = richTextBox1.Text.ToLower();
            string newOne = text.Replace(" ", String.Empty).Replace("—", String.Empty).Replace(".", String.Empty).Replace("!", String.Empty).Replace(",", String.Empty).Replace(";", String.Empty).Replace("?", String.Empty).Replace(":", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty);
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (alphabet.Contains(text[i]))
                    result += text[i];
                else 
                    result += " ";

            }

            string[] words = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool palindrome = true;


            for (int i = 0; i < newOne.Length / 2; i++)
                if (newOne[i] == newOne[newOne.Length - i - 1])
                    palindrome = true;
                else
                    palindrome = false;

            if (palindrome == false)
                for (int i = 0; i < words.Length / 2; i++)
                    if (words[i] == words[words.Length - i - 1])
                        palindrome = true;
                    else palindrome = false;


            if (!palindrome)
                MessageBox.Show("Данная запись не является палиндромом.");

            else
                MessageBox.Show("Данная запись является палиндромом.");





        }

       


    }


}


