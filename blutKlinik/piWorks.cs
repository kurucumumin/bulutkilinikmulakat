using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blutKlinik
{
    public partial class piWorks : Form
    {
        public piWorks()
        {
            InitializeComponent();
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSayi1.Text != "" && txtSayi2.Text != "")
                {
                    int a = Convert.ToInt32(txtSayi1.Text);
                    int b = Convert.ToInt32(txtSayi2.Text);

                    MessageBox.Show("1. Sayı: " + a + Environment.NewLine + "2. Sayı: " + b);
                }
                else
                    MessageBox.Show("Boş geçemezsiniz");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen sayı giriniz");
            }
        }
    }
}
