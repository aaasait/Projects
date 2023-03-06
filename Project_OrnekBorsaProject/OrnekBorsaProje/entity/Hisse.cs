using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekBorsaProje.entity
{
    class Hisse:Hesap
    {
        // Hesap  ve bakiye kontrolü
        public int HisseID { get; set; }
        public string HisseKodu { get; set; }
        public double HisseFiyat { get; set; }

        

        public void HisseEkle(int hisseId,string hisseKodu,double hisseFiyat)
        {
            try
            {
                this.HisseID = hisseId;
                this.HisseKodu = hisseKodu;
                this.HisseFiyat = hisseFiyat;
                Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString());
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public void HisseSil(int hisseId, string hisseKodu, double hisseFiyat)
        {
            try
            {
                this.HisseID = hisseId;
                this.HisseKodu = hisseKodu;
                this.HisseFiyat = hisseFiyat;
                Console.WriteLine(hisseId.ToString() + " " + hisseKodu.ToString() + " " + hisseFiyat.ToString());
            }
            catch (Exception)
            {

                throw;
            }

        }

    
        public override double bakiyeIlkDeger()
        {
            try
            {
                return this.Bakiye = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        // Para Yatırma
        public double BakiyeEkle(double bakiyetutar)
        {
            try
            {
                return Bakiye + bakiyetutar;
            }
            catch (Exception)
            {

                throw;
            }
           

        }
        // Para Çekme
        public double BakiyeCek(double bakiyetutar)
        {
            try
            {
                return Bakiye - bakiyetutar;
            }
            catch (Exception)
            {
                throw; 
            }
        }
    }
}
