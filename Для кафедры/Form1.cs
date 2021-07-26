using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Normalization
{
    public partial class Form1 : Form
    {
        bool noActionNeeded = false;
        string fileName;
        string s = "";
        string logs = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Save(object sender, EventArgs e)
        {   
            StreamWriter sw;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Txt|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(richTextBoxResult.Text);
                sw.Close();
            }
        }

        private void Open(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Txt|*.txt|Все файлы|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                s = sr.ReadToEnd();
                richTextBoxOriginal.Text = s;
                sr.Close();
            }
        }

        private void checkedListBoxChoice_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 3)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    checkBoxDeleteEmptyStrings.Enabled = true;
                }
                if (e.NewValue == CheckState.Unchecked)
                {
                    checkBoxDeleteEmptyStrings.Enabled = false;
                    checkBoxDeleteEmptyStrings.Checked = false;
                }
            }

            if (!noActionNeeded)
            {
                if (e.NewValue == CheckState.Unchecked && checkBoxSelectAll.Checked)
                {
                    noActionNeeded = true;
                    checkBoxSelectAll.Checked = false;
                    noActionNeeded = false;
                }
                if (e.NewValue == CheckState.Checked && !checkBoxSelectAll.Checked
                    && checkedListBoxChoice.CheckedItems.Count == 5)
                {
                    noActionNeeded = true;
                    checkBoxSelectAll.Checked = true;
                    noActionNeeded = false;
                }
            }
        }
        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!noActionNeeded)
            {
                if (checkBoxSelectAll.Checked)
                {
                    noActionNeeded = true;
                    for (int i = 0; i < checkedListBoxChoice.Items.Count; i++)
                        checkedListBoxChoice.SetItemChecked(i, true);
                    noActionNeeded = false;
                }
                else
                {
                    noActionNeeded = true;
                    for (int i = 0; i < checkedListBoxChoice.Items.Count; i++)
                        checkedListBoxChoice.SetItemChecked(i, false);
                    noActionNeeded = false;
                }
            }
        }

        string CreateFrequencyList(string s)
        {
            string logs = "";
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (c == '"' || !((c >= ' ') && (c <= '~') || ((c >= 'А') && (c <= 'я')) || ("ёЁ–«»\r\n".Contains(c))))
                {
                    if (dic.ContainsKey(c))
                        dic[c]++;
                    else
                        dic.Add(c, 1);
                }
            }
            foreach (KeyValuePair<char, int> pair in dic)
                logs += string.Format(pair.Key + " (код {0:X4}): " + pair.Value + "\r\n", (int)pair.Key);
            return logs;
        }

        private void Normalize_Click(object sender, EventArgs e)
        {
            StreamWriter logFile = File.CreateText(Path.GetDirectoryName(fileName) 
                + @"\" + Path.GetFileNameWithoutExtension(fileName) + "_log.txt");
            s = s.Normalize();
            if (checkedListBoxChoice.GetItemCheckState(3) == CheckState.Checked) s = s.NormalizeReturns(checkBoxDeleteEmptyStrings.Checked, ref logs);
            if (checkedListBoxChoice.GetItemCheckState(1) == CheckState.Checked) s = s.AddSpaces(ref logs).RemoveSpaces(ref logs);
            if (checkedListBoxChoice.GetItemCheckState(2) == CheckState.Checked) s = s.NormalizeDashes(ref logs);
            if (checkedListBoxChoice.GetItemCheckState(0) == CheckState.Checked) s = s.NormalizeQuotations(ref logs);
            if (checkedListBoxChoice.GetItemCheckState(4) == CheckState.Checked) s = s.NormalizeCyrLat(ref logs);
            if (checkedListBoxChoice.GetItemCheckState(5) == CheckState.Checked) s = s.NormalizeCyrLatExt(ref logs);
            logs += "Нестандартные символы:\r\n" + CreateFrequencyList(s);
            logFile.Write(logs);
            logFile.Close();
            logs = "";
            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName) + "_result" + Path.GetExtension(fileName));
            sw.Write(s);
            sw.Close();
            richTextBoxResult.Text = s;
        }
    }
}
