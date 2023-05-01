
using CiphersApp;
using CiphersApp.Ciphers;
using CiphersApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EncryptionApp.Ciphers.C_Classes
{
    public sealed class Scytale : CipherClass, CipherStrInt
    {
        public override int Id { get; set; } = 8;
        public override string Name { get; set; } = "Scytale";
        public override string ShortDescription { get; set; } = "In cryptography, a scytale is a tool used to perform a transposition cipher, consisting of a cylinder \nwith a strip of parchment wound around it on which is written a message. The ancient Greeks, \nand the Spartans in particular, are said to have used this cipher to communicate during military campaigns.";
        public override string WikipediaHttps { get; set; } = "https://en.wikipedia.org/wiki/Scytale";

        public Scytale()
        {

        }
        public override void Decode()
        {
            string a = Decode(HelperClass.GetString("Provide encoded message:"), HelperClass.GetInt("Enter the number of cilinder sides:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your message: (encoded message is saved in clipboard) \n" + a);
        }

        public override void Encode()
        {
            string a = Encode(HelperClass.GetString("Provide message:"), HelperClass.GetInt("Set number of cilinder sides:"));
            TextCopy.ClipboardService.SetText(a);
            Console.WriteLine("Your encoded message: (encoded message is saved in clipboard) \n" + a);
        }

        public string Decode(string ciphertext, int key)
        {
            string[] tab = new string[key];
            int j = 0;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                tab[j] += ciphertext[i];
                if (j < key - 1)
                    j++;
                else
                    j = 0;
            }
            return String.Join("", tab).Trim();
        }
        public string Encode(string plaintext, int key)
        {
            int n = 0;
            if (plaintext.Length % key == 0)
                n = (int)(plaintext.Length / key);
            else
                n = (int)1 + (plaintext.Length / key);

            string[] encodedComponent = new string[n];
            int actn = 0;

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (actn < plaintext.Length)
                        encodedComponent[j] += plaintext[actn];
                    else
                        encodedComponent[j] = encodedComponent[j] + " ";
                    actn++;
                }
            }
            return String.Join("", encodedComponent);

        }
    }
}

