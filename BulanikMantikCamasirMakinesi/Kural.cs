using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public class Kural
    {

        public Dictionary<string, string> Girdiler { get; set; }
        public Dictionary<string, string> Ciktilar { get; set; }

        public Kural()
        {
            Girdiler = new();
            Ciktilar = new();
        }
    }
}
