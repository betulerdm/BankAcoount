using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _20200305030
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");
        public static string adSoyad = "";
        public static int mID = 0;
        public static float mbakiye = 0.0f;



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text;
            string password = textBox2.Text;
            bool sonuc = false;
           
            if (radioButton1.Checked)
            {
                if (kAdi=="dilara" && password == "123")
                {
                    Yetkiliişlem yi = new Yetkiliişlem();
                    yi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Entry!!!!!");

                }
       
            }
        
        else
            {
                con.Open();
                SqlCommand komut = new SqlCommand("select * from customers where tcNo=@p1 and password=@p2", con);
                komut.Parameters.AddWithValue("@p1", kAdi);
                komut.Parameters.AddWithValue("@p2", password);
                
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    adSoyad = dr["nameSurname"].ToString();
                    mID = int.Parse(dr["ID"].ToString());
                    mbakiye = float.Parse(dr["balance"].ToString());
                    sonuc = true;

                }

                con.Close();

                if (sonuc)
                {
                    sonuc = false;
                    müşteriişlem mi = new müşteriişlem();
                    mi.Show();

                }
                else
                {
                    MessageBox.Show("Incorrect Entry!!!!!");
                  
                }

              
                
            }
            textBox1.Text = "";
            textBox2.Text = "";


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            yeniŞifreÜret su = new yeniŞifreÜret();
            su.Show();
        }
    }
}
