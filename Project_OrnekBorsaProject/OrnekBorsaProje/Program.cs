
using OrnekBorsaProje.entity;

class Program
{
    // BORSA ORNEK CONSOLE PROJE
    public static void Main(string[] args)
    {

		try
		{
            while (true)
            {
                Console.WriteLine("BORSA ISTANBUL UYGULAMASINA HOŞGELDİNİZ...");
                Console.WriteLine("********HİSSELER**********");
                Hisse hisse1 = new Hisse();
                hisse1.HisseEkle(25156, "SASA", 120.5);
                hisse1.HisseEkle(25155, "KONTR", 170.1);
                hisse1.HisseEkle(25154, "TUPRS", 550.7);
                Console.WriteLine("**************************");
                HalkaArz arz = new HalkaArz();
                //arz.HalkaArzKatil(25154, "TUPRS", 550.7, DateTime.Today, 8);
                Islemler islem = new Islemler();
                islem.HisseAl(25156, "SASA", 120.5, DateTime.Today, 8);


                Console.WriteLine("İşlem Yapmak İstiyorsanız E yazınız... ");
                string deger = Console.ReadLine();
                string trimDeger = deger.Trim();
                if (trimDeger == "E" || trimDeger == "e")
                {
                    Console.WriteLine("İŞLEMLER\n" +
                   "1) Üye Ol\n" +
                   "2) Kullanıcı Girişi\n");
                    Console.WriteLine("Lütfen İşlem türü seçin (1 veya 2)");
                    int girisSayi = Convert.ToInt32(Console.ReadLine());
                    if (girisSayi == 1)
                    {

                        Console.WriteLine("ID : ");
                        int kuid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("KULLANICI ADI : ");
                        string kuadi = Console.ReadLine();
                        Console.WriteLine("SİFRE : ");
                        string kusifre = Console.ReadLine();
                        Console.WriteLine("BAKIYE : ");
                        double kubakiye = Convert.ToDouble(Console.ReadLine());

                        bool kuloginmi = false;

                        Hesap hesap1 = new Hesap();
                        hesap1.kullaniciEkle(kuid, kuadi, kusifre, kubakiye, kuloginmi);
                        //**********************************
                        Console.WriteLine("Lütfen SAYI Gir : ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            Console.WriteLine("Hısse ID : ");
                            int hisse_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Hısse KODU : ");
                            string hisse_kodu = Console.ReadLine();
                            Console.WriteLine("Hısse FİYAT : ");
                            double hisse_fiyat = Convert.ToDouble(Console.ReadLine());

                            DateTime hisse_tarih = DateTime.Today;
                            Console.WriteLine("Hısse LOT ADET : ");
                            int hisse_lot = Convert.ToInt32(Console.ReadLine());

                            double yeniBakiye = kubakiye - (hisse_fiyat * hisse_lot); // Yeni Bakiye

                            if (yeniBakiye <= 0)
                            {
                                Console.WriteLine("Yeterli bakiye yoktur. Lütfen Hesabınıza Para Aktarınız...");
                            }
                            else
                            {
                                Islemler hisseAl = new Islemler();
                                hisseAl.HisseAl(hisse_id, hisse_kodu, hisse_fiyat, DateTime.Today, hisse_lot);
                                Console.WriteLine("Yeni Bakiyeniz : " + yeniBakiye + " TL");
                                break;
                            }


                        }



                    }
                    else if (girisSayi == 2)
                    {
                        Console.WriteLine("KULLANICI ADI : ");
                        string kuadi = Console.ReadLine();
                        Console.WriteLine("SİFRE : ");
                        string kusifre = Console.ReadLine();
                        Hesap hesap2 = new Hesap();
                        bool kaktifmi = true;
                        hesap2.kullaniciGiris(kuadi, kusifre, kaktifmi);

                        Console.WriteLine("Kullanıcı " + kuadi + " Hoşgeldinizz...");
                        Console.WriteLine("İŞLEMLER\n" +
                  "1) Hisse Al\n" +
                  "2) Hisse Sat\n" +
                  "3) Halka Arza Katıl" +
                  "4) Halka Arzı iptal et" +
                  "5) Bakiye Ekle" +
                  "6) Bakiye Çek" +
                  "7) Hisse Ekle" +
                  "8) Hisse Sil");
                        Console.WriteLine("Lütfen İşlem türü seçin (1,2,3,4,5,6,7,8)");
                        int girisSayim = Convert.ToInt32(Console.ReadLine());
                        if (girisSayim == 1)
                        {
                            Console.WriteLine("Hısse ID : ");
                            int hisse_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Hısse KODU : ");
                            string hisse_kodu = Console.ReadLine();
                            Console.WriteLine("Hısse FİYAT : ");
                            double hisse_fiyat = Convert.ToDouble(Console.ReadLine());

                            DateTime hisse_tarih = DateTime.Today;
                            Console.WriteLine("Hısse LOT ADET : ");
                            int hisse_lot = Convert.ToInt32(Console.ReadLine());
                            Islemler hisseAl = new Islemler();
                            hisseAl.HisseAl(hisse_id, hisse_kodu, hisse_fiyat, DateTime.Today, hisse_lot);
                            break;
                        }
                        else if (girisSayim == 2)
                        {

                        }
                        else if (girisSayim == 3)
                        {

                        }
                        else if (girisSayim == 4)
                        {

                        }
                        else if (girisSayim == 5)
                        {

                        }
                        else if (girisSayim == 6)
                        {

                        }
                        else if (girisSayim == 7)
                        {

                        }
                        else if (girisSayim == 8)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Geçersiz İfade Çıkış...");
                            break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("çıkış...");
                        break;
                    }





                }
                else
                {
                    Console.WriteLine(" Yanlış Değer Girişi, Çıkış Yapılıyorr...");
                    break;

                }


                Console.WriteLine(" ");
            }


            // Kullanıcı giriş yapmışsa hisse alma KALDI
            // hisseyi dizi olarak tutma HİSSE VARMI KONTROL
            // SWİTCH CASE İslemler

            Console.WriteLine();
            Console.ReadKey();



            /*
            en az 2 class farklı cs dosyalarında olacak
            iş kısmı bize ait borsa gibi

            en az 7 method - açıklama satırı 3 /// metodun üstüne 
            metod validasyon alanları oluştur istersen try catch yapamadığında konrol validasyonları boşuk  gibi
            change delete create add aktif mi

            */
        }
        catch (Exception)
		{

			throw;
		}
    }
}