using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string text = "";
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string strKey in dict.Keys)
            {
                text += strKey + ": " + dict[strKey];
            }

            string str = "Привет!";
            string str2 = str + " " + "Привет-привет!";

            int count = 5;
            double time = 3.5;
            string res = string.Format("Рабочие перевезли, {0} тонн, груза за {1} часов", count, time);
            

            int firstPunct = res.IndexOfAny(new char[] { ',', ';', '.' });

            string res2 = res.Substring(1, 5);

            bool contains = res.Contains("тонн");
            if (contains)
            {

            }

            string res3 = res.Replace('a', 'b');
            res3 = res3.Replace("тонн", "####");

            string [] words = res.Split(new string[] { " ", "," }, StringSplitOptions.None);

            
            foreach (string currentStr in words)
                    if (dict.ContainsKey(currentStr))
                        dict[currentStr]++;
                    else
                        dict.Add(currentStr, 1);

           
            foreach (string currentStr in dict.Keys)
            {
                text += currentStr + " - " + dict[currentStr] + "\n";
                richTextBox1.Text = text;

                string strJoin = string.Join(" ", words);

                res3 = res3.ToLower();

                res3.Trim();



            }

            

        }
    }
}
