using SOAData.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using SOACommons.Concretes;

namespace SOAData.Concretes
{
    public class KullaniciRepository : IRepository<Kullanici>, IDisposable
    {
        SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;

        public bool Delete(int id)
        {
           // _rowsAffected = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Kullanici where KullaniciID=@id", baglanti);
            komut.Parameters.AddWithValue("@id",id);
            komut.ExecuteNonQuery();
            baglanti.Close();
           
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public Kullanici IdSelect(int id)
        {
            _rowsAffected = 0;

            Kullanici Kullanici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[Ad] ,[Soyad],[Adres],[Telefon],[Email],[Sifre],[Rol]");
                query.Append("FROM [dbo].[Kullanici] ");
                query.Append("WHERE ");
                query.Append("[KullaniciID] = @id ");


                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Kullanici();
                                    entity.KullaniciID = reader.GetInt32(0);
                                    entity.Ad = reader.GetString(1);
                                    entity.Soyad = reader.GetString(2);
                                    entity.Adres = reader.GetString(3);
                                    entity.Telefon = reader.GetString(4);
                                    entity.Email = reader.GetString(5);     
                                    entity.Sifre = reader.GetString(6);
                                    entity.Rol = reader.GetString(7); 
                                    Kullanici = entity;
                                    break;
                                }
                            }
                        }
                    }
                }

                return Kullanici;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:ID ile Seçim Hatası", ex);
            }
        }

        public bool Insert(Kullanici entity)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into Kullanici(Ad,Soyad,Adres,Telefon,Email,Sifre,Rol) values (@Ad,@Soyad,@Adres,@Telefon,@Email,@Sifre,@Rol)";
            // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@Ad", entity.Ad);
            komut.Parameters.AddWithValue("@Soyad", entity.Soyad);
            komut.Parameters.AddWithValue("@Adres", entity.Adres);
            komut.Parameters.AddWithValue("@Telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@Email", entity.Email);
            komut.Parameters.AddWithValue("@Sifre", entity.Sifre);
            komut.Parameters.AddWithValue("@Rol", entity.Rol);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public IList<Kullanici> SelectAll()
        {
            IList<Kullanici> KuList = new List<Kullanici>();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT KullaniciID,Ad,Soyad,Adres,Telefon,Email,Sifre,Rol FROM Kullanici", baglanti);
            SqlDataReader reader = kmt.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    var entity = new Kullanici();
                    entity.KullaniciID = reader.GetInt32(0);
                    entity.Ad = reader.GetString(1);
                    entity.Soyad = reader.GetString(2);
                    entity.Adres = reader.GetString(3);
                    entity.Telefon = reader.GetString(4);
                    entity.Email = reader.GetString(5);
                    entity.Sifre = reader.GetString(6);
                    entity.Rol = reader.GetString(7);
                    KuList.Add(entity);
                    
                }               
            }
            baglanti.Close();
            return KuList;
        }

        public bool Update(Kullanici entity)
        {
            try
            {
                baglanti.Open(); 
                string kayit = "update Kullanici set Ad=@Ad,Soyad=@Soyad,Adres=@Adres,Telefon=@Telefon,Email=@Email,Sifre=@Sifre,Rol=@Rol  where KullaniciID=@KullaniciID";
                SqlCommand Komut = new SqlCommand(kayit, baglanti);
                Komut.Parameters.AddWithValue("@KullaniciID", entity.KullaniciID);
                Komut.Parameters.AddWithValue("@Ad", entity.Ad);
                Komut.Parameters.AddWithValue("@Soyad", entity.Soyad);
                Komut.Parameters.AddWithValue("@Adres", entity.Adres);
                Komut.Parameters.AddWithValue("@Telefon", entity.Telefon);
                Komut.Parameters.AddWithValue("@Email", entity.Email);
                Komut.Parameters.AddWithValue("@Sifre", entity.Sifre);
                Komut.Parameters.AddWithValue("@Rol", entity.Rol);

                Komut.ExecuteNonQuery();
                baglanti.Close();
              


            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciRepository:Güncelleme Hatası", ex);
            }


            return true;

        

        }
    }
}
