
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KelimeOyunuProje
{
    public partial class WordleForm : Form
    {
        string hedefKelime = "";

        // YENİ: Global değişkenler
        Bitmap oyunBitmap;
        Graphics oyunGraphics;
        int tahminSayisi = 0;

        public WordleForm()
        {
            InitializeComponent();
        }

        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            hedefKelime = KelimeSecVeritabanindan();

            if (string.IsNullOrEmpty(hedefKelime))
            {
                MessageBox.Show("Uygun kelime bulunamadı! Lütfen veritabanını kontrol edin.");
                lblDurum2.Text = "Yeni oyun BAŞLATILAMADI!";
                return;
            }

            lblDurum2.Text = $"Yeni oyun başladı! ({hedefKelime.Length} harfli kelime)";
            txtTahmin.Text = "";

            // YENİ: Yeni bitmap ve grafik başlat
            oyunBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            oyunGraphics = Graphics.FromImage(oyunBitmap);
            tahminSayisi = 0;

            pictureBox1.Image = oyunBitmap;

            // DEBUG → seçilen kelime gösterebilirsin:
            // MessageBox.Show("Seçilen kelime: " + hedefKelime);
        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hedefKelime))
            {
                lblDurum2.Text = "Henüz oyun başlamadı. Lütfen 'Yeni Oyun' tıklayın.";
                return;
            }

            string tahmin = txtTahmin.Text.Trim().ToLower();

            if (tahmin.Length != hedefKelime.Length)
            {
                lblDurum2.Text = $"Kelime uzunluğu {hedefKelime.Length} harf olmalı!";
                return;
            }

           
            int kareBoyut = 50;
            int baslangicX = 10;
            int baslangicY = 10 + tahminSayisi * (kareBoyut + 10);

            for (int i = 0; i < tahmin.Length; i++)
            {
                char tahminHarf = tahmin[i];
                char hedefHarf = hedefKelime[i];

                Brush renk;

                if (tahminHarf == hedefHarf)
                {
                    renk = Brushes.Green;
                }
                else if (hedefKelime.Contains(tahminHarf))
                {
                    renk = Brushes.Yellow;
                }
                else
                {
                    renk = Brushes.Gray;
                }

                oyunGraphics.FillRectangle(renk, baslangicX + i * (kareBoyut + 10), baslangicY, kareBoyut, kareBoyut);
                oyunGraphics.DrawRectangle(Pens.Black, baslangicX + i * (kareBoyut + 10), baslangicY, kareBoyut, kareBoyut);
                oyunGraphics.DrawString(tahminHarf.ToString().ToUpper(), new Font("Arial", 24), Brushes.Black, baslangicX + i * (kareBoyut + 10) + 10, baslangicY + 5);
            }

            // YENİ: resmi güncelle
            pictureBox1.Image = oyunBitmap;

            // YENİ: tahmin sayısını artır
            tahminSayisi++;

            if (tahmin == hedefKelime)
            {
                lblDurum2.Text = "🎉 Tebrikler! Doğru bildiniz!";
            }
            else
            {
                lblDurum2.Text = "Tekrar deneyin!";
            }


            if (tahminSayisi == 5)
            {

                MessageBox.Show("hakkınız doldu!!!");
            }
        }
        private string KelimeSecVeritabanindan()
        {
            string secilenKelime = "";

            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 w.eng_word
                    FROM words w
                    JOIN user_progress up ON up.word_id = w.id
                    WHERE LEN(w.eng_word) = 5
                      AND up.correct_count >=0  
                ", conn))
                {
                    object result = cmd.ExecuteScalar();

                    
                    if (result == null || result == DBNull.Value)
                    {
                        using (SqlCommand cmd2 = new SqlCommand(@"
                            SELECT TOP 1 w.eng_word
                            FROM words w
                            WHERE LEN(w.eng_word) = 5
                            ORDER BY NEWID();
                        ", conn))
                        {
                            result = cmd2.ExecuteScalar();
                        }
                    }

                    if (result != null && result != DBNull.Value)
                    {
                        secilenKelime = result.ToString().ToLower();
                    }
                }
            }

            return secilenKelime;
        }

        private void geriwordle_Click(object sender, EventArgs e)
        {
            this.Close();
            AnaMenüForm yenimenü = new AnaMenüForm();   
            yenimenü.Show();
        }
    }
}
