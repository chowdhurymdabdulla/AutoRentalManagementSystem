using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARMSBOLayer
{
    public class CreditCard:BusinessFoundationBase
    {
        //Private Instance Data:
        private string m_CardNumber;
        private string m_CustomerName;
        private string m_MerchantName;
        private string m_ExpDate;
        private string m_HouseStreetAddress;
        private string m_City;
        private string m_State;
        private string m_ZipCode;
        private string m_Country;
        private decimal m_CreditLimit;
        private bool m_ActivationStatus;

        //Public Instance Properties
        public string CardNumber
        {
            get { return m_CardNumber; }
            set { m_CardNumber = value;
                base.MarkDirty();
                }
        }

        public string CustomerName
        {
            get { return m_CustomerName; }
            set { m_CustomerName = value;
                base.MarkDirty();
                }
        }

        public string MarchantName
        {
            get { return m_MerchantName; }
            set {m_MerchantName = value;
                base.MarkDirty();
                 }
        }

        public string ExpDate
        {
            get { return m_ExpDate; }
            set { m_ExpDate = value;
                base.MarkDirty();
                }
        }

        public string HouseStreetAddress
        {
            get { return m_HouseStreetAddress; }
            set { m_HouseStreetAddress = value;
                base.MarkDirty();
                }
        }

        public string City
        { 
         get { return m_City; }
         set { m_City = value;
                base.MarkDirty();
              }
        }

        public string State
        {
            get { return m_State; }
            set { m_State = value;
                base.MarkDirty();
                 }
        }

        public string ZipCode
        {
            get { return m_ZipCode;}
            set { m_ZipCode = value;
                base.MarkDirty();
            }
        }

        public string Country
        {
            get { return m_Country; }
            set { m_Country = value;
                base.MarkDirty();
            }
        }

        public decimal CreditLimit
        {
            get { return m_CreditLimit; }
            set { m_CreditLimit = value;
                base.MarkDirty();
            }
        }

        public bool ActivationStatus
        {
            get { return m_ActivationStatus; }
        }

        //Public Constructor & Destructor methods:
        public CreditCard()
        {
            m_CardNumber = "";
            m_CustomerName = "";
            m_MerchantName = "";
            m_ExpDate = "00/00/0000";
            m_HouseStreetAddress = "";
            m_City = "";
            m_State = "";
            m_ZipCode = "";
            m_Country = "";
            m_CreditLimit = 0;
            m_ActivationStatus = true;

        }
        public CreditCard(string strCardNumber, string strCustomerName, string strMarchantName, 
            string strExpDate, string strHouseStreetAddress, string strCity, string strState, 
            string strZipCode, string strCountry, decimal strCreditLimit)
        {
            this.CardNumber = strCardNumber;
            this.CustomerName = strCustomerName;
            this.MarchantName = strMarchantName;
            this.ExpDate = strExpDate;
            this.HouseStreetAddress = strHouseStreetAddress;
            this.City = strCity;
            this.State = strState;
            this.ZipCode = strZipCode;
            this.Country = strCountry;
            this.CreditLimit = strCreditLimit;
            m_ActivationStatus = false;
        }

        ~CreditCard()
        {
            //Temporary code for testing:
        }

        //Public Instance method 
        public void Print()
        {
            try
            {
                
                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);
               
                objPrinterFile.WriteLine("Credit Card Information ............");
                objPrinterFile.WriteLine("Card Number = {0}", m_CardNumber);
                objPrinterFile.WriteLine("Customer Name = {0}", m_CustomerName);
                objPrinterFile.WriteLine("Merchant Name = {0}", m_MerchantName);
                objPrinterFile.WriteLine("Experation Date = {0}", m_ExpDate);
                objPrinterFile.WriteLine("House Street Address = {0}", m_HouseStreetAddress);
                objPrinterFile.WriteLine("City = {0}", m_City);
                objPrinterFile.WriteLine("State = {0}", m_State);
                objPrinterFile.WriteLine("Zip Code = {0}", m_ZipCode);
                objPrinterFile.WriteLine("Country = {0}", m_Country);
                objPrinterFile.WriteLine("Credit Limit = {0}", m_CreditLimit);
                objPrinterFile.WriteLine("Activation Status = {0}", m_ActivationStatus);
                objPrinterFile.WriteLine();
                objPrinterFile.WriteLine();
               
                objPrinterFile.Close();
            }
            catch  (System.Exception)
            {
                throw new System.Exception();
            }
            
        }
        public bool Activate()
        {
                m_ActivationStatus = true;
                base.MarkDirty();
                return m_ActivationStatus; 
        }

        public bool Deactivate()
        {
            m_ActivationStatus = false;
            base.MarkDirty();
            return m_ActivationStatus;
        }
        //public bool Load(string key)
        //{
        //    return DALayer_Load(key);
        //}
        //public bool Save()
        //{
        //    {
        //        //Only If this object is Marked for deletion & Old
        //        //then delete record, otherwise do nothing
        //        if (base.IsDeleted && !base.flagIsNew)
        //        {
        //            //Calls Local DALayer_Delete(Key)
        //            //to execute delete process
        //            return DALayer_Delete(this.Key);
        //        }
        //        else
        //        {
        //            if (base.flagIsDirty)
        //            {
        //                if (base.flagIsNew)
        //                {
        //                    //We are new so initiate insert opearation
        //                    //Calls Local DALayer_Insert() to start
        //                    //insert process
        //                    return DALayer_Insert();
        //                }
        //                else
        //                {
        //                    //We are OLD so initiate update operation
        //                    //Calls Local DALyaer_Update() to start
        //                    //update process
        //                    return DALyaer_Update();
        //                }//End of IF/ELSE
        //            }//End of IF
        //        }//End of IF/ELSE
        //    }
        //}
        //public bool Delete()
        //{
            
        //}
        //public bool DALayer_Load(string key)
        //{
           

        //}
        //note: page 71 compleated 


    }
}
