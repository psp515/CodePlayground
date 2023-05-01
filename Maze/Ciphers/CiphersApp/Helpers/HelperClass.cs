using CiphersApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CiphersApp
{
    public class HelperClass
    {
        
        public static int GetUserChoice(Action writeMenu, int choiceMin, int choiceMax, string menuName)
        {
            writeMenu();
            int choice = GetIntChoice();
            if (choice < choiceMin || choice > choiceMax || choice == -1)
            {
                Console.Clear();
                Console.WriteLine(" Moving to {0} menu. Please choose correct option...", menuName);
                Thread.Sleep(2000);
                Console.Clear();
                return -1;
            }

            return choice;
        }
        private static int GetIntChoice()
        {
            string a = Console.ReadLine();
            if (Regex.IsMatch(a, @"^\d+$"))
            {
                return Int32.Parse(a);
            }
            return -1;
        }
        public static int GetInt(string text)
        {
            Console.WriteLine(text);
            string a = Console.ReadLine();
            if (Regex.IsMatch(a, @"^\d+$"))
            {
                return Int32.Parse(a);
            }
            else
                return GetInt(text);
        }
        public static string GetString(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        public static void BreakText() => Console.WriteLine("-----------------------------------------------------------------------------------");

        public static void WriteCipherList(List<CipherMenuModel> listCipherMenuModel)
        {
            BreakText();
            Console.WriteLine("List of possible actions: (navigation is simple first select cipher by number in [X] then pres enter)");
            foreach (CipherMenuModel c in listCipherMenuModel)
                Console.WriteLine(string.Format("[{0}] - {1}", c.Id.ToString(), c.Name));
            BreakText();
        }
        

        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Sorry, something went wrong moving to main menu!");
            Thread.Sleep(1000);
            Console.Clear();
            Program.Main();
        }
        public static void LeaveApp()
        {
            Console.Clear();
            Thread.Sleep(500);
            Console.WriteLine("\t\t\tThanks for speding some time with my App!");
            Thread.Sleep(1500);
            Console.WriteLine("\t\t\t\tHave a wonderfull day!");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }
        public static void NotAvaliable()  
        {
            Console.Clear();
            Console.WriteLine("This option is not avaliable yet.");
            Thread.Sleep(1500);
        }

    }
}
