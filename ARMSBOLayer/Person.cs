using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public abstract class Person:BusinessFoundationBase
    {
        //Private instance data
        private string m_IDNumber;
        private string m_FirstName;
        private string m_LastName;
        private string m_BirthDate;
        private int m_Age;
        private string m_HouseStreetAddress;
        private string m_City;
        private string m_State;
        private string m_ZipCode;
        private string m_Country;
        private string m_Phone;
        private string m_Email;
        private string m_DriverLicenseNumber;
        private string m_DriveLicenseExpDate;
        private char m_PersonType;
        private CreditCard m_objCreditCard;

        public string IDNumber
        {
            get { return m_IDNumber; }
            set { m_IDNumber = value;
                base.MarkDirty();
            }
        }
        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value;
                base.MarkDirty();
            }
        }
        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value;
                base.MarkDirty();
            }
        }
        public virtual string BirthDate
        {
            get { return m_BirthDate; }
            set
            {
                m_BirthDate = value;
                m_Age = CalculateAnyPersonAge(BirthDate);
                base.MarkDirty();
            }
        }
        //READ-ONLY Age property
        public int Age
        {
            get { return m_Age; }
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
            set
            {
                m_City = value;
                base.MarkDirty();
            }
        }
        public string State
        {
            get { return m_State; }
            set
            {
                m_State = value;
                base.MarkDirty();
            }
        }
        public string ZipCode
        {
            get { return m_ZipCode; }
            set
            {
                m_ZipCode = value;
                base.MarkDirty();
            }
        }
        public string Country
        {
            get { return m_Country; }
            set
            {
                m_Country = value;
                base.MarkDirty();
            }
        }
        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value;
                base.MarkDirty();
            }
        }
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value;
                base.MarkDirty();
            }
        }
        public string DriverLicenseNumber
        {
            get { return m_DriverLicenseNumber; }
            set
            {
                m_DriverLicenseNumber = value;
                base.MarkDirty();
            }
        }
        public string DriveLicenseExpDate
        {
            get { return m_DriveLicenseExpDate; }
            set
            {
                m_DriveLicenseExpDate = value;
                base.MarkDirty();
            }
        }

        public char PersonType
        {
            get { return m_PersonType; }
            set
            {
                m_PersonType = value;
                base.MarkDirty();
            }
        }
        public CreditCard objCreditCard
        {
            get { return m_objCreditCard; }
            set
            {
                m_objCreditCard = value;
                base.MarkDirty();
            }
        }

        public Person()
        {
            m_IDNumber = "";
            m_FirstName = "";
            m_LastName = "";
            m_BirthDate = "00/00/0000";
            m_Age = 0;
            m_HouseStreetAddress = "";
            m_City = "";
            m_State = "";
            m_ZipCode = "";
            m_Country = "";
            m_Phone = "";
            m_Email = "";
            m_DriverLicenseNumber = "";
            m_DriveLicenseExpDate = "";
            m_PersonType = '\0';
            m_objCreditCard = new CreditCard();
            
        }
       
        public Person(string strIDNumber, string strFirstName, string strLastName, string strBirthDate,
            string strHouseStreetAddress, string strCity, string strState, string strZipCode, string strCountry,
            string strPhone, string strEmail, string strDriverLicenseNumber, string strDriveLicenseExpDate, char strPersonType)
        {
            //Private data being set by PROPERTIES thus setting private data indirectly
            this.IDNumber = strIDNumber;
            this.FirstName = strFirstName;
            this.LastName = strLastName;
            this.BirthDate = strBirthDate;
            this.HouseStreetAddress = strHouseStreetAddress;
            this.City = strCity;
            this.State = strState;
            this.ZipCode = strZipCode;
            this.Country = strCountry;
            this.Phone = strPhone;
            this.Email = strEmail;
            this.DriverLicenseNumber = strDriveLicenseExpDate;
            this.DriveLicenseExpDate = strDriveLicenseExpDate;
            this.PersonType = strPersonType;
            m_objCreditCard = new CreditCard();

        }
        ~Person()
        {
            //Any action you want to do when object is being destroyed
            //Example - Code to clean up memory to make sure all resources
            //being used by an object are destroyed when object is destroyed
        }

        //Methods prints Employee's data to a File named Network_Printer.txt
        public abstract void Print();

        private static int CalculateAnyPersonAge(string strBirthDate)
        {
            //varible created to store the age
            int age;
            //Convert the birthdate string strBirthDate to DateTime object
            DateTime objBirthDate = Convert.ToDateTime(strBirthDate);
            //CALCULATE age, using .NET DateTime Structure to SUBTRACT the
            //current date year portion from Birthdate object Year portion
            age = DateTime.Now.Year - objBirthDate.Year;
            //Compare if today day of the year as a number is less than
            //the birthday day of the year as a number
            //If TRUE, subtract 1 day from the age, otherwise do nothing since
            //you already have the correct age
            //this calculation takes Leap Years into account within the DayOfYear property.
            if (DateTime.Now.DayOfYear < objBirthDate.DayOfYear)
                age = age - 1;
            return age;
        }
        //note: page number 98 compleated 


    }
}
