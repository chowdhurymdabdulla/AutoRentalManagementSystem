using ARMSBOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMSClientApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Minivan objRetailCustomer1 = new Minivan();
            //objRetailCustomer1.Print();

            //Minivan objRetailCustomer2 = new Minivan();


            //objRetailCustomer2.VINNumber = "abc123";
            //objRetailCustomer2.Make = "Toyota";
            //objRetailCustomer2.Model = "Camry";
            //objRetailCustomer2.Year= 2020;
            //objRetailCustomer2.Color = "Red";
            //objRetailCustomer2.PlateNumber = "T2020";
            //objRetailCustomer2.Mileage = 200;
            //objRetailCustomer2.TransmissionType = "Auto";
            //objRetailCustomer2.SeatCapacity = 7;
            //objRetailCustomer2.DailyRentalRate = 10;
            //objRetailCustomer2.VehicleStatus = "New";
            //objRetailCustomer2.VehicleAssignedAgency = "City Tech";
            //objRetailCustomer2.VehicleCurrentAgencyLocation = "New York";
            //objRetailCustomer2.DisabilityOption = false;
            //objRetailCustomer2.MaximumPayload = 700;
            //objRetailCustomer2.EZPlusNumber = "Abdullah";
            //objRetailCustomer2.EZPlusEarnedPoints = 10;

            //CargoVan cargoVan2 = new CargoVan("abc123", "Honda", "e7", 2018, "RED", "Tw342C", 32, 
            //    "Auto", 12, 64, "New", "Budger", "JFK", 20, 63332);
            //cargoVan2.Print();

            //objRetailCustomer2.Print();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            Minivan fordVan = new Minivan();
            fordVan.Print();
            fordVan.VINNumber = "SA23251";
            fordVan.Make = "Honda";
            fordVan.Model = "CRV";
            fordVan.Year = 2019;
            fordVan.Color = "Black";
            fordVan.PlateNumber = "NY12411";
            fordVan.Mileage = 2344;
            fordVan.TransmissionType = "Automatic";
            fordVan.SeatCapacity = 5;
            fordVan.DailyRentalRate = 23;
            fordVan.VehicleStatus = "New Like";
            fordVan.VehicleAssignedAgency = "Budget";
            fordVan.VehicleCurrentAgencyLocation = "JFk Arirport";
            fordVan.DisabilityOption = true;

            MinivanList testVanList = new MinivanList();
            testVanList.Add("SA23251", fordVan);
            fordVan.Print();
        }
    }
}
