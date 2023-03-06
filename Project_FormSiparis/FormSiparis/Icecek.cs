using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class Icecek
    {
        public int icecekId { get; set; }
        public string icecekName { get; set; }

        public double icecekPrice { get; set; }

        public Icecek(int icecek_Id, string icecek_Name, double icecek_Price)
        {
            this.icecekId = icecek_Id;
            this.icecekName = icecek_Name;
            this.icecekPrice = icecek_Price;
        }
    }
}
