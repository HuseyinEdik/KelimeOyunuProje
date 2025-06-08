using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeOyunuProje
{
    public partial class AnaMenüForm: Form
    {
        public AnaMenüForm()
        {
            InitializeComponent();
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

           RaporForm yeniForm = new RaporForm();
            yeniForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            AyarlarForm yeni1Form = new AyarlarForm();
            yeni1Form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            

            this.Hide();

            AdminForm yeni2Form = new AdminForm();
            yeni2Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

           SınavForm yeni3Form = new SınavForm();
            yeni3Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            WordleForm yeni4Form = new WordleForm();

            yeni4Form.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu kısım henüz hazır değil dilerseniz diğer çalışma şekillerine bakınız."); 
        }
    }
}
