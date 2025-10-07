# 💧 Bulanık Mantık Çamaşır Makinesi

**Bulanık Mantık Çamaşır Makinesi**, gerçek bir çamaşır makinesi kontrol sisteminin mantığını taklit eden, **bulanık mantık tabanlı** bir karar verme uygulamasıdır.  
Proje, **C# .NET (WinForms)** ile geliştirilmiş olup, klasik mantıktan farklı olarak **insan düşünme biçimini modelleyen bulanık mantık sistemi** kullanır.

---

## ⚙️ Proje Amacı

Klasik çamaşır makinelerinde su seviyesi, sıcaklık veya yıkama süresi gibi değişkenler sabit değerlerle belirlenir.  
Bu projede ise sistem, **bulanık kurallar** yardımıyla bu değerleri dinamik olarak belirler.

Örneğin:
- Giysi kirlilik oranı “orta”  
- Giysi miktarı “az”  
→ yıkama süresi = “kısa”  
→ su seviyesi = “düşük”  
→ sıcaklık = “orta”

---

## 🧩 Kullanılan Teknolojiler

| Katman | Teknolojiler |
|--------|---------------|
| **Geliştirme Ortamı** | Visual Studio 2022 |
| **Programlama Dili** | C# (.NET Framework / WinForms) |
| **Mantık Motoru** | Bulanık Mantık (Fuzzy Logic) |
| **Arayüz** | Windows Forms GUI |

---

## 🧠 Bulanık Mantık Sistemi

### Giriş Değişkenleri:
- **Kirlilik Oranı** → (Düşük, Orta, Yüksek)  
- **Giysi Miktarı** → (Az, Orta, Fazla)

### Çıkış Değişkenleri:
- **Yıkama Süresi** → (Kısa, Orta, Uzun)  
- **Su Seviyesi** → (Düşük, Orta, Yüksek)  
- **Sıcaklık** → (Soğuk, Ilık, Sıcak)

### Bulanık Kurallar:
| # | Kirlilik | Giysi Miktarı | Süre | Su | Sıcaklık |
|---|-----------|---------------|-------|-----|-----------|
| 1 | Düşük | Az | Kısa | Düşük | Soğuk |
| 2 | Orta | Az | Orta | Orta | Ilık |
| 3 | Yüksek | Fazla | Uzun | Yüksek | Sıcak |
| 4 | Yüksek | Orta | Uzun | Orta | Ilık |
| 5 | Düşük | Fazla | Orta | Yüksek | Soğuk |

Bu kuralların kombinasyonuna göre sistem **çıktı değerlerini bulanıklaştırır**, ardından **durulaştırma (defuzzification)** aşamasıyla kesin sayısal değerlere çevirir.

---

## 🧮 Kullanılan Matematiksel Yaklaşım

- **Bulanık Kümeleme (Fuzzification)**  
  → Üyelik fonksiyonları: üçgensel veya trapez  
- **Kural Çıkarımı (Inference)**  
  → Mamdani yaklaşımı  
- **Durulaştırma (Defuzzification)**  
  → Ağırlıklı Ortalama (Centroid Method)

---

## 🧭 Proje Dizin Yapısı

```
BulanikMantikCamasirMakinesi/
├─ BulanikMantikCamasirMakinesi/
│  ├─ Form1.cs
│  ├─ FuzzyLogic.cs
│  ├─ Program.cs
│  ├─ Resources/
│  └─ Properties/
└─ BulanikMantikCamasirMakinesi.sln
```

---

## 🚀 Çalıştırma

```powershell
cd BulanikMantikCamasirMakinesi
BulanikMantikCamasirMakinesi.sln
# Visual Studio’da aç
# F5 ile çalıştır
```

---

## 🎨 Arayüz Özellikleri

- Girişler: “Kirlilik Oranı” ve “Giysi Miktarı” slider veya combobox ile seçilir.  
- Çıkışlar: Hesaplanan yıkama süresi, su seviyesi ve sıcaklık ekranda gösterilir.  
- Grafik alanı: Üyelik fonksiyonları isteğe bağlı olarak görselleştirilebilir.

---

## 🧠 Örnek Hesaplama

> **Kirlilik = 70**, **Giysi Miktarı = 40**

→ Üyelik hesaplamaları sonucunda:  
- Süre = 48 dk  
- Su seviyesi = 7.5 L  
- Sıcaklık = 45°C

---



---

## 🧾 Lisans
MIT License (isteğe bağlı)

---

Bu proje, **bulanık mantık temellerini uygulamalı olarak öğrenmek** ve **akıllı sistemlerde karar verme süreçlerini modellemek** amacıyla geliştirilmiştir.  
Gerçek bir çamaşır makinesi kontrol algoritmasının akademik prototipidir.
