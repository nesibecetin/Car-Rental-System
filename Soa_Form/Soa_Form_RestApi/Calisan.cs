using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOAModel;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace Soa_Form_RestApi
{
    public partial class Calisan : Form
    {
        /*public void SirketAdCek()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM Sirket";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
               comboBox1.Items.Add(dr["SirketAd"]);
            }
            baglanti.Close();
        }*/

        public static List<Araba> AraList { get; set; }
        public static List<Kiralama> KiraList { get; set; }

        Araba araba;
        Kiralama kiralama;
        public Calisan()
        {
            AraList = new List<Araba>();
            KiraList = new List<Kiralama>();
            InitializeComponent();
        }
        
        private void Calisan_Load(object sender, EventArgs e)
        {
            //SirketAdCek();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    Araba araba = new Araba()
                    {
                        AracMarka = txtMarka.Text,
                        AracModel = txtModel.Text,
                        Plaka = txtPlaka.Text,
                        EhliyetYasi = int.Parse(txtEhliyetYasi.Text),
                        YasSiniri = int.Parse(txtYasSiniri.Text),
                        GunkukSinirKilometre = int.Parse(txtGunlukSinirKilometresi.Text),
                        AnlikKilometre = int.Parse(txtAnlikKilometre.Text),
                        Airbag = cmbAirbag.Text,
                        BagajHacmi = int.Parse(txtBagajHacmi.Text),
                        KoltukSayisi = int.Parse(txtKoltukSayisi.Text),
                        KiralamaBedeli = int.Parse(txtKiralamaBedeli.Text),
                        Sirket = int.Parse(txtSirket.Text),
                        Resim = txtResim.Text,
                        Durum = txtDurum.Text

                    };
                    var serializedProduct = JsonConvert.SerializeObject(araba);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Araba", content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }

                var message = success ? "done" : "failed";

                MessageBox.Show("Operation " + message);
                ListeleAraba();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error happened: " + ex.Message);
            }
            

        }
        public async void ListeleAraba()
        {
            try
            {
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Get Request from the URI
                    using (var result = await client.GetAsync("api/Araba"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dgvListele.DataSource = JsonConvert.DeserializeObject<ResponseContent<Araba>>(value).Data.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Inform user if an error occurs
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ListeleAraba();
        }

        private Araba XmlDeserializer(string xml)
        {
            // Deserialize the XML serialization.
            XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(ResponseContent<Araba>));
            // Setup a string reader
            using (StringReader sr = new StringReader(xml))
            {
                // Deserialize the content with the serializer
                var t = (ResponseContent<Araba>)ser.Deserialize(sr);
                // Get the Customer from the data and return it
                return t.Data.FirstOrDefault();
            }
        }
        private async Task<Araba> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    /* client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));*/

                    var result = await client.DeleteAsync("api/Araba/" + id);
                    MessageBox.Show("Başarılı");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer doesn't exists.");
            }

            // Return null if somethings went wrong without an exception
            return null;
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {

            araba = await Delete(int.Parse(txtAracIdSil.Text));
            ListeleAraba();
        }

        private async void btnArabaGetir_Click(object sender, EventArgs e)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    using (var result = await client.GetAsync("api/Araba"))
                    {

                        if (result.IsSuccessStatusCode)
                        {

                            var value = result.Content.ReadAsStringAsync().Result;


                            AraList = JsonConvert.DeserializeObject<ResponseContent<Araba>>(value).Data.ToList();
                            foreach (var item in AraList.ToList())
                            {
                                if (item.AracID == int.Parse(txtAracIdSil.Text))
                                {

                                    txtMarka.Text = item.AracMarka;
                                    txtModel.Text = item.AracModel;
                                    txtPlaka.Text = item.Plaka;
                                    txtEhliyetYasi.Text = item.EhliyetYasi.ToString();
                                    txtYasSiniri.Text = item.YasSiniri.ToString();
                                    txtGunlukSinirKilometresi.Text = item.GunkukSinirKilometre.ToString();
                                    txtAnlikKilometre.Text = item.AnlikKilometre.ToString();
                                    cmbAirbag.Text = item.Airbag.ToString();
                                    txtBagajHacmi.Text = item.BagajHacmi.ToString();
                                    txtKoltukSayisi.Text = item.KoltukSayisi.ToString();
                                    txtKiralamaBedeli.Text = item.KiralamaBedeli.ToString();
                                    txtSirket.Text = item.Sirket.ToString();
                                    txtResim.Text = item.Resim;
                                    txtDurum.Text = item.Durum;
                                  
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {

        }

        private async void btnKiralamaKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    Kiralama kiralama = new Kiralama()
                    {
                        VerilisTarihi = txtVerilisTarihi.Text,
                        AlinisTarihi=txtAlinisTarihi.Text,
                        VerilisKilometre=int.Parse(txtVerilisKilometre.Text),
                        GidilenKilometre=int.Parse(txtGidilenKilometre.Text),
                        AlinanUcret=int.Parse(txtAlinanUcret.Text),
                        Kullanici=int.Parse(txtKullanici.Text),
                        Arac=int.Parse(txtArac.Text)
                        

                    };
                    var serializedProduct = JsonConvert.SerializeObject(araba);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kiralama", content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }

                var message = success ? "done" : "failed";

                MessageBox.Show("Operation " + message);
                ListeleAraba();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
