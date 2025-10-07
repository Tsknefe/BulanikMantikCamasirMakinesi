using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public static class GrafikCizici
    {
        public static void CiktiyiCiz(Graphics g, Cikti cikti, Rectangle alan)
        {
            g.Clear(Color.White);
            Pen eksenKalem = new Pen(Color.Gray, 1);
            g.DrawLine(eksenKalem, alan.Left, alan.Bottom, alan.Right, alan.Bottom);

            foreach (var kvp in cikti.UyelikFonksiyonlari)
            {
                string etiket = kvp.Key;
                UyelikFonksiyonu fonk = kvp.Value;

                Brush renk = new SolidBrush(RenkSec(etiket));
                double yukseklik = cikti.CiktiDegerleri.ContainsKey(etiket) ? cikti.CiktiDegerleri[etiket] : 0;

                PointF[] bolge = HesaplaBulanikAlan(fonk, yukseklik, alan);
                if (bolge.Length >= 3)
                    g.FillPolygon(renk, bolge);
            }
        }

        private static PointF[] HesaplaBulanikAlan(UyelikFonksiyonu f, double yukseklik, Rectangle alan)
        {
            List<PointF> noktalar = new();
            for (int i = 0; i <= alan.Width; i++)
            {
                double xGercek = i * 15.0 / alan.Width; 
                double uyelik = Math.Min(f.UyeligiHesapla(xGercek), yukseklik);
                float y = (float)(alan.Bottom - uyelik * alan.Height);
                float x = alan.Left + i;
                noktalar.Add(new PointF(x, y));
            }
            if (noktalar.Count > 0)
            {
                
                noktalar.Insert(0, new PointF(alan.Left, alan.Bottom));
                noktalar.Add(new PointF(alan.Right, alan.Bottom));
            }
            return noktalar.ToArray();
        }

        private static Color RenkSec(string etiket)
        {
            return etiket switch
            {
                "Hassas" => Color.LightBlue,
                "NormalHassas" => Color.SkyBlue,
                "Orta" => Color.Orange,
                "NormalGuclu" => Color.IndianRed,
                "Guclu" => Color.Red,
                "Kisa" => Color.LightGreen,
                "NormalKisa" => Color.GreenYellow,
                "NormalUzun" => Color.DarkGreen,
                "Uzun" => Color.ForestGreen,
                "CokAz" => Color.LightGray,
                "Az" => Color.Silver,
                "Fazla" => Color.DarkOrange,
                "CokFazla" => Color.Maroon,
                _ => Color.DarkGray
            };
        }
    }
}

