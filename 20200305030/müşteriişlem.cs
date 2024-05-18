using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200305030
{
    public partial class müşteriişlem : Form
    {
        public müşteriişlem()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void müşteriişlem_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = Form1.adSoyad;
            lblHesapNo.Text = Form1.mID.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            paraçekmeişlemi pc = new paraçekmeişlemi();
            pc.Show();
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            parayatırma py = new parayatırma();
            py.Show();
        }

        private void btnBakiyeGoruntule_Click(object sender, EventArgs e)
        {
            bakiye b = new bakiye();
            b.Show();
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            havale h = new havale();
            h.Show();
        }

        private void btnSifre_Click(object sender, EventArgs e)
        {
            şifredeğiştirme sd = new şifredeğiştirme();
            sd.Show();
        }

        private void btnHesapH_Click(object sender, EventArgs e)
        {
            hesapharaketleri hh = new hesapharaketleri();
            hh.Show();
     
        }
    }
}
