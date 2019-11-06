using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAModel
{
    public class Kiralama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        public int KiralamaID { get; set; }
        public string VerilisTarihi { get; set; }
        public string AlinisTarihi { get; set; }
        public int VerilisKilometre { get; set; }
        public int GidilenKilometre { get; set; }
        public int AlinanUcret { get; set; }
        public int Kullanici { get; set; }
        public int Arac { get; set; }


        public List<Kiralama> KiraList { get; set; }
    }
}
