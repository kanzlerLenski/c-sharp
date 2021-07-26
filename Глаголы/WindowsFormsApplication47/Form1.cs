using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication47
{
    struct Verbs
    {
        public string id;
        public string pos;
        public string literal;
        public string sense;
        public string lnote;
        public string ilr;
        public string ilr2;
        public string ilrHelp;
        public string type;
        public string type2;
        public string typeHelp;
        public string def;
        public string stamp;
        public string usage;
        public string snote;
        public string myStr;

        public Verbs(string id, string pos, string literal, string sense, string lnote, string ilr, string ilr2, string ilrHelp, string type, string type2, string typeHelp, string def, string stamp, string usage, string snote, string myStr)
        {
            this.id = id;
            this.pos = pos;
            this.literal = literal;
            this.sense = sense;
            this.lnote = lnote;
            this.ilr = ilr;
            this.ilr2 = ilr2;
            this.ilrHelp = ilrHelp;
            this.type = type;
            this.type2 = type2;
            this.typeHelp = typeHelp;
            this.def = def;
            this.stamp = stamp;
            this.usage = usage;
            this.snote = snote;
            this.myStr = myStr;

        }

    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Verbs> characteristics = new List<Verbs>();

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader a = new StreamReader(@"E:\Программирование\Прочее\wnrus.txt", Encoding.UTF8);

            string str = a.ReadToEnd();
            string[] str1 = str.Split(new string[] { "<ID>" }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string s in str1)
            {
                if (s.Contains("/ID"))
                    listBox1.Items.Add(s.Substring(0, s.IndexOf("</ID>")));
            }
            listBox1.Sorted = true;
            listBox1.ScrollAlwaysVisible = true;

            foreach (string s in str1)
            {


                if (s.Contains("/ID"))
                {
                    Verbs verb = new Verbs();
                    verb.id = s.Substring(0, s.IndexOf("</ID>"));
                    verb.pos = s.Substring(s.IndexOf("<POS>") + 5, s.IndexOf("</POS>") - s.IndexOf("<POS>") - 5);
                    verb.literal = s.Substring(s.IndexOf("<LITERAL>") + 9, s.IndexOf("<SENSE>") - s.IndexOf("<LITERAL>") - 9);
                    verb.sense = s.Substring(s.IndexOf("<SENSE>") + 7, s.IndexOf("</SENSE>") - s.IndexOf("<SENSE>") - 7);
                    verb.lnote = s.Substring(s.IndexOf("<LNOTE>") + 7, s.IndexOf("</LNOTE>") - s.IndexOf("<LNOTE>") - 7);
                    if (s.Contains("<TYPE>"))
                    {
                        verb.ilr = s.Substring(s.IndexOf("<ILR>") + 5, s.IndexOf("<TYPE>") - s.IndexOf("<ILR>") - 5);

                        if (s.Contains("</ILR><ILR>"))
                        {
                            verb.ilrHelp = s.Remove(0, s.IndexOf("</ILR><ILR>") + 11);
                            verb.ilr2 = verb.ilrHelp.Substring(0, verb.ilrHelp.IndexOf("<TYPE>"));
                        }
                    }
                    else
                    {
                        verb.ilr2 = " — ";
                    }
                    if (s.Contains("</TYPE>"))
                    {
                        verb.type = s.Substring(s.IndexOf("<TYPE>") + 6, s.IndexOf("</TYPE>") - s.IndexOf("<TYPE>") - 6);

                        if (s.Contains("</TYPE></ILR><ILR>"))
                        {

                            verb.typeHelp = s.Remove(0, s.IndexOf("</TYPE></ILR><ILR>") + 18);
                            verb.type2 = verb.typeHelp.Substring(verb.typeHelp.IndexOf("<TYPE>") + 6, verb.typeHelp.IndexOf("</TYPE>") - verb.typeHelp.IndexOf("<TYPE>") - 6);
                        }
                    }
                    else
                    {
                        verb.type2 = " — ";
                    }


                    if (s.Contains("</DEF>"))
                    {
                        verb.def = s.Substring(s.IndexOf("<DEF>") + 5, s.IndexOf("</DEF>") - s.IndexOf("<DEF>") - 5);
                    }
                    else
                    {
                        verb.def = " — ";
                    }
                    if (s.Contains("</STAMP>"))
                    {
                        verb.stamp = s.Substring(s.IndexOf("<STAMP>") + 7, s.IndexOf("</STAMP>") - s.IndexOf("<STAMP>") - 7);
                    }
                    else
                    {
                        verb.stamp = " — ";
                    }
                    if (s.Contains("</USAGE>"))
                    {
                        verb.usage = s.Substring(s.IndexOf("<USAGE>") + 7, s.IndexOf("</USAGE>") - s.IndexOf("<USAGE>") - 7);
                    }
                    else
                    {
                        verb.usage = " — ";
                    }

                    if (s.Contains("</SNOTE>"))
                    {
                        verb.snote = s.Substring(s.IndexOf("<SNOTE>") + 7, s.IndexOf("</SNOTE>") - s.IndexOf("<SNOTE>") - 7);
                    }
                    else
                    {
                        verb.snote = " — ";
                    }

                    verb.myStr = verb.ilr + verb.ilr2;
                    characteristics.Add(verb);
                }
            }
        }

        string newOne = "";
        int d = 0;

        private void NewMethod(Verbs v)
        {
            foreach (var s in characteristics)
            {
                if ((v.myStr.Contains(s.id)) && (!newOne.Contains(s.id)))
                {
                    d++;
                    newOne += v.myStr + "\n";

                    NewMethod(s);
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string isCurItem = listBox1.SelectedItem.ToString();

            foreach (var k in characteristics)
            {
                if (k.id == isCurItem)
                {
                    richTextBox1.Text = ("PoS: " + k.pos + "\n" + "Literal: " + k.literal + "\n" + "Sense: " + k.sense + "\n" + "LNote: " + k.lnote + "\n" + "ILR: " + k.ilr + "\n" + "ILR2: " + k.ilr2 + "\n" + "Type: " + k.type + "\n" + "Type2: " + k.type2 + "\n" + "Def: " + k.def + "\n" + "Stamp: " + k.stamp + "\n" + k.usage + "\n" + "SNote: " + k.snote + "\n");

                    NewMethod(k);
                    string lastStep = string.Format("Имеет {0} связей:", d);
                    richTextBox1.Text += "\n" + lastStep;
                    richTextBox1.Text += "\n" + newOne;
                    break;
                }
            }
        }
    }
}


    


    

    