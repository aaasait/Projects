using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class SiparisGet
    {

        List<Siparis> siparisList= new List<Siparis>();

        public void SiparisAdd(Siparis siparis)
        {
            siparisList.Add(siparis);
        }
    }
}
