using System;
using System.Collections.Generic;
using System.Text;
using CiphersApp;
using CiphersApp.Ciphers;
using CiphersApp.Interfaces;

namespace EncryptionApp.Ciphers.C_Classes
{
    public sealed class CaesarVariation : CipherClass, CipherStrInt
    {
        public override int Id { get; set; } = 4;
        public override string Name { get; set; } = "CaesarVariation";
        public override string ShortDescription { get; set; } = "CaesarVariation is a variation on Caesar cipher. This cipher works the same way like Caesar\n cipher but user is choosing letter shift (in Caesar cipher shift = 3),also numbers are encoded.";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/Caesar_cipher";

        public CaesarVariation()
        {

        }
        public override void Decode()
        {
            string a = Decode(HelperClass.GetString("Provide encoded message:"), HelperClass.GetInt("Enter the shift:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your message: (encoded message is saved in clipboard) \n" + a);
        }

        public override void Encode()
        {
            string a = Encode(HelperClass.GetString("Provide message:"), HelperClass.GetInt("Set shift:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your encoded message: (encoded message is saved in clipboard) \n" + a);
        }

        public string Decode(string message, int n)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                tab[i] = DecodeChar(tab[i], n);

            return new string(tab);
        }
        public string Encode(string message, int n)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                tab[i] = EncodeChar(tab[i], n);

            return new string(tab);
        }
        public char EncodeChar(char a, int n)
        {
            if (Char.IsUpper(a))
            {
                a = (char)(a + n);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a + n);
                if (a > 'z')
                    return (char)(a - 26);
                else if (a < 'a')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsDigit(a))
            {
                a = (char)(a + 5);
                if (a > '9')
                    return (char)(a - 10);
                else if (a < '0')
                    return (char)(a + 10);
                else
                    return a;
            }
            else
                return a;
        }
        public char DecodeChar(char a, int n)
        {
            if (Char.IsUpper(a))
            {
                a = (char)(a - n);
                if (a > 'Z')
                    return (char)(a - 26);
                else if (a < 'A')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsLower(a))
            {
                a = (char)(a - n);
                if (a > 'z')
                    return (char)(a - 26);
                else if (a < 'a')
                    return (char)(a + 26);
                else
                    return a;
            }
            else if (Char.IsDigit(a))
            {
                a = (char)(a - 5);
                if (a > '9')
                    return (char)(a - 10);
                else if (a < '0')
                    return (char)(a + 10);
                else
                    return a;
            }
            else
                return a;
        }

    }
}
