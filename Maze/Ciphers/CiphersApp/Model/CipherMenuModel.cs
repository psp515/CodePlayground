using System;
using System.Collections.Generic;
using System.Text;

namespace CiphersApp.Model
{
    public class CipherMenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Action Start;
    }
}
