using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAAdoNet_TelefonReber.Entities;

namespace WFAAdoNet_TelefonReber.Repositories
{
    class KisiRepository
    {
        SqlConnection connection;
        public KisiRepository()
        {
            connection = new SqlConnection(Properties.Settings.Default.PersonelConnection);
        }
        
        /// <summary>
        /// Kisiler türündeki listeyi Form1deki listView1 e yazdıran method List Döndürür
        /// </summary>
        /// <returns></returns>
        public List<Kisiler> Get()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select KisiID,Ad,Soyad,Telefon from Kisiler";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Kisiler> kisilerList = new List<Kisiler>();
            while (reader.Read())
            {
                Kisiler kisiler = new Kisiler();
                kisiler.KisiID = Convert.ToInt32(reader[0]);
                kisiler.Ad = reader[1].ToString();
                kisiler.Soyad = reader[2].ToString();
                kisiler.Telefon = reader[3].ToString();

                kisilerList.Add(kisiler);//Kisiler türündeki kisileri kisilerListe değer atayıp attım
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return kisilerList;
        }
        /// <summary>
        /// string ara kelimesini alıp gosteren
        /// </summary>
        /// <param name="ara"></param>
        public List<Kisiler> Search(string ara)
        {
            string query = "Select KisiID,Ad,Soyad,Telefon from Kisiler Where Ad like '%'+@Ad+'%'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Ad", ara);

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);


            List<Kisiler> searchedList = new List<Kisiler>();
            while (dataReader.Read())
            {
                Kisiler kisiler = new Kisiler();
                kisiler.KisiID = Convert.ToInt32(dataReader[0]);
                kisiler.Ad = dataReader[1].ToString();
                kisiler.Soyad = dataReader[2].ToString();
                kisiler.Telefon = dataReader[3].ToString();

                searchedList.Add(kisiler);//Kisiler türündeki kisileri kisilerListe değer atayıp attım
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return searchedList;
        }
        /// <summary>
        /// Kişiler Listesini KisiID alarak getiren method. Bunu Kişi click edildiinde kullan ?
        /// </summary>
        /// <param name="kisiID"></param>
        /// <returns></returns>
        public Kisiler GetByID(int kisiID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select KisiID,Ad,Soyad,Telefon From Kisiler where KisiID=@pID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pID", kisiID);

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            Kisiler kisiler = null;
            while (reader.Read())
            {
                kisiler = new Kisiler();
                kisiler.KisiID = Convert.ToInt32(reader[0]);
                kisiler.Ad = reader[1].ToString();
                kisiler.Soyad =(reader[2].ToString());
                kisiler.Telefon = (reader[3].ToString());
               // kisiler.CategoryID = Convert.ToInt32(reader[4]);
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return kisiler; //Kisiler ve verilerini döndürüyor
        }
        /// <summary>
        /// KisiId alan AdresIDleri veren method 
        /// </summary>
        /// <param name="kisiID"></param>
        /// <returns></returns>
        public int GetbyKisiIDKisilerVeAdresleri(int kisiID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Select AdresID From KisilerVeAdresleri where KisiID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", kisiID);
            int affectedRows = command.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;

        }
        /// <summary>
        /// KisiID e göre KisilerVeAdreslerinden Komple olacak şekilde veri silen method
        /// </summary>
        /// <param name="kisiID"></param>
        /// <returns></returns>
        public int DeleteKisilerVeAdresleri(int kisiID) //Kontrol et 
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "delete From KisilerVeAdresleri where KisiID=@pID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pID", kisiID);

            int affectedRows = command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        public int DeleteKisiler(int kisiID)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "delete From Kisiler where KisiID=@pID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pID", kisiID);

            int affectedRows = command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        /// <summary>
        /// GetbyKisiIDKisilerVeAdresleri dan gelen adres ıdleri silen method
        /// </summary>
        /// <param name="adresID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Kisiler tipinde kisi verilerini textlerden alan ve ekleme yapan method
        /// </summary>
        /// <param name="kisi"></param>
        /// <returns></returns>
        public int Add(Kisiler kisi)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Insert into Kisiler (Ad,Soyad,Telefon) values(@Ad,@Soyad,@Telefon)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Ad", kisi.Ad);
            command.Parameters.AddWithValue("@Soyad", kisi.Soyad);
            command.Parameters.AddWithValue("@Telefon", kisi.Telefon);
            //command.Parameters.AddWithValue("@pCatID", kisi.CategoryID);

            int affectedRows = command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows; //Değişkenen atadığım affected olan değeri döndürüyor
        }
        /// <summary>
        /// KisiID bilgisini Form1de listviewden alan ve ona göre update yapan method consturoctor kullanımı kolyalaştırır
        /// </summary>
        /// <param name="updateKisi"></param>
        /// <returns></returns>
        public int Update(Kisiler updateKisi)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "Update Kisiler set Ad=@Ad,Soyad=@Soyad,Telefon=@Tel where KisiID=@pID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.addWithValue("@Ad", updateKisi.Ad);
            command.Parameters.AddWithValue("@Soyad", updateKisi.Soyad);
            command.Parameters.AddWithValue("@Tel", updateKisi.Telefon);          
            command.Parameters.AddWithValue("@pID", updateKisi.KisiID);

            int affectedRows = command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open) connection.Close();
            return affectedRows;
        }
        
    }
}
