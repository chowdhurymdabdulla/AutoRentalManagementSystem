using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class CreditCardDTO
    {
        public string CardNumber { get; set; }
        public string CustomerName { get; set; }
        public string MerchantName { get; set; }
        public string ExpDate { get; set; }
        public string HouseStreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public decimal CreditLimit { get; set; }
        public bool ActivationStatus { get; set; }
    }
}
