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
    public partial class şifredeğiştirme : Form
    {
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        public şifredeğiştirme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtEski.Text == "" ||txtYeni.Text=="" )
            {
                MessageBox.Show("fill in the fields");

            }

            else if (txtYeni.Text.Length <3)
                
            {
                MessageBox.Show("enter at least 4 characters");

            }



            else
            {
                SqlCommand komut = new SqlCommand("update customers set password =  @p1 where password =@p2", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtEski.Text);
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("change password successful ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
                else
                {

                    MessageBox.Show("change password failed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                }

                con.Close();

                txtEski.Text = "";
                txtYeni.Text = "";

            }
        }
    }
}
