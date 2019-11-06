using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAModel
{
    public class Araba : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public int AracID { get; set; }
        public string AracMarka { get; set; }
        public string AracModel { get; set; }
        public string Plaka { get; set; }
        public int EhliyetYasi { get; set; }
        public int YasSiniri { get; set; }
        public int GunkukSinirKilometre { get; set; }
        public int AnlikKilometre { get; set; }
        public string Airbag { get; set; }
        public int BagajHacmi { get; set; }
        public int KoltukSayisi { get; set; }
        public int KiralamaBedeli { get; set; }
        public int Sirket { get; set; }
        public string Resim { get; set; }
        public string Durum { get; set; }

        public List<Araba> AraList { get; set; }
    }
}
