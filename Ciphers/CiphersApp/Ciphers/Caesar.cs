using CiphersApp;
using CiphersApp.Ciphers;
using CiphersApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionApp.Ciphers.C_Classes
{
    public sealed class Caesar : CipherClass , CipherStr
    {
        public override int Id { get; set; } = 3;
        public override string Name { get; set; } = "Cesar";
        public override string ShortDescription { get; set; } = "In cryptography, a Caesar cipher, is one of the simplest and most widely known encryption techniques.\nIt is a type of substitution cipher in which each letter in the plaintext is replaced by a letter\nsome fixed number of positions down the alphabet.he method is named after Julius Caesar, who used\nit in his private correspondence. (shift == 3)";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/Caesar_cipher";

        public Caesar()
        {

        }

        public override void Decode()
        {
            string a = Decode(HelperClass.GetString("Provide encoded message:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your message: (encoded message is saved in clipboard) \n" + a);
        }

        public override void Encode()
        {
            string a = Encode(HelperClass.GetString("Provide message:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your encoded message: (encoded message is saved in clipboard) \n" + a);
        }

        public string Decode(string message)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                 tab[i] = DecodeChar(tab[i]);
           
            return new string(tab);
        }
        public string Encode(string message)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                  tab[i] = EncodeChar(tab[i]);
         
            return new string(tab);
        }
        public char EncodeChar(char a)
        {
            if (Char.IsUpper(a))
            {
                a = (char)(a + 3);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a + 3);
                if (a > 'z')
                    return (char)(a - 26);
                else if (a < 'a')
                    return (char)(a + 26);
                else
                    return a;
            }
            else
                return a;
        }
        public char DecodeChar(char a) 
        {
            if (Char.IsUpper(a))
            {
                a = (char)(a - 3);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a - 3);
                if (a > 'z')
                    return (char)(a - 26);
                else if (a < 'a')
                    return (char)(a + 26);
                else
                    return a;
            }
            else
                return a;
        }
    }
}
