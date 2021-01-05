using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARMSBOLayer
{
    public class Minivan : Vehicle
    {
        private bool m_DisabilityOption;


        public bool DisabilityOption
        {
            get { return m_DisabilityOption; }
            set
            {
                m_DisabilityOption = value;
                base.MarkDirty();
            }
        }

        public Minivan()
        {
            m_DisabilityOption = false;
        }

        public Minivan(string strVINNumber, string strMake, string strModel, int strYear, string strColor,
            string strPlateNumber, long strMileage, string strTransmissionType, int strSeatCapacity,
            decimal strDailyRentalRate, string strVehicleStatus, string strVehicleAssignedAgency,
            string strVehicleCurrentAgencyLocation, bool strDisabilityOption)
        {
            base.VINNumber = strVINNumber;
            base.Make = strMake;
            base.Model = strModel;
            base.Year = strYear;
            base.Color = strColor;
            base.PlateNumber = strPlateNumber;
            base.Mileage = strMileage;
            base.TransmissionType = strTransmissionType;
            base.SeatCapacity = strSeatCapacity;
            base.DailyRentalRate = strDailyRentalRate;
            base.VehicleStatus = strVehicleStatus;
            base.VehicleAssignedAgency = strVehicleAssignedAgency;
            base.VehicleCurrentAgencyLocation = strVehicleCurrentAgencyLocation;
            this.DisabilityOption = strDisabilityOption;
        }

        ~Minivan()
        {

        }

        public override void Print()
        {
            try
            {

                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);

                objPrinterFile.WriteLine("Minivan Information ............");
                objPrinterFile.WriteLine("VIN Number = {0}", base.VINNumber);
                objPrinterFile.WriteLine("Maker Name = {0}", base.Make);
                objPrinterFile.WriteLine("Model Number = {0}", base.Model);
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
                objPrinterFile.WriteLine("Disability Option = {0}", this.DisabilityOption);
                objPrinterFile.WriteLine();
                objPrinterFile.WriteLine();

                objPrinterFile.Close();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
            //page number 160 compleated
        }
    }
}
