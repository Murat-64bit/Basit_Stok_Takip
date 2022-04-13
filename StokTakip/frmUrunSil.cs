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
    public partial class frmUrunSil : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmUrunSil()
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
        private void button3_Click_1(object sender, EventArgs e)
        {
            frmAnaSayfa fr = new frmAnaSayfa();
            fr.Show();
            this.Hide();
        }

        private void frmUrunSil_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text != "" && txtAlisFiyat.Text !="" && txtSatisFiyat.Text != "" && txtUrunad.Text != "" && lblid.Text !="")
            {
                SqlCommand komut = new SqlCommand("delete from TBL_STOK where id=@id", bgl.baglanti());
                komut.Parameters.AddWithValue("@id", lblid.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ürün sistemden silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                //Temizle();
            }
            else
            {
                MessageBox.Show("Satır değerleri boş olduğu için silinemedi lütfen seçim yapıp tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
