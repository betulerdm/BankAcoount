using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200305030
{
    internal class haraketkaydet
    {

        public static void kaydet(int mId, string msj)
            {
            SqlConnection con = new SqlConnection("server=  LAPTOP-QP97ML1O\\SQLEXPRESS; initial catalog= bankamatik; integrated security = sspi ");

            SqlCommand komut = new SqlCommand("insert into movements(consumerID,process,date) values (@p1,@p2,@p3)", con);
            komut.Parameters.AddWithValue("@p1", mId);
            komut.Parameters.AddWithValue("@p2", msj);
            komut.Parameters.AddWithValue("@p3", DateTime.Now);

            con.Open();
            komut.ExecuteNonQuery();
            con.Close();




        }
}
}
