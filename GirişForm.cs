
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

namespace KelimeOyunuProje
{
    public partial class GirişForm : Form
    {
        public GirişForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
             
            string connectionString = "Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtbxUserName.Text.Trim());  
                    cmd.Parameters.AddWithValue("@password", txtbxPassword.Text.Trim()); 

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Giriş Başarılı!");

                        this.Hide();

                        AnaMenüForm mainForm = new AnaMenüForm();   
                        mainForm.Show();  
                          

                    }
                    else
                    {
                        MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!  Lütfen tekrar deneyiniz.");
                    }
                }
            }
        }

        private void txtbxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
              
         
            string connectionString = "Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string insertUser = "INSERT INTO users (username, password) VALUES (@username, @password)";

                using (SqlCommand cmd = new SqlCommand(insertUser, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtbxUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtbxPassword.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Bu kullanıcı zaten kayıtlı!!!!!!!!!!");

                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarılı!");
                        this.Close();  
                    }
                    else
                    {
                        MessageBox.Show("Kayıt yapılamadı. Lütfen tekrar deneyin.");
                    }
                
            }
        }

    }

        private void btnFpass_Click(object sender, EventArgs e)
        {
            this.Hide();

            ŞifreUnuttumForm yeniForm = new ŞifreUnuttumForm();
            yeniForm.Show();
        }
    }
}
