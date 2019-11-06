using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAModel
{
    public class Kullanici : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Kullanici()
        {
            
        }

        public int KullaniciID { get; set; }
        public string Ad{ get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }

        public List<Kullanici> KuList { get; set; }
    }
}
