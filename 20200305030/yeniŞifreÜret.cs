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
    public partial class yeniŞifreÜret : Form
    {
        public yeniŞifreÜret()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTc.Text == "" || txtTel.Text == "" || txtYeni.Text=="")
            {
                MessageBox.Show("fill in the fields");

            }

            else if (txtYeni.Text.Length < 3)

            {
                MessageBox.Show("enter at least 4 characters");

            }



            else
            {
                SqlCommand komut = new SqlCommand("update customers set password =  @p1 where tcNo =@p2 and phoneNumber=@p3 ", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtTc.Text);
                komut.Parameters.AddWithValue("@p3", txtTel.Text);
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("new password successful ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    MessageBox.Show("new password failed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                }

                con.Close();

                txtTc.Text = "";
                txtYeni.Text = "";
                txtTel.Text = "";

            }
        }
    }
}
