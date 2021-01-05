using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARMSBOLayer
{
    public class RetailCustomer : Person
    {
        //Private instance data
        private string m_DiscountCode;
        private string m_DiscountCodeDesc;
        private string m_EZPlusID;
        private int m_EZPlusEarnedPoints;

        public string DiscountCode
        {
            get { return m_DiscountCode; }
            set { m_DiscountCode = value;
                base.MarkDirty();
            }
        }

        public string DiscountCodeDesc
        {
            get { return m_DiscountCodeDesc;}
            set { m_DiscountCodeDesc = value;
                base.MarkDirty();
            }
        }

        public string EZPlusID
        {
            get { return m_EZPlusID; }
            set { m_EZPlusID = value;
                base.MarkDirty();
            }
        }

        public int EZPlusEarnedPoints
        {
            get { return m_EZPlusEarnedPoints; }
            set { m_EZPlusEarnedPoints = value;
                base.MarkDirty();
            }
        }
        public override string BirthDate
        {
            get { return base.BirthDate; }
            set
            {
                try
                {
                    if (base.Age >= 21)
                    {
                        base.BirthDate = value;
                        base.MarkDirty();
                    }
                    else throw new System.ArgumentException("Under Age Customer.Must be 21 and over to rent a car!");
                    
                }
                catch (System.Exception)
                {
                    throw new System.Exception();
                }
            }

        }
        public RetailCustomer()
        {
            m_DiscountCode = "";
            m_DiscountCodeDesc = "";
            m_EZPlusID = "";
            m_EZPlusEarnedPoints = 0;
        }

        public RetailCustomer(string strIDNumber, string strFirstName, string strLastName, string strBirthDate,
            string strHouseStreetAddress, string strCity, string strState, string strZipCode, string strCountry,
            string strPhone, string strEmail, string strDriverLicenseNumber, string strDriveLicenseExpDate,
            string strDiscountCode, string strDiscoundCodeDesc, string strEZPlusID, int strEZPlusEarnedPoints)
        {
            base.IDNumber = strIDNumber;
            base.FirstName = strFirstName;
            base.LastName = strLastName;
            this.BirthDate = strBirthDate;
            base.HouseStreetAddress = strHouseStreetAddress;
            base.City = strCity;
            base.State = strState;
            base.ZipCode = strZipCode;
            base.Country = strCountry;
            base.Phone = strPhone;
            base.Email = strEmail;
            base.DriverLicenseNumber = strDriveLicenseExpDate;
            base.DriveLicenseExpDate = strDriveLicenseExpDate;
            this.DiscountCode = strDiscountCode;
            this.DiscountCodeDesc = strDiscoundCodeDesc;
            this.EZPlusID = strEZPlusID;
            this.EZPlusEarnedPoints = strEZPlusEarnedPoints;
        }
        ~RetailCustomer()
        {

        }

        public override void Print()
        {
            try
            {

                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);

                objPrinterFile.WriteLine("Retail Customer Information ............");
                objPrinterFile.WriteLine("ID Number = {0}", base.IDNumber);
                objPrinterFile.WriteLine("First Name = {0}", base.FirstName);
                objPrinterFile.WriteLine("Last Name = {0}", base.LastName);
                objPrinterFile.WriteLine("Date of Birth = {0}", this.BirthDate);
                objPrinterFile.WriteLine("Age = {0}", base.Age);
                objPrinterFile.WriteLine("House Street Address = {0}", base.HouseStreetAddress);
                objPrinterFile.WriteLine("City = {0}", base.City);
                objPrinterFile.WriteLine("State = {0}", base.State);
                objPrinterFile.WriteLine("Zip Code = {0}", base.ZipCode);
                objPrinterFile.WriteLine("Country = {0}", base.Country);
                objPrinterFile.WriteLine("Phone Number = {0}", base.Phone);
                objPrinterFile.WriteLine("Email Address = {0}", base.Email);
                objPrinterFile.WriteLine("Dricing License Number = {0}", base.DriverLicenseNumber);
                objPrinterFile.WriteLine("Driving License Experation Date = {0}", base.DriveLicenseExpDate);
                objPrinterFile.WriteLine("Discount Code = {0}", this.DiscountCode);
                objPrinterFile.WriteLine("Discount Code Desc = {0}", this.DiscountCodeDesc);
                objPrinterFile.WriteLine("EZ Plus Number = {0}", this.EZPlusID);
                objPrinterFile.WriteLine("EZ Plus Points = {0}", this.EZPlusEarnedPoints);
                objPrinterFile.WriteLine();
                objPrinterFile.WriteLine();

                objPrinterFile.Close();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
        }
        


    }
}
