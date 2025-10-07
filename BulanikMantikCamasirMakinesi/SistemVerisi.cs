using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public static class SistemVerisi
    {
        public static List<Girdi> GirdileriHazirla(double hassaslik, double miktar, double kirlilik)
        {
            var g1 = new Girdi
            {
                Ad = "Hassaslik",
                Deger = hassaslik,
                UyelikFonksiyonlari = new()
                {
                    { "hassas", new YamukUyelik(5.5, 8, 12.5, 14) },
                    { "orta", new UcgenUyelik(3, 5, 7) },
                    { "sağlam", new YamukUyelik(-4, -1.5, 2, 4) }
                }
            };

            var g2 = new Girdi
            {
                Ad = "Miktar",
                Deger = miktar,
                UyelikFonksiyonlari = new()
                {
                    { "küçük", new YamukUyelik(-4, -1.5, 2, 4) },
                    { "orta", new UcgenUyelik(3, 5, 7) },
                    { "büyük", new YamukUyelik(5.5, 8, 12.5, 14) }
                }
            };

            var g3 = new Girdi
            {
                Ad = "Kirlilik",
                Deger = kirlilik,
                UyelikFonksiyonlari = new()
                {
                    { "küçük", new YamukUyelik(-4.5, -2.5, 2, 4.5) },
                    { "orta", new UcgenUyelik(3, 5, 7) },
                    { "büyük", new YamukUyelik(5.5, 8, 12.5, 15) }
                }
            };

            return new List<Girdi> { g1, g2, g3 };
        }

        public static List<Cikti> CiktilariHazirla()
        {
            var donus = new Cikti
            {
                Ad = "DonusHizi",
                UyelikFonksiyonlari = new()
                {
                    { "hassas", new YamukUyelik(-5.8, -2.8, 0.5, 1.5) },
                    { "normal_hassas", new UcgenUyelik(0.5, 2.75, 5) },
                    { "orta", new UcgenUyelik(2.75, 5, 7.25) },
                    { "normal_güçlü", new UcgenUyelik(5, 7.25, 9.5) },
                    { "güçlü", new YamukUyelik(8.5, 9.5, 12.8, 15.2) }
                }
            };

            var sure = new Cikti
            {
                Ad = "Sure",
                UyelikFonksiyonlari = new()
                {
                    { "kısa", new YamukUyelik(-46.5, -25.28, 22.3, 39.9) },
                    { "normal_kısa", new UcgenUyelik(22.3, 39.9, 57.5) },
                    { "orta", new UcgenUyelik(39.9, 57.5, 75.1) },
                    { "normal_uzun", new UcgenUyelik(57.5, 75.1, 92.7) },
                    { "uzun", new YamukUyelik(75, 92.7, 111.6, 130) }
                }
            };

            var deterjan = new Cikti
            {
                Ad = "Deterjan",
                UyelikFonksiyonlari = new()
                {
                    { "çok_az", new YamukUyelik(0, 0, 20, 85) },
                    { "az", new UcgenUyelik(20, 85, 150) },
                    { "orta", new UcgenUyelik(85, 150, 215) },
                    { "fazla", new UcgenUyelik(150, 215, 280) },
                    { "çok_fazla", new YamukUyelik(215, 280, 300, 300) }
                }
            };

            return new List<Cikti> { donus, sure, deterjan };
        }

        public static List<Kural> KurallariHazirla()
        {
            var kurallar = new List<Kural>();

            void Ekle(string h, string m, string k, string d, string s, string det)
            {
                kurallar.Add(new Kural
                {
                    Girdiler = new Dictionary<string, string>
                    {
                        { "Hassaslik", h },
                        { "Miktar", m },
                        { "Kirlilik", k }
                    },
                    Ciktilar = new Dictionary<string, string>
                    {
                        { "DonusHizi", d },
                        { "Sure", s },
                        { "Deterjan", det }
                    }
                });
            }

            // 27 kural 
            Ekle("hassas", "küçük", "küçük", "hassas", "kısa", "çok_az");
            Ekle("hassas", "küçük", "orta", "normal_hassas", "kısa", "az");
            Ekle("hassas", "küçük", "büyük", "orta", "normal_kısa", "orta");
            Ekle("hassas", "orta", "küçük", "hassas", "kısa", "orta");
            Ekle("hassas", "orta", "orta", "normal_hassas", "normal_kısa", "orta");
            Ekle("hassas", "orta", "büyük", "orta", "orta", "fazla");
            Ekle("hassas", "büyük", "küçük", "normal_hassas", "normal_kısa", "orta");
            Ekle("hassas", "büyük", "orta", "normal_hassas", "orta", "fazla");
            Ekle("hassas", "büyük", "büyük", "orta", "normal_uzun", "fazla");

            Ekle("orta", "küçük", "küçük", "normal_hassas", "normal_kısa", "az");
            Ekle("orta", "küçük", "orta", "orta", "kısa", "orta");
            Ekle("orta", "küçük", "büyük", "normal_güçlü", "orta", "fazla");
            Ekle("orta", "orta", "küçük", "normal_hassas", "normal_kısa", "orta");
            Ekle("orta", "orta", "orta", "orta", "orta", "orta");
            Ekle("orta", "orta", "büyük", "hassas", "uzun", "fazla");
            Ekle("orta", "büyük", "küçük", "hassas", "orta", "orta");
            Ekle("orta", "büyük", "orta", "hassas", "normal_uzun", "fazla");
            Ekle("orta", "büyük", "büyük", "hassas", "uzun", "çok_fazla");

            Ekle("sağlam", "küçük", "küçük", "orta", "orta", "az");
            Ekle("sağlam", "küçük", "orta", "normal_güçlü", "orta", "orta");
            Ekle("sağlam", "küçük", "büyük", "güçlü", "normal_uzun", "fazla");
            Ekle("sağlam", "orta", "küçük", "orta", "orta", "orta");
            Ekle("sağlam", "orta", "orta", "normal_güçlü", "normal_uzun", "orta");
            Ekle("sağlam", "orta", "büyük", "güçlü", "orta", "çok_fazla");
            Ekle("sağlam", "büyük", "küçük", "normal_güçlü", "normal_uzun", "fazla");
            Ekle("sağlam", "büyük", "orta", "normal_güçlü", "uzun", "fazla");
            Ekle("sağlam", "büyük", "büyük", "güçlü", "uzun", "çok_fazla");

            return kurallar;
        }
    }
}
