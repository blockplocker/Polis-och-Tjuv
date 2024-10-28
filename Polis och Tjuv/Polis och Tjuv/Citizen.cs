using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Citizen : Person
    {
        public List<string> Items { get; set; }
        public Citizen(string name) : base(name)
        {
            Items = new List<string> { "Phone", "Wallet", "Keys" };
        }
    }
}
