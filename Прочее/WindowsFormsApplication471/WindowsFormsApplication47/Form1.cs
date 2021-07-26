using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication47
{

    public struct MyStruct
    {
        /*объявление структуры*/
        public string lex;
        public string sem;
        public string gr;

    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*экземпляр струтуры*/
            MyStruct myStruct1 = new MyStruct();
            myStruct1.lex = "Светлана";
            myStruct1.sem = "";
            myStruct1.gr = "";

            MyStruct myStruct2 = new MyStruct();
            myStruct2.lex = "Светлана";
            myStruct2.sem = "";
            myStruct2.gr = "";

            List<MyStruct> myStructs = new List<MyStruct>();
            myStructs.Add(myStruct1);
            myStructs.Add(myStruct2);
        }
    }
}
