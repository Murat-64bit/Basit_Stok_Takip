using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StokTakip
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Integrated Security=True; AttachDbFileName='|DataDirectory|\DbStokTakip.mdf';");
            baglan.Open();
            return baglan;
        }
    }
}
