using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soa_Form.ArabaServis;
using Araba = SOAModel.Araba;
using Soa_Form.SirketServis;
using Sirket = SOAModel.Sirket;

namespace Soa_Form
{
    public partial class Çalışan : Form
    {
        public Çalışan()
        {
            InitializeComponent();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
        public void temizle()
        {
            txtAnlikKilometre.Clear();
            txtBagajHacmi.Clear();
            txtEhliyetYasi.Clear();
            txtGunlukSinirKilometresi.Clear();
            txtKiralamaBedeli.Clear();
            txtKoltukSayisi.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtPlaka.Clear();
            txtSirket.Clear();
            txtYasSiniri.Clear();
            cmbAirbag.Text="";
            txtDurum.Clear();
            txtResim.Clear();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var ArabaSoapClient = new ArabaServisSoapClient())
                {
                    success = ArabaSoapClient.InsertAraba(new ArabaServis.Araba()
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
                        Resim=txtResim.Text,
                        Durum=txtDurum.Text
                       

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

        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ArabaSoapClient = new ArabaServisSoapClient())
                {
                    List<Araba> AraList = new List<Araba>();
                    foreach (var responsedAraba in ArabaSoapClient.SelectAllAraba().OrderBy(x => x.AracID).ToList())
                    {
                        Araba castedAraba = new Araba()
                        {
                            AracID = responsedAraba.AracID,
                            AracMarka = responsedAraba.AracMarka,
                            AracModel = responsedAraba.AracModel,
                            Plaka = responsedAraba.Plaka,
                            EhliyetYasi = responsedAraba.EhliyetYasi,
                            YasSiniri = responsedAraba.YasSiniri,
                            GunkukSinirKilometre = responsedAraba.GunkukSinirKilometre,
                            AnlikKilometre = responsedAraba.AnlikKilometre,
                            Airbag = responsedAraba.Airbag,
                            BagajHacmi = responsedAraba.BagajHacmi,
                            KoltukSayisi = responsedAraba.KoltukSayisi,
                            KiralamaBedeli = responsedAraba.KiralamaBedeli,
                            Sirket = responsedAraba.Sirket,
                            Resim = responsedAraba.Resim,
                            Durum = responsedAraba.Durum


                        };
                        AraList.Add(castedAraba);
                    }
                    dgvListele.DataSource = AraList.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
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
                    dataGridView1.DataSource = sirlist.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }

        private void Çalışan_Load(object sender, EventArgs e)
        {

        }
    }
}
