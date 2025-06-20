﻿using System;
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

        


       private void btn2_Click(object sender, EventArgs e)
        {
            string engWord = textBox1.Text.Trim();
            string turWord = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(engWord) || string.IsNullOrEmpty(turWord) || string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve görsel seçin!");
                return;
            }

            string cleanTurWord = turWord.ToLower()
                .Replace("ç", "c").Replace("ğ", "g").Replace("ü", "u").Replace("ö", "o")
                .Replace("ş", "s").Replace("ı", "i").Replace("İ", "i")
                .Replace(" ", "").Replace("-", "").Replace("é", "e");

            string newImageName = cleanTurWord + ".jpeg";
            string newImageFullPath = Path.Combine(imageSaveFolder, newImageName);

            try
            {
                // Görseli kopyala
                File.Copy(selectedImagePath, newImageFullPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görsel kopyalanırken hata oluştu: " + ex.Message);
                return;
            }

            try
            {
                // VERİTABANINA INSERT
                using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
                {
                    conn.Open();

                    // TEST → Hangi path gönderiyoruz?
                    MessageBox.Show("KAYDEDİLECEK PATH: " + newImageFullPath);

                    int newWordId = 0;

                    // 1️⃣ WORDS tablosuna ekle → word_id al
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO words (eng_word, tur_word, image_path)
                VALUES (@engWord, @turWord, @imagePath);
                SELECT SCOPE_IDENTITY();
            ", conn))
                    {
                        cmd.Parameters.AddWithValue("@engWord", engWord);
                        cmd.Parameters.AddWithValue("@turWord", turWord);
                        cmd.Parameters.AddWithValue("@imagePath", newImageFullPath);

                        object result = cmd.ExecuteScalar();
                        newWordId = Convert.ToInt32(result);
                    }

                    // 2️⃣ user_progress tablosuna da ekle (her kullanıcı için ekleyebilirsin → şimdilik user_id=1 örnek)
                    using (SqlCommand cmd2 = new SqlCommand(@"
                INSERT INTO user_progress (user_id, word_id, correct_count, last_answer_date)
                VALUES (@userId, @wordId, 0, GETDATE());
            ", conn))
                    {
                        cmd2.Parameters.AddWithValue("@userId", 1); // Şimdilik user_id = 1
                        cmd2.Parameters.AddWithValue("@wordId", newWordId);

                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kelime ve kullanıcı ilerlemesi başarıyla eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("VERİTABANINA EKLERKEN HATA OLDU: " + ex.Message);
            }

            // Temizle
            textBox1.Clear();
            textBox2.Clear();
            selectedImagePath = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string engWord = textBox1.Text.Trim();
            string turWord = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(engWord) || string.IsNullOrEmpty(turWord) || string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve görsel seçin!");
                return;
            }

           
            string cleanTurWord = turWord.ToLower()
                .Replace("ç", "c").Replace("ğ", "g").Replace("ü", "u").Replace("ö", "o")
                .Replace("ş", "s").Replace("ı", "i").Replace("İ", "i")
                .Replace(" ", "").Replace("-", "").Replace("é", "e");

            string newImageName = cleanTurWord + ".jpeg";
            string newImageFullPath = Path.Combine(imageSaveFolder, newImageName);

            try
            {
               
                File.Copy(selectedImagePath, newImageFullPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görsel kopyalanırken hata oluştu: " + ex.Message);
                return;
            }

            
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

        private void btngrslsc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Görsel Seçiniz";
            ofd.Filter = "Tüm Resimler (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tüm Dosyalar (*.*)|*.*";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



