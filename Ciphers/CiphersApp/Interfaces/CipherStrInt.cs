using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Interfaces
{
    interface CipherStrInt
    {
        public string Encode(string message, int n);
        public string Decode(string message, int n);
    }
}
