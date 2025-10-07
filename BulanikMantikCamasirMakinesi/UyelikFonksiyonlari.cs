using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikCamasirMakinesi
{
    public abstract class UyelikFonksiyonu
    {
        public abstract double UyeligiHesapla(double x);

    }
    public class UcgenUyelik : UyelikFonksiyonu
    {
        public double a, b, c;

        public UcgenUyelik(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double UyeligiHesapla(double x)
        {
            if (x <= a || x >= c) return 0;
            if (x == b) return 1;
            if (x < b) return (x - a) / (b - a);
            return (c - x) / (c - b);
        }
    }
    public class YamukUyelik : UyelikFonksiyonu
    {
        public double a, b, c, d;

        public YamukUyelik(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public override double UyeligiHesapla(double x)
        {
            if (x <= a || x >= d) return 0;
            if (x >= b && x <= c) return 1;
            if (x > a && x < b) return (x - a) / (b - a);
            return (d - x) / (d - c);
        }
    }
}
