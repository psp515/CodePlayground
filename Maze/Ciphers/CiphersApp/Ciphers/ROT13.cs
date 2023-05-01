using CiphersApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Ciphers
{
    class ROT13 : CipherClass, CipherStr
    {
        public override int Id { get; set; } = 7;
        public override string Name { get; set; } = "RO13";
        public override string ShortDescription { get; set; } = "ROT13 is a simple letter substitution cipher that replaces a letter with the 13th \nletter after it in the alphabet. ROT13 is a special case of the Caesar cipher which was developed in ancient Rome.";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/ROT13";
        public ROT13()
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
                a = (char)(a + 13);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a + 13);
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
                a = (char)(a - 13);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a - 13);
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
