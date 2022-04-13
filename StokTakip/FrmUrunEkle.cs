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
    public partial class FrmUrunEkle : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmUrunEkle()
        {
            InitializeComponent();
        }
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_STOK", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text != "" && txtAlisFiyat.Text != "" && txtSatisFiyat.Text != "" && txtUrunad.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_STOK (ad,alisfiyat,satisfiyat,adet,depono) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUrunad.Text);
                komut.Parameters.AddWithValue("@p2", txtAlisFiyat.Text);
                komut.Parameters.AddWithValue("@p3", txtSatisFiyat.Text);
                komut.Parameters.AddWithValue("@p4", txtAdet.Text);
                komut.Parameters.AddWithValue("@p5", mskDepoNo.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ürün sisteme eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Satır değerleri boş olduğu için eklenilmedi lütfen seçim yapıp tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
