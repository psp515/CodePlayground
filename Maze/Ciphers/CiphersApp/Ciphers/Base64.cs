
using CiphersApp;
using CiphersApp.Ciphers;
using CiphersApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionApp.Ciphers.C_Classes
{
    public sealed class Base64 : CipherClass, CipherStr
    {
        public override int Id { get; set; } = 2;
        public override string Name { get; set; } = "Base64";
        public override string ShortDescription { get; set; } = "Base64 is a group of binary-to-text encoding schemes that represent binary data (more specifically, \na sequence of 8-bit bytes) in an ASCII string format by translating the data into a radix-64 representation.";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/Base64";

        public Base64()
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
        public  string Decode(string message) => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(message));
        public  string Encode(string message) => System.Convert.ToBase64String(Encoding.UTF8.GetBytes(message));

    }
}
