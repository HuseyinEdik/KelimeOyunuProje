using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KelimeOyunuProje
{
    public partial class RaporForm : Form
    {
        public RaporForm()
        {
            InitializeComponent();
        }

        private void RaporForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=dil_uygulamasi2;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT
                        up.user_id AS [Kullanıcı ID],
                        CONVERT(date, up.last_answer_date) AS [Sınav Tarihi],
                        CAST(100.0 * up.correct_count / 6 AS DECIMAL(5,2)) AS [Doğru Yüzdesi]
                    FROM user_progress up
                    ORDER BY up.user_id, up.last_answer_date DESC;
                ", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            AnaMenüForm anaMenu = new AnaMenüForm();  
            anaMenu.Show();
            this.Close();
        }
    }
}
