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
    public partial class havale : Form
    {
        public havale()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        private void havale_Load(object sender, EventArgs e)
        {

        }

        private void withdraw_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(txtMiktar.Text);
            int aliciNo = int.Parse(txtNo.Text);



            SqlCommand komut = new SqlCommand("select * from customers where ID= @p1 ", con);
            komut.Parameters.AddWithValue("@p1", txtNo.Text);
            bool sonuc = false;
         

            con.Open();


            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                sonuc = true;
            }
            else
            {
                MessageBox.Show("Account number is incorrect!!!");
            }
            con.Close();




             if (sayi > Form1.mbakiye && sonuc)
            {
                MessageBox.Show("insufficient funds");

            }
            else
            {
                SqlCommand komut2 = new SqlCommand("update customers set balance -=  @p1 where ID=@p2", con);
                SqlCommand komut3 = new SqlCommand("update customers set balance +=  @p3 where ID=@p2", con);
                komut2.Parameters.AddWithValue("@p1", sayi);
                komut2.Parameters.AddWithValue("@p2", Form1.mID);
                komut3.Parameters.AddWithValue("@p3", sayi);
                komut3.Parameters.AddWithValue("@p2", aliciNo);


                con.Open();

                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery();
                
                MessageBox.Show("Transfer or  Eft successful ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.mbakiye -= sayi;
                haraketkaydet.kaydet(Form1.mID,  sayi + "trasfer or eft given  ");
                haraketkaydet.kaydet(int.Parse(txtNo.Text), sayi + "trasfer or eft receipt ");


                con.Close();
                txtNo.Text = "";
                txtMiktar.Text = "";
            }
        }

          

                
        }
    }

