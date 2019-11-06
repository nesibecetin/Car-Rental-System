using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Soa_Form
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
        private void Giriş_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=desktop-uinl7ih;Initial Catalog=Soa;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Kullanici where Email='" + txtEMail.Text + "' and Sifre='" + txtSifre.Text + "' and Rol ='" +"admin"+"'", baglanti);
            SqlDataReader dr = komut.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
               
                        this.Hide();
                        Admin form2 = new Admin();

                        form2.Show();
               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Parolayı kontrol ediniz.");
            }
            baglanti.Close();
            
            
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Kullanici where Email='" + txtEMail.Text + "' and Sifre='" + txtSifre.Text + "' and Rol ='" + "calisan" + "'", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader(CommandBehavior.CloseConnection);

             if (dr1.Read())
            {

                this.Hide();
                Çalışan form3 = new Çalışan();

                form3.Show();

               

            }

            else
            {
                MessageBox.Show("Kullanıcı Adı ve Parolayı kontrol ediniz.");
            }
            baglanti.Close();
            txtEMail.Clear();
            txtSifre.Clear();
        }
    }
}
