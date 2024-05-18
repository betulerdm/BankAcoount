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
    public partial class müşterigüncelle : Form
    {
        public müşterigüncelle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from customers where ID= @p1 or tcNo= @p2", con);
            komut.Parameters.AddWithValue("@p1", txtAra.Text);
            komut.Parameters.AddWithValue("@p2", txtAra.Text);


            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtId.Text = dr["ID"].ToString();
                txtTcNo.Text = dr["tcNo"].ToString();
                txtName.Text = dr["nameSurname"].ToString();
                txtAdres.Text = dr["address"].ToString();
                txtPhone.Text = dr["phoneNumber"].ToString();
                txtH.Text = dr["balance"].ToString();
            }
            else
            {

                MessageBox.Show(txtId.Text + " not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtName.Text = "";
                txtTcNo.Text = "";
                txtAdres.Text = "";
                txtH.Text = "";
                txtPhone.Text = "";
            }

            con.Close();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update customers set nameSurname= @p1 , address= @p2, phoneNumber=@p3 where ID=@p4 or tcNo=@p5", con);
            komut.Parameters.AddWithValue("@p4", txtAra.Text);
            komut.Parameters.AddWithValue("@p5", txtAra.Text);
            komut.Parameters.AddWithValue("@p1", txtName.Text);
            komut.Parameters.AddWithValue("@p2", txtAdres.Text);
            komut.Parameters.AddWithValue("@p3", txtPhone.Text);

            con.Open();

            int sonuc = komut.ExecuteNonQuery();
            if (sonuc == 1)
            {
                MessageBox.Show( "update succeed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                MessageBox.Show( "update failed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtName.Text = "";
                txtTcNo.Text = "";
                txtAdres.Text = "";
                txtH.Text = "";
                txtPhone.Text = "";
            }

            con.Close();

        }
    }
}
