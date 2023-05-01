using CiphersApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace CiphersApp.Ciphers
{
    public class Amc : CipherClass, CipherStr
    {
        public override int Id { get; set; } = 1;
        public override string Name { get; set; } = "Ascii Multiplier";
        public override string ShortDescription { get; set; } = "Simple cipher that takes char code and multiplies it by 2 when encoding\nor divide char code by 2 when decode.";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/English_Wikipedia";

        public Amc(){ }
        
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

        public string Encode(string message)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                tab[i] = (char)(2 * tab[i]);
            return new string(tab);
        }
        public string Decode(string message)
        {
            char[] tab = message.ToCharArray();
            for (int i = 0; i < tab.Length; i++)
                tab[i] = (char)(tab[i] / 2);
            return new string(tab);
        }
    }
}
