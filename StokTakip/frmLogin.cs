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
    public partial class frmLogin : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("select * from TBL_LOGIN where kad=@t1 and ksifre=@t2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@t1", txtkad.Text);
            komut2.Parameters.AddWithValue("@t2", txtksifre.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                frmAnaSayfa fr = new frmAnaSayfa();
                lbladsoyad.Text = dr2[3].ToString();

                fr.adsoyad = lbladsoyad.Text;
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Şifre veya kullanıcı adınıı yanlış girdiniz lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
