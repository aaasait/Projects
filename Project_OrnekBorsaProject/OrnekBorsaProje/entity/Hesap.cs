using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekBorsaProje.entity
{
    class Hesap
    {
        public int Id { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }

        public double Bakiye { get; set; }

        public bool isLogin { get; set; }

        //Kullanici Login olmuşsa işlem yapabilir 
        // KULLANICI EKLE SİL GÜNCELLE

        public void kullaniciEkle(int id,string kadi,string sifre,double bakiyem,bool isLoginmi)
        {
            this.Id = id;
            this.KullaniciAd = kadi;
            this.Sifre = sifre;
            this.Bakiye= bakiyem;
            this.isLogin= isLoginmi;

            
            Console.WriteLine(id.ToString() + " " + kadi.ToString() + " " + sifre.ToString() + " " + bakiyem.ToString() + " " + isLoginmi.ToString());


        }
        public void kullaniciGiris(string kadim,string ksifre,bool kaktifmi)
        {
            this.KullaniciAd= kadim;
            this.Sifre= ksifre;
            this.isLogin= kaktifmi;
            Console.WriteLine(kadim.ToString() + " " + ksifre.ToString()+ " "+kaktifmi.ToString());

        }
        public virtual double bakiyeIlkDeger()
        {
            return Bakiye=0;
        }
   

    }
}
