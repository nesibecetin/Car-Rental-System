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

namespace Soa_Form_RestApi
{
    public partial class Admin : Form
    {
       /* public void metod()
        {
            Calisan frm1 = (Calisan)Application.OpenForms["Calisan"];

            frm1.SirketAdCek();

        }*/
        

        public static List<Kullanici> KuList{ get; set; }
        public static List<Sirket> sirlist { get; set; }

        Kullanici kullanici;
        Sirket sirket;
        public Admin()
        {
            sirlist = new List<Sirket>();
            KuList = new List<Kullanici>();
            InitializeComponent();
        }
        private void Admin_Load(object sender, EventArgs e)
        {

        }
        public async void Listele()
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
                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dgvListele.DataSource = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
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
                     Kullanici kullanici = new Kullanici()
                     {
                         Ad = txtCalisanAd.Text,
                         Soyad = txtCalisanSoyad.Text,
                         Adres = txtAdres.Text,
                         Telefon = txtTelefon.Text,
                         Email = txtEmail.Text,
                         Sifre = txtSifre.Text,
                         Rol = txtRol.Text
                     };  var serializedProduct = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                     var result = await client.PostAsync("api/Kullanici", content);
                     if (result.IsSuccessStatusCode)
                     {
                         success = true;
                     }
                 }
                 
                 var message = success ? "done" : "failed";
                 
                 MessageBox.Show("Operation " + message);
             }
             catch (Exception ex)
             {
                
                 MessageBox.Show("Error happened: " + ex.Message);
             }
            Listele();
        }
        private async void btnSil_Click(object sender, EventArgs e)
        {
            kullanici = await Delete(int.Parse(txtCalisanSil.Text));
            Listele();
        }
        private Kullanici XmlDeserializer(string xml)
        {
            // Deserialize the XML serialization.
            XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(ResponseContent<Kullanici>));
            // Setup a string reader
            using (StringReader sr = new StringReader(xml))
            {
                // Deserialize the content with the serializer
                var t = (ResponseContent<Kullanici>)ser.Deserialize(sr);
                // Get the Customer from the data and return it
                return t.Data.FirstOrDefault();
            }
        }
        private async Task<Kullanici> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64124/");
                   /* client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));*/

                    var result = await client.DeleteAsync("api/Kullanici/" + id);
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
        private async Task<Kullanici> SelectKullaniciByID(int ID)
        {
            try
            {
                // Create HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    // GET Request from the URI
                    using (var result = await client.GetAsync("api/Customer/" + ID))
                    {
                        // Check the result
                        if (result.IsSuccessStatusCode)
                        {
                            // Get the result string as XML
                            var value = result.Content.ReadAsStringAsync().Result;
                            // Deserialize it and return the Customer object we need
                            return XmlDeserializer(value);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer doesn't exists.");
            }

            // Return null if somethings went wrong without an exception
            return null;
        }
        private async void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private async void btnGetir_Click(object sender, EventArgs e)
        {

            try
            {
               
                using (var client = new HttpClient())
                {
                  
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                   
                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                       
                        if (result.IsSuccessStatusCode)
                        {
                           
                            var value = result.Content.ReadAsStringAsync().Result;

                           
                            KuList = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
                            foreach (var item in KuList.ToList())
                            {
                                if (item.KullaniciID == int.Parse(txtCalisanSil.Text))
                                {
                                    txtCalisanAd.Text = item.Ad;
                                    txtCalisanSoyad.Text = item.Soyad;
                                    txtAdres.Text = item.Adres;
                                    txtTelefon.Text = item.Telefon;
                                    txtEmail.Text = item.Email;
                                    txtSifre.Text = item.Sifre;
                                    txtRol.Text = item.Rol;
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
        private async void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                  
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    foreach (var item in KuList.ToList())
                    {
                        if (item.KullaniciID == int.Parse(txtCalisanSil.Text))
                        {
                            Kullanici kullanici = new Kullanici()
                            {
                                KullaniciID = item.KullaniciID,
                                Ad = txtCalisanAd.Text,
                                Soyad = txtCalisanSoyad.Text,
                                Adres = txtAdres.Text,
                                Telefon = txtTelefon.Text,
                                Email = txtEmail.Text,
                                Sifre = txtSifre.Text,
                                Rol = txtRol.Text
                            };
                        }
                    }
                    var serializedProduct = JsonConvert.SerializeObject(kullanici);

                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");

                    var result = await client.PutAsync("api/Kullanici/"+ txtCalisanSil.Text, content);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
            Listele();

        }
        private async void btnKaydetme_Click(object sender, EventArgs e)
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
                    
                    Sirket kullanici = new Sirket()
                    {
                        SirketAd = txtSirketAdi.Text,
                        Sehir = txtSehir.Text,
                        SirketAdres=txtAdress.Text,
                        AracSayisi=int.Parse(txtAracSayisi.Text)

                    };
                    var serializedProduct = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(" api/Sirket", content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
              
                var message = success ? "done" : "failed";
                MessageBox.Show("Operation " + message);
                ListeleSirket();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }
        public async void ListeleSirket()
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
                    using (var result = await client.GetAsync("api/Sirket"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dgvSirket.DataSource = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();
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
        private void btnListeleme_Click(object sender, EventArgs e)
        {
            ListeleSirket();
        }
        private Sirket XmlDeserializers(string xml)
        {
            
            XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(ResponseContent<Sirket>));
            
            using (StringReader sr = new StringReader(xml))
            {
                
                var t = (ResponseContent<Sirket>)ser.Deserialize(sr);
               
                return t.Data.FirstOrDefault();
            }
        }
        private async Task<Sirket> DeleteSirket(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    /* client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));*/

                    var result = await client.DeleteAsync("api/Sirket/" + id);

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
        private async void btnSilme_Click(object sender, EventArgs e)
        {
            sirket = await DeleteSirket(int.Parse(txtSirketIdSil.Text));
            ListeleSirket();

        }

        private async void btnSirketGetir_Click(object sender, EventArgs e)
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
                    using (var result = await client.GetAsync("api/Sirket"))
                    {
                        // Check the Result
                        if (result.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = result.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            sirlist = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();
                            foreach (var item in sirlist.ToList())
                            {
                                if (item.SirketID == int.Parse(txtSirketIdSil.Text))
                                {
                                    txtSirketAdi.Text = item.SirketAd;
                                    txtSehir.Text = item.Sehir;
                                    txtAdress.Text = item.SirketAdres;
                                    txtAracSayisi.Text = item.AracSayisi.ToString();
                                }
                            }
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

        private void btnGüncelleme_Click(object sender, EventArgs e)
        {

        }
    }
}
