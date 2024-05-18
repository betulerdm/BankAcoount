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
    public partial class Yetkiliişlem : Form
    {
        public Yetkiliişlem()
        {
            InitializeComponent();
        }

        private void Yetkiliişlem_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            müşteriara ma = new müşteriara();
            ma.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            müşterigüncelle mg = new müşterigüncelle();
            mg.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
          
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            müşterilistele ml = new müşterilistele();
            ml.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();

        }
    }
}
