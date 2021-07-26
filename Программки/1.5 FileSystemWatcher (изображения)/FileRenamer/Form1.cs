using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher watcher;
        int counter = 1;

        public Form1()
        {
            InitializeComponent();
            watcher = new FileSystemWatcher(@"D:\My downloads\Temp");
            watcher.Created += new FileSystemEventHandler(OnCreate);
            watcher.Filter = "*.jpg";
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.EnableRaisingEvents = true;
        }

        public void OnCreate(object source, FileSystemEventArgs e)
        {
            try
            {
                string s = "";
                while (!IsFileReady(e.FullPath)) Thread.Sleep(20);
                FileInfo fi = new FileInfo(e.FullPath);
                
                //Image im = new Bitmap(e.FullPath);
                //PropertyItem[] props = im.PropertyItems;
                //string str;
                //foreach (PropertyItem pi in props)
                //{
                //    if (pi.Id == 0x9003)
                //    {
                //        Decoder decode = Encoding.ASCII.GetDecoder();
                //        char[] chars = new char[pi.Len];
                //        decode.GetChars(pi.Value, 0, pi.Len, chars, 0, true);
                //        str = new string(chars);
                //        s = @"D:\copies\Img "
                //        + str.Substring(0, 4) + "-" 
                //        + str.Substring(5, 2) + "-" 
                //        + str.Substring(8, 2)
                //        + " " 
                //        + str.Substring(11, 2) + "-" 
                //        + str.Substring(14, 2) + "-" 
                //        + str.Substring(17, 2) + ".jpg";
                //    }
                //}
                //im.Dispose();

                if (s == "")
                    s = @"D:\My downloads\Temp\Copies\Img " + counter++ + ".jpg";
                
                    //s = @"D:\copies\Img "
                    //+ fi.CreationTime.Year + "-" 
                    //+ fi.CreationTime.Month.ToString().PadLeft(2, '0') + "-" 
                    //+ fi.CreationTime.Day.ToString().PadLeft(2, '0')
                    //+ " " 
                    //+ fi.CreationTime.Hour.ToString().PadLeft(2, '0') + "-" 
                    //+ fi.CreationTime.Minute.ToString().PadLeft(2, '0') + "-"
                    //+ fi.CreationTime.Second.ToString().PadLeft(2, '0') + "." + Path.GetExtension(e.FullPath);
                
                fi.CopyTo(s, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool IsFileReady(string s)
        {
            try
            {
                FileStream fs = File.Open(s, FileMode.Open);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }   
}
