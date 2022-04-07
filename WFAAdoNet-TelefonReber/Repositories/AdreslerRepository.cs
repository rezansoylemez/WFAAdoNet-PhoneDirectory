using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAAdoNet_TelefonReber.Entities;

namespace WFAAdoNet_TelefonReber.Repositories
{
    class AdreslerRepository
    {
        SqlConnection connection;
        public AdreslerRepository()
        {
            connection = new SqlConnection(Properties.Settings.Default.PersonelConnection);
        }
        public List<Adres> GetByKisiID(int kisiID)
        {
           
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select a.Il,a.Ilce,a.AdresDetay,a.AdresID From Adres a join KisilerVeAdresleri ka on a.AdresID=ka.AdresID where ka.KisiID=@KisiID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@KisiID", kisiID);

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Adres> adresList = new List<Adres>();
            while (reader.Read())
            {
                Adres adres= new Adres();
                adres.Il = reader[0].ToString();
                adres.Ilce = reader[1].ToString();
                adres.AdresDetay = reader[2].ToString();
                adres.AdresID = Convert.ToInt32(reader[3].ToString());
                adresList.Add(adres);
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return adresList;
        }
        public int AdressAdd(Adres adres)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Insert into Adres (Il,Ilce,AdresDetay) values(@Sehir,@Ilce,@Detay)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Sehir", adres.Il);
            command.Parameters.AddWithValue("@Ilce", adres.Ilce);
            command.Parameters.AddWithValue("@Detay", adres.AdresDetay);
            
            int affectedRows = command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows; 
        }
        public int GetAdresID(string gelenSehir)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select AdresID From Adres where Il=@Sehir";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Sehir", gelenSehir);

            int donenAdresID= Convert.ToInt32(command.ExecuteScalar());
            if (connection.State == ConnectionState.Open) connection.Close();
            return donenAdresID;
        }
        public int KisiVeADresleriAdd(int kisiID, int adresID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query1 = "Insert into KisilerVeAdresleri(KisiID,AdresID) values(@kisiID,@AdresID)";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@kisiID", kisiID);
            command1.Parameters.AddWithValue("@adresID", adresID);

            int affectedRows = command1.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        public int DeleteAdres(int adresID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "delete From Adres where AdresID=@pID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pID", adresID);
            int affectedRows = command.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        public int Update(Adres updateAdresID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Update Adres set Il=@Il,Ilce=@Ilce,AdresDetay=@detay where AdresID=@pID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Il", updateAdresID.Il);
            command.Parameters.AddWithValue("@Ilce", updateAdresID.Ilce);
            command.Parameters.AddWithValue("@detay", updateAdresID.AdresDetay);
            command.Parameters.AddWithValue("@pID", updateAdresID.AdresID);
            int affectedRows = command.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        public List<Adres> Search1(string ara,int kisilerID)
        {
            string query = "Select a.Il Il,a.Ilce Ilce,a.AdresID AdresID,a.AdresDetay from Adres a join KisilerVeADresleri ka on a.AdresID=ka.AdresID join Kisiler k on k.KisiID=ka.KisiID Where a.Il like '%'+@Aranan+'%' and k.KisiID =@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Aranan", ara);
            command.Parameters.AddWithValue("@ID", kisilerID);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Adres> searchedList = new List<Adres>();
            while (dataReader.Read())
            {
                Adres adres = new Adres();
                adres.Il = dataReader[0].ToString();
                adres.Ilce = dataReader[1].ToString();
                adres.AdresID = Convert.ToInt32(dataReader[2]);
                adres.AdresDetay = dataReader[3].ToString();
                searchedList.Add(adres);
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return searchedList;
        }
        public List<Adres> Search2(string ara,int KisilerID)
        {
            string query = "Select a.Il,a.Ilce,a.AdresID,a.AdresDetay  from Adres a join KisilerVeADresleri ka on a.AdresID=ka.AdresID join Kisiler k on k.KisiID=ka.KisiID Where a.Ilce like '%'+@Aranan+'%' and k.KisiID =@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Aranan", ara);
            command.Parameters.AddWithValue("@ID", KisilerID);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Adres> searchedList = new List<Adres>();
            while (dataReader.Read())
            {
                Adres adres = new Adres();
                adres.Il = dataReader[0].ToString();
                adres.Ilce = dataReader[1].ToString();
                adres.AdresID = Convert.ToInt32(dataReader[2]);
                adres.AdresDetay = dataReader[3].ToString();
                searchedList.Add(adres);
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return searchedList;
        }
        public List<Kisiler> ListBoxKisilerYazdir()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select Ad,KisiID From Kisiler";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Kisiler> kisilerList = new List<Kisiler>();
            while (reader.Read())
            {
                Kisiler kisiler = new Kisiler();
                kisiler.Ad = reader[0].ToString();
                kisiler.KisiID = Convert.ToInt32(reader[1]);
                kisilerList.Add(kisiler);
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return kisilerList;
        }
    }
}
