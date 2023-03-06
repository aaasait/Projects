using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class GetComboboxList
    {
        public List<Pizza> pizzaList = new List<Pizza>();
        public List<Icecek> icecekList = new List<Icecek>();

        public async void GetPizzaList(Pizza p)
        {
            pizzaList.Add(p);
        }

        public void GetIcecekList(Icecek i)
        {
            icecekList.Add(i);
        }
    }
}
