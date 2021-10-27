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
    public partial class frmEkleGuncelle : Form
    {

        public int workerID = 0;

        public frmEkleGuncelle()
        {
            InitializeComponent();
        }

        public frmEkleGuncelle(int id)
        {
            InitializeComponent();
            dbDataContext db = new dbDataContext();

            workerID = id;

            Worker w = db.Workers.Where(op => op.ID == workerID).FirstOrDefault();

            txtIsım.Text = w.Name;
            txtSoyisim.Text = w.Surname;
            txtMeslek.Text = w.TitleName;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();

            if (workerID > 0)
            {
                Worker w = db.Workers.Where(op => op.ID == workerID).FirstOrDefault();

                w.Name = txtIsım.Text;
                w.Surname = txtSoyisim.Text;
                w.TitleName = txtMeslek.Text;

                db.SubmitChanges();
            }
            else
            {
                Worker w = new Worker();

                w.Name = txtIsım.Text;
                w.Surname = txtSoyisim.Text;
                w.TitleName = txtMeslek.Text;

                db.Workers.InsertOnSubmit(w);
                db.SubmitChanges();
            }

            this.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
