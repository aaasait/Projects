using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekBorsaProje.entity
{
    class HalkaArz:Hisse
    {
        public DateTime BasvuruTarihi { get; set; }
        public int BasvuruLotAdet { get; set; }

        public void HalkaArzKatil(int hisseId, string hisseKodu, double hisseFiyat,DateTime tarih,int lot)
        {
            this.HisseID = hisseId;
            this.HisseKodu= hisseKodu;
            this.HisseFiyat= hisseFiyat;
            this.BasvuruTarihi = tarih;
            this.BasvuruLotAdet= lot;
            Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString()+" "+tarih.Date.ToString()+" "+lot.ToString());

        }
        // Sadece katıldıktan sonra iptal edilebilir
        public void HalkaArzIptal(int hisseId, string hisseKodu, double hisseFiyat, DateTime tarih, int lot)
        {
            this.HisseID = hisseId;
            this.HisseKodu = hisseKodu;
            this.HisseFiyat = hisseFiyat;
            this.BasvuruTarihi = tarih;
            this.BasvuruLotAdet = lot;
            Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString() + " " + tarih.Date.ToString() + " " + lot.ToString());

        }
    }
}
