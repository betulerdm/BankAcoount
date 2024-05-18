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
using System.Xml.Linq;

namespace _20200305030
{
    public partial class paraçekmeişlemi : Form
    {
        public paraçekmeişlemi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        private void withdraw_Click(object sender, EventArgs e)
        {
           
            float sayi = float.Parse(maskedTextBox1.Text);
            if (sayi > Form1.mbakiye)
            {
                MessageBox.Show("insufficient funds");
          
         }
        else
            {
                SqlCommand komut = new SqlCommand("update customers set balance -=  @p1 where ID=@p2", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mID);
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("withdrawal successful ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mbakiye -= sayi;
                    

                    haraketkaydet.kaydet(Form1.mID,sayi+"money withdraw");
                }
                else
                {

                    MessageBox.Show("withdrawal failed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                   
                    
                }

                con.Close();

                maskedTextBox1.Text = "";

            }


        }
    }
}
