using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StokTakip
{
    public partial class frmUrunGuncelle : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmUrunGuncelle()
        {
            InitializeComponent();
        }

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_STOK", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource = dt;
        }

        void Temizle()
        {
            txtUrunad.Text = "";
            txtAlisFiyat.Text = "";
            txtAdet.Text = "";
            txtSatisFiyat.Text = "";
            mskDepoNo.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAnaSayfa fr = new frmAnaSayfa();
            fr.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text != "" && txtAlisFiyat.Text != "" && txtSatisFiyat.Text != "" && txtUrunad.Text != "")
            {
                SqlCommand komut = new SqlCommand("update TBL_STOK set ad=@ad,alisfiyat=@alisfiyat,satisfiyat=@satisfiyat,adet=@adet,depono=@depono where id=@id", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtUrunad.Text);
            komut.Parameters.AddWithValue("@alisfiyat", txtAlisFiyat.Text);
            komut.Parameters.AddWithValue("@satisfiyat", txtSatisFiyat.Text);
            komut.Parameters.AddWithValue("@adet", txtAdet.Text);
            komut.Parameters.AddWithValue("@depono", mskDepoNo.Text);
            komut.Parameters.AddWithValue("@id", lblid.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Ürün sistemde güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            }
            else
            {
                MessageBox.Show("Satır değerleri boş olduğu için güncellenmeli lütfen seçim yapıp tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = grd.SelectedCells[0].RowIndex;
                lblid.Text = grd.Rows[secilen].Cells[0].Value.ToString();
                txtUrunad.Text = grd.Rows[secilen].Cells[1].Value.ToString();
                txtAlisFiyat.Text = grd.Rows[secilen].Cells[2].Value.ToString();
                txtSatisFiyat.Text = grd.Rows[secilen].Cells[3].Value.ToString();
                txtAdet.Text = grd.Rows[secilen].Cells[4].Value.ToString();
                mskDepoNo.Text = grd.Rows[secilen].Cells[5].Value.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void frmUrunGuncelle_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
