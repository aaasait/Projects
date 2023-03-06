using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekBorsaProje.entity
{
    class Islemler : Hisse
    {
        public DateTime IslemTarihi { get; set; }
        public int IslemLotAdet { get; set; }

        public void HisseAl(int hisseId, string hisseKodu, double hisseFiyat, DateTime tarih, int lot)
        {
            this.HisseID = hisseId;
            this.HisseKodu = hisseKodu;
            this.HisseFiyat = hisseFiyat;
            this.IslemTarihi = tarih;
            this.IslemLotAdet = lot;
            Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString() + " " + tarih.Date.ToString() + " " + lot.ToString());

            
          
        }
        public void HisseSat(int hisseId, string hisseKodu, double hisseFiyat, DateTime tarih, int lot)
        {
                this.HisseID = hisseId;
                this.HisseKodu = hisseKodu;
                this.HisseFiyat = hisseFiyat;
                this.IslemTarihi = tarih;
                this.IslemLotAdet = lot;
                Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString() + " " + tarih.Date.ToString() + " " + lot.ToString());
             //   double yeniBakiye = bakiyeKontrol(1000.0) + (hisseFiyat * lot);
             //   Console.WriteLine("Yeni Bakiyeniz : " + yeniBakiye+" TL");
        }

    }
}

