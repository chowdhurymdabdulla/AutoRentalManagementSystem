using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public abstract class Vehicle:BusinessFoundationBase
    {
        private string m_VINNumber;
        private string m_Make;
        private string m_Model;
        private int m_Year;
        private string m_Color;
        private string m_PlateNumber;
        private long m_Mileage;
        private string m_TransmissionType;
        private int m_SeatCapacity;
        private decimal m_DailyRentalRate;
        private string m_VehicleStatus;
        private string m_VehicleAssignedAgency;
        private string m_VehicleCurrentAgencyLocation;
        private string m_VehicleType;



        public string VINNumber
        {
            get { return m_VINNumber; }
            set { m_VINNumber = value;
                base.MarkDirty();
            }
        }

        public string Make
        {
            get { return m_Make; }
            set { m_Make = value;
                base.MarkDirty();
            }
        }

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value;
                base.MarkDirty();
            }
        }
        public int Year
        {
            get { return m_Year; }
            set { m_Year = value;
                base.MarkDirty();
            }
        }
        public string Color
        {
            get { return m_Color; }
            set { m_Color = value;
                base.MarkDirty();
            }
        }
        public string PlateNumber
        {
            get { return m_PlateNumber; }
            set { m_PlateNumber = value;
                base.MarkDirty();
            }
        }
        public long Mileage
        {
            get { return m_Mileage; }
            set { m_Mileage = value;
                base.MarkDirty();
            }
        }
        public string TransmissionType
        {
            get { return m_TransmissionType; }
            set { m_TransmissionType = value;
                base.MarkDirty();
            }
        }
        public int SeatCapacity
        {
            get { return m_SeatCapacity; }
            set { m_SeatCapacity = value;
                base.MarkDirty();
            }
        }
        public decimal DailyRentalRate
        {
            get { return m_DailyRentalRate; }
            set { m_DailyRentalRate = value;
                base.MarkDirty();
            }
        }
        public string VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value;
                base.MarkDirty();
            }
        }
        public string VehicleAssignedAgency
        {
            get { return m_VehicleAssignedAgency; }
            set { m_VehicleAssignedAgency = value;
                base.MarkDirty();
            }
        }
        public string VehicleCurrentAgencyLocation
        {
            get { return m_VehicleCurrentAgencyLocation; }
            set { m_VehicleCurrentAgencyLocation = value;
                base.MarkDirty();
            }
        }
        public string VehicleType
        {
            get { return m_VehicleType; }
            set
            {
                m_VehicleType = value;
                base.MarkDirty();
            }
        }


        public Vehicle()
        {
           m_VINNumber = "";
           m_Make = "";
           m_Model = "";
           m_Year = 0;
           m_Color = "";
           m_PlateNumber = "";
           m_Mileage = 0;
           m_TransmissionType = "";
           m_SeatCapacity = 0;
           m_DailyRentalRate = 0.0m;
           m_VehicleStatus = "";
           m_VehicleAssignedAgency = "";
           m_VehicleCurrentAgencyLocation = "";
            m_VehicleType = "";
        }

        public Vehicle(string strVINNumber, string strMake, string strModel, int strYear, string strColor, 
            string strPlateNumber, long strMileage, string strTransmissionType, int strSeatCapacity,
            decimal strDailyRentalRate, string strVehicleStatus, string strVehicleAssignedAgency, string strVehicleCurrentAgencyLocation, string strVehicleType)
        {
            this.VINNumber = strVINNumber;
            this.Make = strMake;
            this.Model = strModel;
            this.Year = strYear;
            this.Color = strColor;
            this.PlateNumber = strPlateNumber;
            this.Mileage = strMileage;
            this.TransmissionType = strTransmissionType;
            this.SeatCapacity = strSeatCapacity;
            this.DailyRentalRate = strDailyRentalRate;
            this.VehicleStatus = strVehicleStatus;
            this.VehicleAssignedAgency = strVehicleAssignedAgency;
            this.VehicleCurrentAgencyLocation = strVehicleCurrentAgencyLocation;
            this.VehicleType = strVehicleType;
        }

        ~Vehicle()
        {

        }


        public abstract void Print();
        //page number 132 compleated 
    }
}
