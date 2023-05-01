using CiphersApp.Ciphers;
using CiphersApp.Model;
using EncryptionApp.Ciphers.C_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Helpers
{
    public class CiphersLists
    {
        public List<CipherMenuModel> MenuModels;
        public CiphersLists()
        {
            MenuModels = new List<CipherMenuModel>();

            CipherMenuModel cipherMenu_0 = new CipherMenuModel();
            CipherMenuModel cipherMenu_1 = new CipherMenuModel();
            CipherMenuModel cipherMenu_2 = new CipherMenuModel();
            CipherMenuModel cipherMenu_3 = new CipherMenuModel();
            CipherMenuModel cipherMenu_4 = new CipherMenuModel();
            CipherMenuModel cipherMenu_5 = new CipherMenuModel();
            CipherMenuModel cipherMenu_6 = new CipherMenuModel();
            CipherMenuModel cipherMenu_7 = new CipherMenuModel();
            CipherMenuModel cipherMenu_8 = new CipherMenuModel();

            cipherMenu_0.Id = 0;
            cipherMenu_0.Name = "Quit app";
            cipherMenu_0.Start = HelperClass.LeaveApp;
            MenuModels.Add(cipherMenu_0);

            Amc amc = new Amc();
            cipherMenu_1.Id = amc.Id;
            cipherMenu_1.Name = amc.Name;
            cipherMenu_1.Start = amc.WriteInfo;
            MenuModels.Add(cipherMenu_1);

            Base64 base64 = new Base64();
            cipherMenu_2.Id = base64.Id;
            cipherMenu_2.Name = base64.Name;
            cipherMenu_2.Start = base64.WriteInfo;
            MenuModels.Add(cipherMenu_2);

            Caesar caesar = new Caesar();
            cipherMenu_3.Id = caesar.Id;
            cipherMenu_3.Name = caesar.Name;
            cipherMenu_3.Start = caesar.WriteInfo;
            MenuModels.Add(cipherMenu_3);

            CaesarVariation caesarVariation = new CaesarVariation();
            cipherMenu_4.Id = caesarVariation.Id;
            cipherMenu_4.Name = caesarVariation.Name;
            cipherMenu_4.Start = caesarVariation.WriteInfo;
            MenuModels.Add(cipherMenu_4);

            RailFenceCipher railFenceCipher = new RailFenceCipher();
            cipherMenu_5.Id = railFenceCipher.Id;
            cipherMenu_5.Name = railFenceCipher.Name;
            cipherMenu_5.Start = railFenceCipher.WriteInfo;
            MenuModels.Add(cipherMenu_5);

            ROT135 ROT135 = new ROT135();
            cipherMenu_6.Id = ROT135.Id;
            cipherMenu_6.Name = ROT135.Name;
            cipherMenu_6.Start = ROT135.WriteInfo;
            MenuModels.Add(cipherMenu_6);

            ROT13 ROT13 = new ROT13();
            cipherMenu_7.Id = ROT13.Id;
            cipherMenu_7.Name = ROT13.Name;
            cipherMenu_7.Start = ROT13.WriteInfo;
            MenuModels.Add(cipherMenu_7);

            Scytale scytale = new Scytale();
            cipherMenu_8.Id = scytale.Id;
            cipherMenu_8.Name = scytale.Name;
            cipherMenu_8.Start = scytale.WriteInfo;
            MenuModels.Add(cipherMenu_8);

        }
    }
}
