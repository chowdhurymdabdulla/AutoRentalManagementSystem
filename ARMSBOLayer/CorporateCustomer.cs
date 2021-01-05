using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace ARMSBOLayer
{
    public class CorporateCustomer : Person
    {
        //Private instance data
        private string m_CompanyID;
        private string m_CompanyName;
        private string m_ContactName;
        private string m_ContactPhone;
        private string m_ContactEmail;
        private decimal m_CompanyDailyRate;


        public string CompanyID
        {
            get { return m_CompanyID; }
            set { m_CompanyID = value;
                base.MarkDirty();
            }
        }

        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value;
                base.MarkDirty();
            }
        }

        public string ContactName
        {
            get { return m_ContactName; }
            set { m_ContactName = value;
                base.MarkDirty();
            }
        }

        public string ContactPhone
        {
            get { return m_ContactPhone; }
            set { m_ContactPhone = value;
                base.MarkDirty();
            }
        }

        public string ContactEmail
        {
            get { return m_ContactEmail; }
            set { m_ContactEmail = value;
                base.MarkDirty();
            }
        }

        public decimal CompanyDailyRate
        {
            get { return m_CompanyDailyRate; }
            set { m_CompanyDailyRate = value;
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

        public CorporateCustomer()
        {
            m_CompanyID = "";
            m_CompanyName = "";
            m_ContactName = "";
            m_ContactPhone = "";
            m_ContactEmail = "";
            m_CompanyDailyRate = 0;
        }

        public CorporateCustomer(string strIDNumber, string strFirstName, string strLastName, string strBirthDate,
            string strHouseStreetAddress, string strCity, string strState, string strZipCode, string strCountry,
            string strPhone, string strEmail, string strDriverLicenseNumber, string strDriveLicenseExpDate,
            string strCompanyID, string strCompanyName, string strContactName, string strContactPhone, string strContactEmail, 
            decimal strCompanyDailyRate)
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
            this.CompanyID = strCompanyID;
            this.CompanyName = strCompanyName;
            this.ContactName = strContactName;
            this.ContactPhone = strContactPhone;
            this.ContactEmail = strContactEmail;
            this.CompanyDailyRate = strCompanyDailyRate;
        }

        ~CorporateCustomer()
        {

        }
       
        public override void Print()
        {
            try
            {

                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);

                objPrinterFile.WriteLine("Corporate Customer Information ............");
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
                objPrinterFile.WriteLine("Company ID = {0}", this.CompanyID);
                objPrinterFile.WriteLine("Company Name = {0}", this.CompanyName);
                objPrinterFile.WriteLine("Contact Name = {0}", this.ContactName);
                objPrinterFile.WriteLine("Contact Phone Number = {0}", this.ContactPhone);
                objPrinterFile.WriteLine("Email Address = {0}", this.m_ContactEmail);
                objPrinterFile.WriteLine("Company Daily Rate = {0}", this.m_CompanyDailyRate);
                objPrinterFile.WriteLine();
                objPrinterFile.WriteLine();

                objPrinterFile.Close();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
            //page number 120 compleated
        }


    }


}
