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
    public partial class frmBulutKlinik : Form
    {
        public frmBulutKlinik()
        {
            InitializeComponent();

            #region Tüm Datanın dolduğu yer

            loadGrid();

            #endregion

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
       System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
       dgKisiler, new object[] { true });

        }

        private void frmBulutKlinik_Load(object sender, EventArgs e)
        {
            #region Grid için ayarlar

            #region Boş Kolonların Gizlendiği Yer

            dgKisiler.Columns[3].Visible = false;
            dgKisiler.Columns[4].Visible = false;
            dgKisiler.Columns[5].Visible = false;

            #endregion

            #region Kolonlara Boyut Verme

            dgKisiler.Columns[1].Width = 250;
            dgKisiler.Columns[2].Width = 350;
            dgKisiler.Columns[6].Width = 400;

            #endregion

            #endregion
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmEkleGuncelle frm = new frmEkleGuncelle();
            frm.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgKisiler.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dgKisiler.SelectedCells[0].Value);

                frmEkleGuncelle frm = new frmEkleGuncelle(id);
                frm.Show();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();

            if (dgKisiler.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dgKisiler.SelectedCells[0].Value);

                Worker w = db.Workers.Where(op => op.ID == id).FirstOrDefault();

                w.Telephone = "DELETE";

                db.SubmitChanges();

                loadGrid();
            }
        }

        private void loadGrid()
        {
            #region Tüm Datanın dolduğu yer

            dbDataContext db = new dbDataContext();

            dgKisiler.DataSource = db.Workers.Where(op => op.Telephone == null).ToList();  // telefon dememde ki sebep silme tarafında telefon kolonuna veri yazıcam ve onu getirmeyecek

            #endregion
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}
