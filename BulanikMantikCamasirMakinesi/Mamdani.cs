using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public class Mamdani
    {
        public List<Girdi> Girdiler { get; set; }
        public List<Cikti> Ciktilar { get; set; }
        public List<Kural> Kurallar { get; set; }

        public Mamdani()
        {
            Girdiler = new();
            Ciktilar = new();
            Kurallar = new();
        }

        public void Calistir()
        {
            foreach (var kural in Kurallar)
            {
                List<double> uyelikler = new();
                foreach (var girdi in Girdiler)
                {
                    if (!kural.Girdiler.ContainsKey(girdi.Ad)) continue;
                    string etiket = kural.Girdiler[girdi.Ad];
                    double uyelik = girdi.Bulaniklastir()[etiket];
                    uyelikler.Add(uyelik);
                }

                double minDeger = uyelikler.Min();

                foreach (var cikti in Ciktilar)
                {
                    if (!kural.Ciktilar.ContainsKey(cikti.Ad)) continue;
                    string ciktiEtiket = kural.Ciktilar[cikti.Ad];
                    if (!cikti.CiktiDegerleri.ContainsKey(ciktiEtiket))
                        cikti.CiktiDegerleri[ciktiEtiket] = minDeger;
                    else
                        cikti.CiktiDegerleri[ciktiEtiket] = Math.Max(cikti.CiktiDegerleri[ciktiEtiket], minDeger);
                }
            }
        }
    }
}

