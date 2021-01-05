using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARMSBOLayer
{
   public class SUV:Vehicle
    {
        private float m_TowingCapacity;
        private bool m_IsAWD;

        public float TowingCapacity
        {
            get { return m_TowingCapacity; }
            set
            {
                m_TowingCapacity = value;
                base.MarkDirty();
            }
        }

        public bool IsAWD
        {
            get { return m_IsAWD; }
            set
            {
                m_IsAWD = value;
                base.MarkDirty();
            }
        }

        public SUV()
        {
            m_TowingCapacity = 0.0f;
            m_IsAWD = false;
        }

        public SUV(string strVINNumber, string strMake, string strModel, int intYear, string strColor, 
            string strPlateNumber, long lngMileage, string strTransmissionType, int intSeatCapacity, 
            decimal decDailyRentalRate, string strVehicleAssignedAgency, string strVehicleCurrentAgencyLocation,
            float fltTowingCapacity, bool strIsAWD)
        {
            base.VINNumber = strVINNumber;
            base.Make = strMake;
            base.Model = strModel;
            base.Year = intYear;
            base.Color = strColor;
            base.PlateNumber = strPlateNumber;
            base.Mileage = lngMileage;
            base.TransmissionType = strTransmissionType;
            base.SeatCapacity = intSeatCapacity;
            base.DailyRentalRate = decDailyRentalRate;
            base.VehicleAssignedAgency = strVehicleAssignedAgency;
            base.VehicleCurrentAgencyLocation = strVehicleCurrentAgencyLocation;
            this.TowingCapacity = fltTowingCapacity;
            this.IsAWD = strIsAWD;
            

        }

        ~SUV()
        {

        }

        public override void Print()
        {
            try
            {
                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);

                objPrinterFile.WriteLine("SUV Information .........");
                objPrinterFile.WriteLine("VIN Number = {0}", base.VINNumber);
                objPrinterFile.WriteLine("Make = {0}", base.Make);
                objPrinterFile.WriteLine("Model = {0}", base.Model);
                objPrinterFile.WriteLine("Year = {0}", base.Year);
                objPrinterFile.WriteLine("Color = {0}", base.Color);
                objPrinterFile.WriteLine("Plate Number = {0}", base.PlateNumber);
                objPrinterFile.WriteLine("Mileage = {0}", base.Mileage);
                objPrinterFile.WriteLine("Transmission Type = {0}", base.TransmissionType);
                objPrinterFile.WriteLine("Seat Capacity = {0}", base.SeatCapacity);
                objPrinterFile.WriteLine("Daily Rental Rate = {0}", base.DailyRentalRate);
                objPrinterFile.WriteLine("Vehicle Status = {0}", base.VehicleStatus);
                objPrinterFile.WriteLine("Vehicle Assigned Agency = {0}", base.VehicleAssignedAgency);
                objPrinterFile.WriteLine("Vehicle Current Agency Location = {0}", base.VehicleCurrentAgencyLocation);
                objPrinterFile.WriteLine("Towing Capacity = {0}", m_TowingCapacity);
                objPrinterFile.WriteLine("Is AWD = {0}", m_IsAWD);
                objPrinterFile.WriteLine();
                objPrinterFile.WriteLine();
                objPrinterFile.Close();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
            //Page number 149 compleated 
        }
    }
}
