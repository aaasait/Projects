using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class ListSiparis
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Addres { get; set; }
        public string PizzaBoyAdet { get; set; }
        public string Ekstra { get; set; }
        public string IcecekAdet { get; set; }

        public string Ucret { get; set; }

        public ListSiparis(string _UserName,
            string _Phone,
            string _Addres,
            string _PizzaBoyAdet,
            string _Ekstra,
            string _IcecekAdet,
            string _Ucret) 
        { 
            this.UserName = _UserName;
            this.Phone = _Phone;
            this.Addres = _Addres;
            this.PizzaBoyAdet= _PizzaBoyAdet;
            this.Ekstra= _Ekstra;
            this.IcecekAdet= _IcecekAdet;
            this.Ucret= _Ucret; 

        
        }
    }
}
