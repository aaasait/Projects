using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationVatanComputer
{
    // Price Class for filter with combobox
    public class Price
    {
        public int PriceId { get; set; }
        public string PriceName { get; set; }

        public Price() { }
        public Price(int priceId, string priceName)
        {
            PriceId = priceId;
            PriceName = priceName;
        }
    }
}
