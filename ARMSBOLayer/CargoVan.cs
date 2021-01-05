using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARMSBOLayer
{
    public class CargoVan : Vehicle
    {
        private int m_CargoCapacity;
        private int m_MaximumPayload;



        public int CargoCapacity
        {
            get { return m_CargoCapacity; }
            set
            {
                m_CargoCapacity = value;
                base.MarkDirty();
            }
        }
        public int MaximumPayload
        {
            get { return m_MaximumPayload; }
            set
            {
                m_MaximumPayload = value;
                base.MarkDirty();
            }
        }


        public CargoVan()
        {
            m_CargoCapacity = 0;
            m_MaximumPayload = 0;
        }

        public CargoVan(string strVINNumber, string strMake, string strModel, int strYear, string strColor,
            string strPlateNumber, long strMileage, string strTransmissionType, int strSeatCapacity,
            decimal strDailyRentalRate, string strVehicleStatus, string strVehicleAssignedAgency,
            string strVehicleCurrentAgencyLocation, int strCargoCapacity, int strMaximumPayload)
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
            this.CargoCapacity = strCargoCapacity;
            this.MaximumPayload = strMaximumPayload;
        }

        ~CargoVan()
        {

        }

        public override void Print()
        {
            try
            {

                StreamWriter objPrinterFile = new StreamWriter("Network_Printer.txt", true);

                objPrinterFile.WriteLine("Cargo Van Information ............");
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
                objPrinterFile.WriteLine("Cargo Capacity = {0}", this.CargoCapacity);
                objPrinterFile.WriteLine("Maximum Payload = {0}", this.MaximumPayload);
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
