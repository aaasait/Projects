using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class ListSiparisGet
    {
       public  List<ListSiparis> listSiparis = new List<ListSiparis>();


        // Sipariş Ekleme
        public async void Add(ListSiparis ls)
        {
            try
            {
               listSiparis.Add(ls);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Ad Soyad Getirme
        string username;
        public async Task<string> GetNameSurname()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    username = item.UserName;
                }
                return  await Task.FromResult(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Telefon Getirme
        string phone;
        public async Task<string> GetPhone()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    phone = item.Phone;
                }
                return await Task.FromResult(phone);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Addres Getirme
        string address;
        public async Task<string> GetAddress()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    address = item.Addres;
                }
                return await Task.FromResult(address);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Pizza Boy Adet Getirme
        string pizzaboyadet;
        public async Task<string> GetPizzaBoyAdet()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    pizzaboyadet = item.PizzaBoyAdet;
                }
                return await Task.FromResult(pizzaboyadet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Ekstra Getirme
        string ekstra;
        public async Task<string> GetEkstra()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    ekstra = item.Ekstra;
                }
                return await Task.FromResult(ekstra);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // İçecek Adet Getirme
        string icecekadet;
        public async Task<string> GetIcecekAdet()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    icecekadet = item.IcecekAdet;
                }
                return await Task.FromResult(icecekadet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Ücret Getirme
        string ucret;
        public async Task<string> GetUcret()
        {
            try
            {
                foreach (var item in listSiparis)
                {
                    ucret = item.Ucret;
                }
                return await Task.FromResult(ucret);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
