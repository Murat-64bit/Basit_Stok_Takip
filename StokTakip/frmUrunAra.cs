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
    public partial class frmUrunAra : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public frmUrunAra()
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

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmAnaSayfa fr = new frmAnaSayfa();
            fr.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_STOK where ad LIKE '%" + txtAra.Text + "%'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void frmUrunAra_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
