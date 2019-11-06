using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SOAModel;
using System.Data.Common;
using SOAData.Abstractions;
using SOACommons.Concretes;

namespace SOAData.Concretes
{
    public class KiralamaRepository : IRepository<Kiralama>, IDisposable
    {
        SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;

        public bool Insert(Kiralama entity)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into Kiralama(VerilisTarihi,AlinisTarihi,VerilisKilometre,GidilenKilometre,AlinanUcret,Kullanici,Arac)" +
                " values                       (@VerilisTarihi,@AlinisTarihi,@VerilisKilometre,@GidilenKilometre,@AlinanUcret,@Kullanici,@Arac)";
            // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@VerilisTarihi", entity.VerilisTarihi);
            komut.Parameters.AddWithValue("@AlinisTarihi", entity.AlinisTarihi);
            komut.Parameters.AddWithValue("@VerilisKilometre", entity.VerilisKilometre);
            komut.Parameters.AddWithValue("@GidilenKilometre", entity.GidilenKilometre);
            komut.Parameters.AddWithValue("@AlinanUcret", entity.AlinanUcret);
            komut.Parameters.AddWithValue("@Kullanici", entity.Kullanici);
            komut.Parameters.AddWithValue("@Arac", entity.Arac);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }
        
        public bool Delete(int id)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Kiralama where KiralamaID=@id", baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglanti.Close();

            return true;
        }
        
        public Kiralama IdSelect(int id)
        {
            _rowsAffected = 0;

            Kiralama Kiralama = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KiralamaID],[VerilisTarihi] ,[AlinisTarihi],[VerilisKilometre],[GidilenKilometre],[AlinanUcret],[Kullanici],[Arac]");
                query.Append("FROM [dbo].[Kiralama] ");
                query.Append("WHERE ");
                query.Append("[KiralamaID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [Kiralama] can't be null. ");

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
                                    var entity = new Kiralama();
                                    entity.KiralamaID = reader.GetInt32(0);
                                    entity.VerilisTarihi = reader.GetString(1);
                                    entity.AlinisTarihi = reader.GetString(2);
                                    entity.VerilisKilometre = reader.GetInt32(3);
                                    entity.GidilenKilometre = reader.GetInt32(4);
                                    entity.AlinanUcret = reader.GetInt32(5);
                                    entity.Kullanici = reader.GetInt32(6);
                                    entity.Arac = reader.GetInt32(7);
                                    Kiralama = entity;
                                    break;
                                }
                            }
                        }
                    }
                }

                return Kiralama;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:ID ile Seçim Hatası", ex);
            }
        }
        
        public bool Update(Kiralama entity)
        {
            try
            {
                baglanti.Open();
                string kayit = "UPDATE Kiralama SET VerilisTarihi=@VerilisTarihi,AlinisTarihi=@AlinisTarihi,VerilisKilometre=@VerilisKilometre,GidilenKilometre=@GidilenKilometre,AlinanUcret=@AlinanUcret,Kullanici=@Kullanici,Arac=@Arac  where KiralamaID=@KiralamaID";
                SqlCommand Komut = new SqlCommand(kayit, baglanti);
                Komut.Parameters.AddWithValue("@KiralamaID", entity.KiralamaID);
                Komut.Parameters.AddWithValue("@VerilisTarihi", entity.VerilisTarihi);
                Komut.Parameters.AddWithValue("@AlinisTarihi", entity.AlinisTarihi);
                Komut.Parameters.AddWithValue("@VerilisKilometre", entity.VerilisKilometre);
                Komut.Parameters.AddWithValue("@GidilenKilometre", entity.GidilenKilometre);
                Komut.Parameters.AddWithValue("@AlinanUcret", entity.AlinanUcret);
                Komut.Parameters.AddWithValue("@Kullanici", entity.Kullanici);
                Komut.Parameters.AddWithValue("@Arac", entity.Arac);

                Komut.ExecuteNonQuery();
                baglanti.Close();



            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciRepository:Güncelleme Hatası", ex);
            }


            return true;
        }
        
        public IList<Kiralama> SelectAll()
        {
            IList<Kiralama> KiraList = new List<Kiralama>();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT KiralamaID,VerilisTarihi,AlinisTarihi,VerilisKilometre,GidilenKilometre,AlinanUcret,Kullanici,Arac FROM Kiralama", baglanti);
            SqlDataReader reader = kmt.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    var entity = new Kiralama();
                    entity.KiralamaID = reader.GetInt32(0);
                    entity.VerilisTarihi = reader.GetString(1);
                    entity.AlinisTarihi = reader.GetString(2);
                    entity.VerilisKilometre = reader.GetInt32(3);
                    entity.GidilenKilometre = reader.GetInt32(4);
                    entity.AlinanUcret = reader.GetInt32(5);
                    entity.Kullanici = reader.GetInt32(6);
                    entity.Arac = reader.GetInt32(7);
                    KiraList.Add(entity);

                }
            }
            baglanti.Close();
            return KiraList;
        }
    }
}

