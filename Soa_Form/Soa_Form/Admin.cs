using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soa_Form.SirketServis;
using Soa_Form.KullaniciServis;
using SOAModel;
using Sirket = SOAModel.Sirket;
using Kullanici = SOAModel.Kullanici;


namespace Soa_Form
{
    public partial class Admin : Form
    {
        public static List<Kullanici> KuList { get; set; }
        public Admin()
        {
            KuList = new List<Kullanici>();
            InitializeComponent();
        }
        public void temizle()
        {
            txtAdres.Clear();
            txtAdress.Clear();
            txtAracSayisi.Clear();
            txtCalisanAd.Clear();
            txtCalisanSoyad.Clear();
            txtEmail.Clear();
            txtSehir.Clear();
            txtSifre.Clear();
            txtSirketAdi.Clear();
            txtTelefon.Clear();

        }
        private void btnKaydetme_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var SirketSoapClient = new SirketServisSoapClient())
                {
                    success = SirketSoapClient.InsertSirket(new SirketServis.Sirket()
                    {
                        SirketAd = txtSirketAdi.Text,
                        Sehir = txtSehir.Text,
                        SirketAdres = txtAdress.Text,
                        AracSayisi = int.Parse(txtAracSayisi.Text)

                    });
                    MessageBox.Show("Kaydedildi.");
                    temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private void btnListeleme_Click(object sender, EventArgs e)
        {
            try
            {
                using (var SirketSoapClient = new SirketServisSoapClient())
                {
                    List<Sirket> sirlist = new List<Sirket>();
                    foreach (var responsedSirket in SirketSoapClient.SelectAllSirket().OrderBy(x => x.SirketID).ToList())
                    {
                        Sirket castedCustomer = new Sirket()
                        {
                            SirketID = responsedSirket.SirketID,
                            SirketAd = responsedSirket.SirketAd,
                            Sehir = responsedSirket.Sehir,
                            SirketAdres = responsedSirket.SirketAdres,
                            AracSayisi = responsedSirket.AracSayisi

                        };
                        sirlist.Add(castedCustomer);
                    }
                    dgvSirket.DataSource = sirlist.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                bool success;
                using (var customerSoapClient = new KullaniciServisSoapClient())
                {
                    success = customerSoapClient.InsertKullanici(new KullaniciServis.Kullanici()
                    {
                        Ad = txtCalisanAd.Text,
                        Soyad = txtCalisanSoyad.Text,
                        Adres = txtAdres.Text,
                        Telefon = txtTelefon.Text,
                        Email = txtEmail.Text,
                        Sifre = txtSifre.Text,
                        Rol = txtRol.Text
                    });
                    MessageBox.Show("Kaydedildi.");
                    temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }
        public void KullaniciListele()
        {
            KuList.Clear();
            try
            {
                using (var customerSoapClient = new KullaniciServisSoapClient())
                {

                    foreach (var responsedCustomer in customerSoapClient.SelectAllKullanici().OrderBy(x => x.KullaniciID).ToList())
                    {
                        Kullanici castedCustomer = new Kullanici()
                        {
                            KullaniciID = responsedCustomer.KullaniciID,
                            Ad = responsedCustomer.Ad,
                            Soyad = responsedCustomer.Soyad,
                            Adres = responsedCustomer.Adres,
                            Telefon = responsedCustomer.Telefon,
                            Email = responsedCustomer.Email,
                            Sifre = responsedCustomer.Sifre,
                            Rol = responsedCustomer.Rol
                        };
                        KuList.Add(castedCustomer);
                    }
                    dgvListele.DataSource = KuList.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }


        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            KullaniciListele();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
         
                using (var KullaniciSoapClient = new KullaniciServisSoapClient())
                {
                    foreach (var item in KuList.ToList() )
                    {                                      
                        if(item.Ad == txtCalisanSil.Text)
                        {
                            KullaniciSoapClient.DeleteKullanici(item.KullaniciID);
                            KuList.Remove(item);
                            MessageBox.Show("Silindi.");    
                        }
                        
                    }
                                     
                }
            
            KullaniciListele();
            txtCalisanSil.Clear();

        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var kullaniciServis = new KullaniciServisSoapClient())
                {
                    foreach (var item in KuList)
                    {
                        if (int.Parse(txtCalisanSil.Text) == item.KullaniciID)
                        {
                            var musteri = new KullaniciServis.Kullanici()
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

                            kullaniciServis.UpdateKullanici(musteri);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

        }
        /* private void txtCalisanSil_SelectedIndexChanged(object sender, EventArgs e)
{
foreach (var item in KuList)
{
if (item.Ad == txtCalisanSil.Text)
{
   txtCalisanAd.Text = item.Ad;
   txtCalisanSoyad.Text = item.Soyad;
   txtEmail.Text = item.Email;

 //  txt.Text = item.Adres;


 ///  txtMusteriTel.Text = item.Telefon;
  // txtSifre.Text = item.Sifre;
 //  dtMusteriEhliyetTarihi.Value = item.EhliyetYil.Date;
  // dtpMusteriDogumTarihi.Value = item.DogumTarihi.Date;

}
}
}*/
    }
}
