using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Interfaces
{
    interface CipherStrStrInt
    {
        public string Encode(string message, string k, int n);
        public string Decode(string message, string k, int n);
    }
}
