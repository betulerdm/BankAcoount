using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _20200305030
{
    public partial class müşteriara : Form
    {
        private class Customer
        {
            public int ID { get; set; }
            public string TcNo { get; set; }
            public string NameSurname { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public decimal Balance { get; set; }
        }

        private Customer[] customers = new Customer[100]; 
        private int customerCount = 0; 
        public müşteriara()
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
              
                Customer customer = new Customer
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    TcNo = dr["tcNo"].ToString(),
                    NameSurname = dr["nameSurname"].ToString(),
                    Address = dr["address"].ToString(),
                    PhoneNumber = dr["phoneNumber"].ToString(),
                    Balance = Convert.ToDecimal(dr["balance"])
                };

                customers[customerCount] = customer; 
                customerCount++; 

              
                txtId.Text = customer.ID.ToString();
                txtTcNo.Text = customer.TcNo;
                txtName.Text = customer.NameSurname;
                txtAdres.Text = customer.Address;
                txtPhone.Text = customer.PhoneNumber;
                txtH.Text = customer.Balance.ToString();
            }
            else
            {
                MessageBox.Show("Customer not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTextBoxes();
            }

            con.Close();
        }

        private void ClearTextBoxes()
        {
            txtId.Text = "";
            txtTcNo.Text = "";
            txtName.Text = "";
            txtAdres.Text = "";
            txtPhone.Text = "";
            txtH.Text = "";
        }
    }
}

