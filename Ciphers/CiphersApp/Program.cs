using CiphersApp.Ciphers;
using CiphersApp.Helpers;
using CiphersApp.Model;
using EncryptionApp.Ciphers.C_Classes;
using System;
using System.Collections.Generic;

namespace CiphersApp
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "CiphersApp";
            Console.WriteLine("\t\t\t  Welcome to CiphersApp!");
            Starting();
        }

        private static void Starting()
        {
            CiphersLists cl = new CiphersLists();
            Action WriteMenu = () => HelperClass.WriteCipherList(cl.MenuModels);
            int cipher = HelperClass.GetUserChoice(WriteMenu, 0, 8, "Main");

            try
            {
                if (cipher == -1)
                    Main();
                cl.MenuModels[cipher].Start();
            }
            catch(Exception e)
            {
                HelperClass.Error();
            }
            
        }
    }
}
