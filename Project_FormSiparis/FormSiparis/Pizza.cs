using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSiparis
{
    public class Pizza
    {
        public int pizzaId { get; set; }
        public string pizzaName { get; set; }

        public double PizzaPrice { get; set; }

        public Pizza(int pizza_Id, string pizza_Name, double pizza_Price)
        {
            this.pizzaId = pizza_Id;
            this.pizzaName = pizza_Name;
            PizzaPrice = pizza_Price;
        }
    }
}
