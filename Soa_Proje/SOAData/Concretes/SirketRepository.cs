using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using System.Data.SqlClient;
using System.Data;
using SOAData.Abstractions;
using SOACommons.Concretes;
using System.Data.Common;

namespace SOAData.Concretes
{
    public class SirketRepository : IRepository<Sirket>, IDisposable
    {
        SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;

        public bool Delete(int id)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Sirket where SirketID=@id", baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public Sirket IdSelect(int id)
        {
            _rowsAffected = 0;

            Sirket Sirket = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[SirketID],[SirketAd] ,[Sehir],[SirketAdres],[AracSayisi]");
                query.Append("FROM [dbo].[Sirket] ");
                query.Append("WHERE ");
                query.Append("[SirketID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [Sirket] can't be null. ");

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
                                    var entity = new Sirket();
                                    entity.SirketID = reader.GetInt32(0);
                                    entity.SirketAd = reader.GetString(1);
                                    entity.Sehir = reader.GetString(2);
                                    entity.SirketAdres = reader.GetString(3);
                                    entity.AracSayisi = reader.GetInt32(4);
                                    Sirket = entity;
                                    break;
                                }
                            }
                        }
                    }
                }

                return Sirket;
            }
            catch (Exception ex)
            {

                throw new Exception("SirketRepository:ID ile Seçim Hatası", ex);
            }
        }

        public bool Insert(Sirket entity)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            
            string kayit = "insert into Sirket(SirketAd,Sehir,SirketAdres,AracSayisi) values (@SirketAd,@Sehir,@SirketAdres,@AracSayisi)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@SirketAd", entity.SirketAd);
            komut.Parameters.AddWithValue("@Sehir", entity.Sehir);
            komut.Parameters.AddWithValue("@SirketAdres", entity.SirketAdres);
            komut.Parameters.AddWithValue("@AracSayisi", entity.AracSayisi);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public IList<Sirket> SelectAll()
        {
            IList<Sirket> sirlist = new List<Sirket>();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT SirketID,SirketAd,Sehir,SirketAdres,AracSayisi FROM Sirket", baglanti);
            SqlDataReader reader = kmt.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    var entity = new Sirket();
                    entity.SirketID = reader.GetInt32(0);
                    entity.SirketAd = reader.GetString(1);
                    entity.Sehir = reader.GetString(2);
                    entity.SirketAdres = reader.GetString(3);
                    entity.AracSayisi = reader.GetInt32(4);
                    
                    sirlist.Add(entity);

                }
            }
            baglanti.Close();
            return sirlist;
        }

        public bool Update(Sirket entity)
        {
            try
            {
                baglanti.Open();
                string kayit = "update Sirket set SirketAd=@SirketAd,Sehir=@Sehir,SirketAdres=@SirketAdres,AracSayisi=@AracSayisi  where SirketID=@SirketID";
                SqlCommand Komut = new SqlCommand(kayit, baglanti);
                Komut.Parameters.AddWithValue("@SirketAd", entity.SirketAd);
                Komut.Parameters.AddWithValue("@Sehir", entity.Sehir);
                Komut.Parameters.AddWithValue("@SirketAdres", entity.SirketAdres);
                Komut.Parameters.AddWithValue("@AracSayisi", entity.AracSayisi);
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

    

    
    

