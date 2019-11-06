using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAData.Abstractions;
using SOAModel;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SOACommons.Concretes;

namespace SOAData.Concretes
{
   public class ArabaRepository : IRepository<Araba>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;

        public bool Insert(Araba entity)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
            string kayit = "insert into Araba(AracMarka,AracModel,Plaka,EhliyetYasi,YasSiniri,GunkukSinirKilometre,AnlikKilometre,Airbag,BagajHacmi,KoltukSayisi,KiralamaBedeli,Sirket,Resim,Durum)" +
                " values (@AracMarka,@AracModel,@Plaka,@EhliyetYasi,@YasSiniri,@GunkukSinirKilometre,@AnlikKilometre,@Airbag,@BagajHacmi,@KoltukSayisi,@KiralamaBedeli,@Sirket,@Resim,@Durum)";
            // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@AracMarka", entity.AracMarka);
            komut.Parameters.AddWithValue("@AracModel", entity.AracModel);
            komut.Parameters.AddWithValue("@Plaka", entity.Plaka);
            komut.Parameters.AddWithValue("@EhliyetYasi", entity.EhliyetYasi);
            komut.Parameters.AddWithValue("@YasSiniri", entity.YasSiniri);
            komut.Parameters.AddWithValue("@GunkukSinirKilometre", entity.GunkukSinirKilometre);
            komut.Parameters.AddWithValue("@AnlikKilometre", entity.AnlikKilometre);
            komut.Parameters.AddWithValue("@Airbag", entity.Airbag);
            komut.Parameters.AddWithValue("@BagajHacmi", entity.BagajHacmi);
            komut.Parameters.AddWithValue("@KoltukSayisi", entity.KoltukSayisi);
            komut.Parameters.AddWithValue("@KiralamaBedeli", entity.KiralamaBedeli);
            komut.Parameters.AddWithValue("@Sirket", entity.Sirket);
            komut.Parameters.AddWithValue("@Resim", entity.Resim);
            komut.Parameters.AddWithValue("@Durum", entity.Durum);

            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public IList<Araba> SelectAll()
        {
            IList<Araba> AraList = new List<Araba>();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT AracID,AracMarka,AracModel,Plaka,EhliyetYasi,YasSiniri,GunkukSinirKilometre,AnlikKilometre,Airbag,BagajHacmi,KoltukSayisi,KiralamaBedeli,Sirket,Resim,Durum FROM Araba", baglanti);
            SqlDataReader reader = kmt.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    var entity = new Araba();
                    entity.AracID = reader.GetInt32(0);
                    entity.AracMarka = reader.GetString(1);
                    entity.AracModel = reader.GetString(2);
                    entity.Plaka = reader.GetString(3);
                    entity.EhliyetYasi= reader.GetInt32(4);
                    entity.YasSiniri = reader.GetInt32(5);
                    entity.GunkukSinirKilometre = reader.GetInt32(6);
                    entity.AnlikKilometre = reader.GetInt32(7);
                    entity.Airbag = reader.GetString(8);
                    entity.BagajHacmi = reader.GetInt32(9);
                    entity.KoltukSayisi = reader.GetInt32(10);
                    entity.KiralamaBedeli = reader.GetInt32(11);
                    entity.Sirket = reader.GetInt32(12);
                    entity.Resim = reader.GetString(13);
                    entity.Durum = reader.GetString(14);
                    AraList.Add(entity);

                }
            }
            baglanti.Close();
            return AraList;
            
        }

        public bool Update(Araba entity)
        {
           try
           {
                baglanti.Open();
                string kayit = "UPDATE Araba SET Ad=@Ad,Soyad=@Soyad,Adres=@Adres,Telefon=@Telefon,Email=@Email,Sifre=@Sifre,Rol=@Rol  where AracID=@AracID";
                SqlCommand Komut = new SqlCommand(kayit, baglanti);
                Komut.Parameters.AddWithValue("@AracID", entity.AracID);
                Komut.Parameters.AddWithValue("@AracMarka", entity.AracMarka);
                Komut.Parameters.AddWithValue("@AracModel", entity.AracModel);
                Komut.Parameters.AddWithValue("@Plaka", entity.Plaka);
                Komut.Parameters.AddWithValue("@EhliyetYasi", entity.EhliyetYasi);
                Komut.Parameters.AddWithValue("@YasSiniri", entity.YasSiniri);
                Komut.Parameters.AddWithValue("@GunkukSinirKilometre", entity.GunkukSinirKilometre);
                Komut.Parameters.AddWithValue("@AnlikKilometre", entity.AnlikKilometre);
                Komut.Parameters.AddWithValue("@Airbag", entity.Airbag);
                Komut.Parameters.AddWithValue("@BagajHacmi", entity.BagajHacmi);
                Komut.Parameters.AddWithValue("@KoltukSayisi", entity.KoltukSayisi);
                Komut.Parameters.AddWithValue("@KiralamaBedeli", entity.KiralamaBedeli);
                Komut.Parameters.AddWithValue("@Sirket", entity.Sirket);
                Komut.Parameters.AddWithValue("@Resim", entity.Resim);
                Komut.Parameters.AddWithValue("@Durum", entity.Durum);
                Komut.ExecuteNonQuery();
                baglanti.Close();
               
           }
           catch (Exception ex)
           {
               throw new Exception("KullaniciRepository:Güncelleme Hatası", ex);
           }


            return true;

        }

        public bool Delete(int id)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Araba where AracID=@id", baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public Araba IdSelect(int id)
        {
            _rowsAffected = 0;

            Araba Araba = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[AracID],[AracMarka] ,[AracModel],[Plaka],[EhliyetYasi],[YasSiniri],[GunkukSinirKilometre],[AnlikKilometre],[Airbag],[BagajHacmi] ,[KoltukSayisi],[KiralamaBedeli],[Sirket],[Resim],[Durum]");
                query.Append("FROM [dbo].[Kiralama] ");
                query.Append("WHERE ");
                query.Append("[AracID] = @id ");


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
                                    var entity = new Araba();
                                    entity.AracID = reader.GetInt32(0);
                                    entity.AracMarka = reader.GetString(1);
                                    entity.AracModel = reader.GetString(2);
                                    entity.Plaka = reader.GetString(3);
                                    entity.EhliyetYasi = reader.GetInt32(4);
                                    entity.YasSiniri = reader.GetInt32(5);
                                    entity.GunkukSinirKilometre = reader.GetInt32(6);
                                    entity.AnlikKilometre = reader.GetInt32(7);
                                    entity.Airbag = reader.GetString(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.KiralamaBedeli = reader.GetInt32(11);
                                    entity.Sirket = reader.GetInt32(12);
                                    entity.Resim = reader.GetString(13);
                                    entity.Durum = reader.GetString(14);
                                    Araba = entity;
                                    break;
                                }
                            }
                        }
                    }
                }

                return Araba;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:ID ile Seçim Hatası", ex);
            }

        }
    }
}
