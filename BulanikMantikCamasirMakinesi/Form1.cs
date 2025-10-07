namespace BulanikMantikCamasirMakinesi
{
    public partial class Form1 : Form
    {
        private NumericUpDown nudHassaslik, nudMiktar, nudKirlilik;
        private Button btnHesapla;
        private Label lblDonusHizi, lblSure, lblDeterjan;
        private ListBox lstDonusDegerleri, lstSureDegerleri, lstDeterjanDegerleri;
        private Panel panelDonus, panelSure, panelDeterjan;
        private DataGridView dgvKurallar;
        private Cikti donusSonuc, sureSonuc, deterjanSonuc;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Bulanık Çamaşır Makinesi";
            this.Size = new Size(1200, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 9);

            Label baslik = new()
            {
                Text = "Bulanık Mantıkla Çalışan Çamaşır Makinesi",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(380, 5),
                AutoSize = true,
                ForeColor = Color.Navy
            };

            Label lbl1 = new() { Text = "Hassaslık", Location = new Point(40, 40) };
            Label lbl2 = new() { Text = "Miktar", Location = new Point(40, 90) };
            Label lbl3 = new() { Text = "Kirlilik", Location = new Point(40, 140) };

            nudHassaslik = new() { Minimum = 0, Maximum = 10, DecimalPlaces = 1, Increment = 0.1M, Location = new Point(150, 40), Width = 100 };
            nudMiktar = new() { Minimum = 0, Maximum = 10, DecimalPlaces = 1, Increment = 0.1M, Location = new Point(150, 90), Width = 100 };
            nudKirlilik = new() { Minimum = 0, Maximum = 10, DecimalPlaces = 1, Increment = 0.1M, Location = new Point(150, 140), Width = 100 };

            btnHesapla = new() { Text = "HESAPLA", Location = new Point(100, 200), Width = 120 ,Height=50};
            btnHesapla.Click += BtnHesapla_Click;

            GroupBox grpDonus = new() { Text = "Dönüş Hızı", Location = new Point(300, 40), Size = new Size(200, 80), ForeColor = Color.DarkSlateBlue };
            lblDonusHizi = new() { Text = "---", Location = new Point(20, 30), AutoSize = true };
            grpDonus.Controls.Add(lblDonusHizi);

            GroupBox grpSure = new() { Text = "Süre", Location = new Point(300, 130), Size = new Size(200, 80), ForeColor = Color.DarkSlateBlue };
            lblSure = new() { Text = "---", Location = new Point(20, 30), AutoSize = true };
            grpSure.Controls.Add(lblSure);

            GroupBox grpDeterjan = new() { Text = "Deterjan Miktarı", Location = new Point(300, 220), Size = new Size(200, 80), ForeColor = Color.DarkSlateBlue };
            lblDeterjan = new() { Text = "---", Location = new Point(20, 30), AutoSize = true };
            grpDeterjan.Controls.Add(lblDeterjan);

            dgvKurallar = new DataGridView()
            {
                Location = new Point(520, 40),
                Size = new Size(640, 260),
                ReadOnly = true,
                AllowUserToAddRows = false,
                ColumnCount = 8,
                RowHeadersVisible = false
            };
            dgvKurallar.Columns[0].Name = "Kural No";
            dgvKurallar.Columns[1].Name = "Ateşleme";
            dgvKurallar.Columns[2].Name = "Hassaslık";
            dgvKurallar.Columns[3].Name = "Miktar";
            dgvKurallar.Columns[4].Name = "Kirlilik";
            dgvKurallar.Columns[5].Name = "Dönüş";
            dgvKurallar.Columns[6].Name = "Süre";
            dgvKurallar.Columns[7].Name = "Deterjan";

            Label lblMamDonus = new() { Text = "Dönüş Mamdani", Location = new Point(40, 520), AutoSize = true };
            Label lblMamSure = new() { Text = "Süre Mamdani", Location = new Point(280, 520), AutoSize = true };
            Label lblMamDeterjan = new() { Text = "Deterjan Mamdani", Location = new Point(520, 520), AutoSize = true };

            panelDonus = new Panel() { Location = new Point(40, 330), Size = new Size(220, 180), BorderStyle = BorderStyle.FixedSingle };
            panelSure = new Panel() { Location = new Point(280, 330), Size = new Size(220, 180), BorderStyle = BorderStyle.FixedSingle };
            panelDeterjan = new Panel() { Location = new Point(520, 330), Size = new Size(220, 180), BorderStyle = BorderStyle.FixedSingle };

            panelDonus.Paint += PanelDonus_Paint;
            panelSure.Paint += PanelSure_Paint;
            panelDeterjan.Paint += PanelDeterjan_Paint;

            lstDonusDegerleri = new() { Location = new Point(40, 540), Size = new Size(220, 70) };
            lstSureDegerleri = new() { Location = new Point(280, 540), Size = new Size(220, 70) };
            lstDeterjanDegerleri = new() { Location = new Point(520, 540), Size = new Size(220, 70) };

            this.Controls.AddRange(new Control[] {
                baslik,
                lbl1, lbl2, lbl3,
                nudHassaslik, nudMiktar, nudKirlilik,
                btnHesapla,
                grpDonus, grpSure, grpDeterjan,
                panelDonus, panelSure, panelDeterjan,
                lblMamDonus, lblMamSure, lblMamDeterjan,
                lstDonusDegerleri, lstSureDegerleri, lstDeterjanDegerleri,
                dgvKurallar
            });
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            double hassaslik = (double)nudHassaslik.Value;
            double miktar = (double)nudMiktar.Value;
            double kirlilik = (double)nudKirlilik.Value;

            var girdiler = SistemVerisi.GirdileriHazirla(hassaslik, miktar, kirlilik);
            var ciktilar = SistemVerisi.CiktilariHazirla();
            var kurallar = SistemVerisi.KurallariHazirla();

            var motor = new Mamdani
            {
                Girdiler = girdiler,
                Ciktilar = ciktilar,
                Kurallar = kurallar
            };
            motor.Calistir();

            var donus = ciktilar.First(c => c.Ad == "DonusHizi");
            var sure = ciktilar.First(c => c.Ad == "Sure");
            var deterjan = ciktilar.First(c => c.Ad == "Deterjan");

            double donusDeger = Durulama.AgirlikliOrtalama(donus);
            double sureDeger = Durulama.AgirlikliOrtalama(sure);
            double deterjanDeger = Durulama.AgirlikliOrtalama(deterjan);

            donusSonuc = donus;
            sureSonuc = sure;
            deterjanSonuc = deterjan;

            lblDonusHizi.Text = donusDeger.ToString("0.00");
            lblSure.Text = sureDeger.ToString("0.00") + " dk";
            lblDeterjan.Text = deterjanDeger.ToString("0.00") + " gr";

            dgvKurallar.Rows.Clear();
            int index = 1;
            foreach (var kural in kurallar)
            {
                var hVal = girdiler[0].Bulaniklastir()[kural.Girdiler["Hassaslik"]];
                var mVal = girdiler[1].Bulaniklastir()[kural.Girdiler["Miktar"]];
                var kVal = girdiler[2].Bulaniklastir()[kural.Girdiler["Kirlilik"]];
                double minDeger = Math.Min(hVal, Math.Min(mVal, kVal));
                if (minDeger > 0)
                {
                    string dOut = $"{kural.Ciktilar["DonusHizi"]} ({minDeger:0.00})";
                    string sOut = $"{kural.Ciktilar["Sure"]} ({minDeger:0.00})";
                    string detOut = $"{kural.Ciktilar["Deterjan"]} ({minDeger:0.00})";
                    dgvKurallar.Rows.Add(
                        $"Kural {index}",
                        minDeger.ToString("0.00"),
                        $"{kural.Girdiler["Hassaslik"]} ({hVal:0.00})",
                        $"{kural.Girdiler["Miktar"]} ({mVal:0.00})",
                        $"{kural.Girdiler["Kirlilik"]} ({kVal:0.00})",
                        dOut, sOut, detOut
                    );
                }
                index++;
            }

            lstDonusDegerleri.Items.Clear();
            lstSureDegerleri.Items.Clear();
            lstDeterjanDegerleri.Items.Clear();

            foreach (var kvp in donus.CiktiDegerleri)
                lstDonusDegerleri.Items.Add($"{kvp.Key} → {kvp.Value:0.00}");

            foreach (var kvp in sure.CiktiDegerleri)
                lstSureDegerleri.Items.Add($"{kvp.Key} → {kvp.Value:0.00}");

            foreach (var kvp in deterjan.CiktiDegerleri)
                lstDeterjanDegerleri.Items.Add($"{kvp.Key} → {kvp.Value:0.00}");

            panelDonus.Invalidate();
            panelSure.Invalidate();
            panelDeterjan.Invalidate();
        }

        private void PanelDonus_Paint(object sender, PaintEventArgs e)
        {
            if (donusSonuc != null)
                GrafikCizici.CiktiyiCiz(e.Graphics, donusSonuc, panelDonus.ClientRectangle);
        }

        private void PanelSure_Paint(object sender, PaintEventArgs e)
        {
            if (sureSonuc != null)
                GrafikCizici.CiktiyiCiz(e.Graphics, sureSonuc, panelSure.ClientRectangle);
        }

        private void PanelDeterjan_Paint(object sender, PaintEventArgs e)
        {
            if (deterjanSonuc != null)
                GrafikCizici.CiktiyiCiz(e.Graphics, deterjanSonuc, panelDeterjan.ClientRectangle);
        }
    }
}
