using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Interfaces
{
    interface CipherStr
    {
        public string Encode(string message);
        public string Decode(string message);
    }
}
