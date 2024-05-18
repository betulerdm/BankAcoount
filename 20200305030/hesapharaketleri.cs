using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200305030
{
    public partial class hesapharaketleri : Form
    {
        public hesapharaketleri()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        private void hesap_haraketleri_Load(object sender, EventArgs e)
        {


            SqlCommand komut = new SqlCommand("select * from movements where consumerID=@p1", con);
            komut.Parameters.AddWithValue("@p1", Form1.mID);
            SqlDataAdapter da = new SqlDataAdapter(komut );
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            haraketkaydet.kaydet(Form1.mID, "Bir hareket kaydedildi.");
        }
    }
}
