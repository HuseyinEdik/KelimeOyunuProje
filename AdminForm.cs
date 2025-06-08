using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace KelimeOyunuProje
{
    public partial class AdminForm : Form
    {
        string selectedImagePath = "";  
        string imageSaveFolder = @"C:\Users\Hüsocell\Desktop\Kelime Oyunu\KelimeOyunuProje\images.project\";

        public AdminForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Görsel Seçiniz";
            ofd.Filter = "Resim Dosyaları (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                MessageBox.Show("Seçilen Görsel: " + selectedImagePath);
            }
            else
            {
                MessageBox.Show("Görsel seçilmedi.");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string engWord = textBox1.Text.Trim();
            string turWord = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(engWord) || string.IsNullOrEmpty(turWord) || string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve görsel seçin!");
                return;
            }

            // Türkçe karakterleri temizleyip görsel ismi üretelim
            string cleanTurWord = turWord.ToLower()
                .Replace("ç", "c").Replace("ğ", "g").Replace("ü", "u").Replace("ö", "o")
                .Replace("ş", "s").Replace("ı", "i").Replace("İ", "i")
                .Replace(" ", "").Replace("-", "").Replace("é", "e");

            string newImageName = cleanTurWord + ".jpeg";
            string newImageFullPath = Path.Combine(imageSaveFolder, newImageName);

            try
            {
                // Görseli hedef klasöre kopyala
                File.Copy(selectedImagePath, newImageFullPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görsel kopyalanırken hata oluştu: " + ex.Message);
                return;
            }

            // Veritabanına ekleme
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO words (eng_word, tur_word, image_path)
                    VALUES (@engWord, @turWord, @imagePath);
                ", conn))
                {
                    cmd.Parameters.AddWithValue("@engWord", engWord);
                    cmd.Parameters.AddWithValue("@turWord", turWord);
                    cmd.Parameters.AddWithValue("@imagePath", newImageFullPath);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kelime başarıyla eklendi!");

            // Alanları temizle
            textBox1.Clear();
            textBox2.Clear();
            selectedImagePath = "";
        }

        private void geriadmin_Click(object sender, EventArgs e)
        {
            this.Close();
            AnaMenüForm yeniana = new AnaMenüForm();
            yeniana.Show();
        }
    }
}



