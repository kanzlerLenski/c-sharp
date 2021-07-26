using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"C:\Users\User\Downloads\НКРЯ.xml");

            XmlNode n = myDoc.DocumentElement;

            XmlElement myElem = myDoc.DocumentElement;
            //myDoc.Save(@"C:\Users\User\Downloads\НКРЯ_мой_результат.txt");
            TextBox myBox = new TextBox();
             
            myBox.Text += string.Format("элемент {0}", myElem.Name.ToString());
            //myBox.Text += string.Format("   элемент {0}", n.Name.ToString());
            myBox.Text += string.Format("   элемент {0}", n.FirstChild.Name.ToString());
            

            /*foreach (XmlNode n in myDoc.ParentNode)
            {
                myBox.Text += string.Format("элемент {0}", n.ParentNode.Name.ToString());
                if (n.HasChildNodes == true)
                {
                    myBox.Text += string.Format("   элемент {0}", n.FirstChild.Name.ToString());
                    foreach (XmlNode s in n.NextSibling)
                    {
                        myBox.Text += string.Format("       элемент {0}", n.NextSibling.Name.ToString());
                    }
                }

                else
                {
                }
            }*/

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
