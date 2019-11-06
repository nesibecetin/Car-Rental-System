using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAModel
{
    public class Sirket : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Sirket()
        {
            //Transactions = new List<Transactions>();
        }

        public int SirketID { get; set; }
        public string SirketAd { get; set; }
        public string Sehir { get; set; }
        public string SirketAdres { get; set; }
        public int AracSayisi { get; set; }

        public List<Sirket> sirList { get; set; }
    }
}
