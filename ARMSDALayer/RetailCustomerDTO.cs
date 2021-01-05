using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
   public class RetailCustomerDTO
    {
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; }
        public string HouseStreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DriverLicenseExpDate { get; set; }
        public char PersonType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountCodeDesc { get; set; }
        public string EZPlusID { get; set; }
        public int EZPlusEarnedPoints { get; set; }
        
    }
}
