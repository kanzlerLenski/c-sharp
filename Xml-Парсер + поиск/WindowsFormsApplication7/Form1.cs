using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder stb = new StringBuilder();

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"E:\НКРЯ.xml");

            XmlElement root = myDoc.DocumentElement;
            RecursiveMethod(root, ref stb, "");
        }

        private void RecursiveMethod(XmlNode node, ref StringBuilder stb, string space)
        {
            if (node is XmlElement)
            {
                stb.Append(string.Format("element {0}" + "\r\n", node.Name));
                Attributes(node, ref stb);

                if (node.HasChildNodes)
                    RecursiveMethod(node.FirstChild, ref stb, space + " ");

                if (node.NextSibling != null)
                    RecursiveMethod(node.NextSibling, ref stb, space + "  ");
            }
            else if (node is XmlText)
            {
                stb.Append("text" + " " + ((XmlText)node).Value);
                myList.Text += stb;
            }
        }

            private void Attributes(XmlNode node, ref StringBuilder stb)
        {
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                for (int y = 0; y < node.Attributes.Count; y++)
                {
                    stb.Append(string.Format(" " + "attribute" + " " + node.Attributes[y].Name.ToString()
                    + " " + "=" + " " + node.Attributes[y].Value.ToString()));
                    myList.Text += stb;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stb2 = new StringBuilder();

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"E:\НКРЯ.xml");

            XmlElement root = myDoc.DocumentElement;
            string query = myBox.Text;

            switch (query)
            {
                case "//book":
                    foreach (XmlNode n in root.SelectNodes("//book"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//body":
                    foreach (XmlNode n in root.SelectNodes("//body"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//p":
                    foreach (XmlNode n in root.SelectNodes("//p"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//se":
                    foreach (XmlNode n in root.SelectNodes("//se"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//w":
                    foreach (XmlNode n in root.SelectNodes("//w"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//ana":
                    foreach (XmlNode n in root.SelectNodes("//ana"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//gr":
                    foreach (XmlNode n in root.SelectNodes("//gr"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

                case "//sem":
                    foreach (XmlNode n in root.SelectNodes("//sem"))
                        RecursiveMethod2(n, ref stb2, "");
                    break;

            }

        }

        private void RecursiveMethod2(XmlNode node, ref StringBuilder stb2, string space)
        {
            if (node is XmlElement)
            {
                stb2.Append(string.Format("element {0}" + "\r\n", node.Name));
                Attributes2(node, ref stb2);

                if (node.HasChildNodes)
                    RecursiveMethod2(node.FirstChild, ref stb2, " ");

                if (node.NextSibling != null)
                    RecursiveMethod2(node.NextSibling, ref stb2, " ");
            }
            else if (node is XmlText)
            {
                stb2.Append("text" + " " + ((XmlText)node).Value);
                result.Text += stb2;
            }
        }

        private void Attributes2(XmlNode node, ref StringBuilder stb2)
        {
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                for (int y = 0; y < node.Attributes.Count; y++)
                {
                     stb2.Append(string.Format(" " + "attribute" + " " + node.Attributes[y].Name.ToString()
                    + " " + "=" + " " + node.Attributes[y].Value.ToString()));
                     result.Text += stb2;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void myList_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

        
