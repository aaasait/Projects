using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class Siparis
    {
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int Pizza { get; set; }
        public int PizzaCount { get; set; }

        public int Icecek { get; set; }
        public int IcecekCount { get; set; }

        public bool Sucuk { get; set; }
        public bool Sosis { get; set; }
        public bool Mantar { get; set; }
        public bool Kaşar { get; set; }
        public bool Peynir { get; set; }
        public bool Sebze { get; set; }

        public Siparis(string _NameSurname,
            string _Phone,
            string _Address,
            int _Pizza,
            int _PizzaCount,
            int _Icecek,
            int _IcecekCount,
            bool _Sucuk,
            bool _Sosis,
            bool _Mantar,
            bool _Kaşar,
            bool _Peynir,
            bool _Sebze)
        {
            this.NameSurname= _NameSurname;
            this.Phone= _Phone;
            this.Address= _Address;
            this.Pizza= _Pizza;
            this.PizzaCount= _PizzaCount;
            this.Icecek= _Icecek;
            this.IcecekCount= _IcecekCount;
            this.Sucuk= _Sucuk;
            this.Sosis= _Sosis;
            this.Mantar= _Mantar;
            this.Kaşar = _Kaşar;
            this.Peynir= _Peynir;
            this.Sebze= _Sebze;


        }

    }
}
