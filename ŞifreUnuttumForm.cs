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
    public partial class ŞifreUnuttumForm : Form
    {


        public ŞifreUnuttumForm()
        {
            InitializeComponent();


            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
        }
        string connectionString = "Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

             
        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

            GirişForm yeni = new GirişForm();
            yeni.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen yeni şifreyi ve tekrarını giriniz.");
                return;
            }

            
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updatePassword = "UPDATE users SET password = @password WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(updatePassword, conn))
                {
                    cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Şifre başarıyla güncellendi.");
                        this.Close();   
                    }
                    else
                    {
                        MessageBox.Show("Şifre güncellenemedi.");
                    }
                }
            }











            this.Hide();

            GirişForm yeni = new GirişForm();
             yeni.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM users WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Kullanıcı bulundu. Yeni şifreyi giriniz.");

                         
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı adı bulunamadı.");
                    }
                }
            }
        }
    }
}