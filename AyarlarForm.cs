using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KelimeOyunuProje
{
    public partial class AyarlarForm: Form
    { 
        int currentUserId = 1;  // aktif kullanıcı (örnek 1)

        public AyarlarForm()
        {
            InitializeComponent();
            cmbBxQueCount.Items.Clear();
            cmbBxQueCount.Items.Add(5);
            cmbBxQueCount.Items.Add(10);
            cmbBxQueCount.Items.Add(15);
            cmbBxQueCount.Items.Add(20);
            cmbBxQueCount.Items.Add(25);
        }

        private void AyarlarForm_Load(object sender, EventArgs e)
        {
             

            // Ayardan mevcut değeri çek
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 daily_limit FROM settings WHERE user_id = @userId", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        cmbBxQueCount.SelectedItem = Convert.ToInt32(result);
                    }
                }
            }
        }

        private void Ayarları_Kaydet_Click(object sender, EventArgs e)
        {
            if (cmbBxQueCount.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir soru sayısı seçiniz!");
                return;
            }

            int selectedCount = Convert.ToInt32(cmbBxQueCount.SelectedItem);

            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM settings WHERE user_id = @userId)
                    BEGIN
                        UPDATE settings SET daily_limit = @count WHERE user_id = @userId;
                    END
                    ELSE
                    BEGIN
                        INSERT INTO settings (user_id, daily_limit) VALUES (@userId, @count);
                    END
                ", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    cmd.Parameters.AddWithValue("@count", selectedCount);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ayarlar kaydedildi!");
            this.Close();
            AnaMenüForm anaMenüForm = new AnaMenüForm();
            anaMenüForm.Show(); 
        }

        private void geriayar_Click(object sender, EventArgs e)
        {
            this.Close();
            AnaMenüForm yeniana = new AnaMenüForm();
            yeniana.Show();
        }
    }
}
