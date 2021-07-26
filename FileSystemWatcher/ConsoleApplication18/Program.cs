using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\User\Desktop\Картинки";
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            watcher.Filter = "*.jpg";
            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }

        private static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0} was created.", e.Name);
        }

    }
}
