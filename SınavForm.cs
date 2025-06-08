using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KelimeOyunuProje
{
    public partial class SınavForm : Form
    {
        class ExamOption
        {
            public int id { get; set; }
            public string eng_word { get; set; }
            public string tur_word { get; set; }
            public string image_path { get; set; }
            public bool IsCorrect { get; set; }
        }

        List<ExamOption> currentOptions = new List<ExamOption>();
        int correctCount = 0;
        int wrongCount = 0;
        int currentQuestionNumber = 0;
        int maxQuestionCount = 10;  // varsayılan
        int currentUserId = 1;  // aktif kullanıcı

        public SınavForm()
        {
            InitializeComponent();
        }

        private void SınavForm_Load(object sender, EventArgs e)
        {
            // daily_limit değerini çekiyoruz
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 daily_limit FROM settings WHERE user_id = @userId", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        maxQuestionCount = Convert.ToInt32(result);
                    }
                }
            }

            correctCount = 0;
            wrongCount = 0;
            currentQuestionNumber = 0;

            lblSoruDogru1.Text = "Doğru: 0";
            lblSoruYanlis.Text = "Yanlış: 0";
            lblSoruNo.Text = "Soru: 0 / " + maxQuestionCount;

            // Butonları ortak click event’e bağlıyoruz
            btnA.Click += btnOption_Click;
            btnB.Click += btnOption_Click;
            btnC.Click += btnOption_Click;
            btnD.Click += btnOption_Click;

            LoadExamQuestion();
        }

        void LoadExamQuestion()
        {
            currentOptions.Clear();

            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.sp_sorularvesiklar", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Çalışacak kelime kalmadı!");
                            this.Close();
                            return;
                        }

                        while (reader.Read())
                        {
                            ExamOption option = new ExamOption()
                            {
                                id = reader.GetInt32(0),
                                eng_word = reader.GetString(1),
                                tur_word = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                image_path = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                IsCorrect = reader.GetInt32(4) == 1
                            };

                            currentOptions.Add(option);
                        }
                    }
                }
            }

            var correctOption = currentOptions.First(x => x.IsCorrect);
            string imageFullPath = correctOption.image_path.Trim();

            if (!File.Exists(imageFullPath))
            {
                MessageBox.Show("Dosya bulunamadı: " + imageFullPath);
                return;
            }

            // Önce eski resmi temizle
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            // Yeni resmi yükle
            pictureBox1.Image = Image.FromFile(imageFullPath);

            // Şıkları karıştır
            var shuffled = currentOptions.OrderBy(x => Guid.NewGuid()).ToList();

            btnA.Text = shuffled[0].eng_word;
            btnA.Tag = shuffled[0].IsCorrect;

            btnB.Text = shuffled[1].eng_word;
            btnB.Tag = shuffled[1].IsCorrect;

            btnC.Text = shuffled[2].eng_word;
            btnC.Tag = shuffled[2].IsCorrect;

            btnD.Text = shuffled[3].eng_word;
            btnD.Tag = shuffled[3].IsCorrect;

            // Soru numarasını güncelle
            lblSoruNo.Text = "Soru: " + (currentQuestionNumber + 1) + " / " + maxQuestionCount;
        }

        void btnOption_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            bool isCorrect = (bool)clicked.Tag;

            if (isCorrect)
            {
                correctCount++;
                lblSoruDogru1.Text = "Doğru: " + correctCount;
                UpdateProgress(currentOptions.First(x => x.IsCorrect).id, true);
            }
            else
            {
                wrongCount++;
                lblSoruYanlis.Text = "Yanlış: " + wrongCount;
                UpdateProgress(currentOptions.First(x => x.IsCorrect).id, false);
            }

            currentQuestionNumber++;

            if (currentQuestionNumber >= maxQuestionCount)
            {
                MessageBox.Show("Sınav bitti!\nDoğru: " + correctCount + "\nYanlış: " + wrongCount);
                this.Close();
                AnaMenüForm anaMenüForm = new AnaMenüForm();    
                anaMenüForm.Show();
                return;
            }

            LoadExamQuestion();
        }

        void UpdateProgress(int wordId, bool isCorrect)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.sp_UpdateProgress", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    cmd.Parameters.AddWithValue("@wordId", wordId);
                    cmd.Parameters.AddWithValue("@isCorrect", isCorrect ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gerisınav_Click(object sender, EventArgs e)
        {
            this.Close();
            AnaMenüForm yeniana = new AnaMenüForm();
            yeniana.Show();
        }
    }
}


