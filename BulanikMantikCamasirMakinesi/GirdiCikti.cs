using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public class Girdi
    {
        public string Ad { get; set; }
        public double Deger { get; set; }
        public Dictionary<string, UyelikFonksiyonu> UyelikFonksiyonlari { get; set; } = new();

        public Dictionary<string, double> Bulaniklastir()
        {
            var sonuc = new Dictionary<string, double>();
            foreach (var kvp in UyelikFonksiyonlari)
            {
                sonuc[kvp.Key] = kvp.Value.UyeligiHesapla(Deger);
            }
            return sonuc;
        }
    }
    public class Cikti
    {
        public string Ad { get; set; }
        public Dictionary<string, UyelikFonksiyonu> UyelikFonksiyonlari { get; set; } = new();
        public Dictionary<string, double> CiktiDegerleri { get; set; } = new();
    }

}

