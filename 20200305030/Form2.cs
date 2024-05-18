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
    public partial class Form2 : Form
    {
        private BankaHesabi bankaHesabi;
        public Form2()
        {
            InitializeComponent();
             bankaHesabi = new BankaHesabi();
       
       }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            decimal yatirilanMiktar = Convert.ToDecimal(txtYatirilanPara.Text);
            bankaHesabi.ParaGelisi(yatirilanMiktar);
            MessageBox.Show(yatirilanMiktar.ToString("C") + " TL hesabınıza yatırıldı.");
            txtYatirilanPara.Clear();
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            decimal cekilenMiktar = Convert.ToDecimal(txtCekilenPara.Text);
            bankaHesabi.ParaGidis(cekilenMiktar);
            MessageBox.Show(cekilenMiktar.ToString("C") + " TL hesabınızdan çekildi.");
            txtCekilenPara.Clear();
        }

        private void btnBakiye_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mevcut bakiyeniz: " + bankaHesabi.Bakiye().ToString("C"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCekilenPara_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
