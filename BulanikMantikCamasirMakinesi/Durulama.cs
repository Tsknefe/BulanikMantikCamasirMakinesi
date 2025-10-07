using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public static class Durulama
    {
        public static double AgirlikliOrtalama(Cikti cikti)
        {
            double pay = 0;
            double payda = 0;
            foreach (var kvp in cikti.CiktiDegerleri)
            {
                string etiket = kvp.Key;
                double agirlik = kvp.Value;

                UyelikFonksiyonu f = cikti.UyelikFonksiyonlari[etiket];
                double merkez = OrtalamaBul(f);
                pay += agirlik * merkez;
                payda += agirlik;
            }
            return payda == 0 ? 0 : pay / payda;
        }

        private static double OrtalamaBul(UyelikFonksiyonu fonk)
        {
            if (fonk is UcgenUyelik u) return (u.a + u.b + u.c) / 3.0;
            if (fonk is YamukUyelik y) return (y.b + y.c) / 2.0;
            return 0;
        }

        public static double AgirlikMerkezi(Cikti cikti)
        {
            double alanToplam = 0;
            double agirlikliAlan = 0;

            foreach (var kvp in cikti.CiktiDegerleri)
            {
                string etiket = kvp.Key;
                double yukseklik = kvp.Value;
                UyelikFonksiyonu f = cikti.UyelikFonksiyonlari[etiket];
                double merkez = OrtalamaBul(f);
                double alan = yukseklik * 1; 
                agirlikliAlan += merkez * alan;
                alanToplam += alan;
            }
            return alanToplam == 0 ? 0 : agirlikliAlan / alanToplam;
        }
    }
}

