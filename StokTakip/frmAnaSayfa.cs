using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        public string adsoyad;
        private void panel2_Click(object sender, EventArgs e)
        {
            FrmUrunEkle fr = new FrmUrunEkle();
            fr.Show();
            this.Hide();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            frmUrunSil fr = new frmUrunSil();
            fr.Show();
            this.Hide();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            frmUrunGuncelle fr = new frmUrunGuncelle();
            fr.Show();
            this.Hide();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            frmUrunAra fr = new frmUrunAra();
            fr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            lblad.Text = adsoyad;
        }
    }
}
