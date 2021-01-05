using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class MinivanDTO
    {
        public string VINNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public long Mileage { get; set; }
        public string TransmissionType { get; set; }
        public int SeatCapacity { get; set; }
        public decimal DailyRentalRate { get; set; }
        public string VehicleStatus { get; set; }
        public string VehicleAssignedAgency { get; set; }
        public string VehicleCurrentAgencyLocation { get; set; }
        public string VehicleType { get; set; }
        public bool DisabilityOption { get; set; }
    }
}
