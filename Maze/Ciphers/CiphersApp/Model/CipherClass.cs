using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace CiphersApp.Ciphers
{
    public abstract class CipherClass
    {
        public virtual int Id { get; set; } = 0;
        public virtual string Name { get; set; } = "No name";
        public virtual string ShortDescription { get; set; } = "No Description";
        public virtual string WikipediaHttps { get; set; } = "https://pl.wikipedia.org/wiki/Wikipedia:Strona_g%C5%82%C3%B3wna";
        public virtual void WriteInfo()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t"+Name+"\n");
            Console.WriteLine(ShortDescription);
            Action Menu = WriteCipherOptions;
            FindOption(HelperClass.GetUserChoice(Menu, 0, 3,Name));
        }
        public CipherClass()
        {

        }
        public virtual void Decode()
        {
            HelperClass.NotAvaliable();
            WriteInfo();
        }
        public virtual void Encode()
        {
            HelperClass.NotAvaliable();
            WriteInfo();
        }
        public virtual void FindOption(int a)
        {
           switch(a)
           {
                case 0:
                    BackToMainMenu();
                    break;
                case 1:
                    StartEncode();
                    break;
                case 2:
                    StartDecode();
                    break;
                case 3:
                    OpenLink(WikipediaHttps);
                    break;
                case -1:
                    WriteInfo();
                    break;
                default:
                    Console.Clear();
                    HelperClass.Error();
                    break;
           }
        }

        private void OpenLink(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
            WriteInfo();
        }

        public virtual void BackToMainMenu()
        {
            Console.Clear();
            Program.Main();
        }
        private void StartDecode()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tDecoding message with " + Name);
            Decode();
            Ending();
        }     
        private void StartEncode()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tEncoding message with " + Name);
            Encode();
            Ending();
        }  
        private void Ending()
        {
            Action Menu = WriteEndingOptions;
            EndingFindOption(HelperClass.GetUserChoice(Menu,0,3,"Ending Actions"));
        }
        private void EndingFindOption(int a)
        {
            switch (a)
            {
                case 0:
                    HelperClass.LeaveApp();
                    break;
                case 1:
                    WriteInfo();
                    break;
                case 2:
                    BackToMainMenu();
                    break;
                default:
                    HelperClass.Error();
                    break;
            }
        }


        public  void WriteCipherOptions()
        {
            HelperClass.BreakText();
            Console.WriteLine("List of possible actions: (navigation is simple first select cipher by number in [X] then pres enter)");
            Console.WriteLine("[0] - Go to main menu\n[1] - Encode with {0}\n[2] - Decode with {0}\n[3] - More Information about Cipher.",Name);
            HelperClass.BreakText();
        }
        public void WriteEndingOptions()
        {
            HelperClass.BreakText();
            Console.WriteLine("List of possible actions: (navigation is simple first select cipher by number in [X] then pres enter)");
            Console.WriteLine("[0] - Quit app\n[1] - Continue to cipher menu\n[2] - Go to main menu",Name);
            HelperClass.BreakText();
        }

    }
}
