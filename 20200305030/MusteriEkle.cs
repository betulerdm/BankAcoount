using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _20200305030
{
    public partial class MusteriEkle : Form
    {
        private SqlConnection con;
        private string connectionString = "server=LAPTOP-QP97ML1O\\SQLEXPRESS;initial catalog=bankamatik;integrated security=sspi";

        public MusteriEkle()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tcNo = txtTcNo.Text;
            string nameSurname = txtName.Text;
            string address = txtAdres.Text;
            string phoneNumber = txtPhone.Text;
            string password = txtTcNo.Text; // Şifre belirlemedim, tc no yazacak.
            string balance = txtH.Text;

            // Müşteri bilgilerini diziye ekle
            string[] musteriBilgileri = { tcNo, nameSurname, address, phoneNumber, password, balance };

            // SQL sorgusu için parametreler oluştur
            string[] parametreler = { "@p1", "@p2", "@p3", "@p4", "@p5", "@p6" };

            SqlCommand komut = new SqlCommand("INSERT INTO customers (tcNo, nameSurname, address, phoneNumber, password, balance, situation) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", con);

            // Parametreleri ekle
            for (int i = 0; i < musteriBilgileri.Length; i++)
            {
                komut.Parameters.AddWithValue(parametreler[i], musteriBilgileri[i]);
            }

            // Durumu direkt 1 olarak ekliyorum, array kullanarak değil
            komut.Parameters.AddWithValue("@p7", 1);

            con.Open();
            int sonuc = komut.ExecuteNonQuery();
            con.Close();

            if (sonuc == 1)
                MessageBox.Show("Yeni müşteri kaydedildi.");
            else
                MessageBox.Show("Yeni kayıt yapılamadı!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Temizle();
        }

        private void Temizle()
        {
            txtName.Text = "";
            txtTcNo.Text = "";
            txtAdres.Text = "";
            txtH.Text = "";
            txtPhone.Text = "";
        }
    }
}