using System;
using System.Collections.Generic;
using System.Text;

namespace Sunfleet_Car_Terminal
{
    public class Vehicle
    {
        public string registrationNumber { get; set; }
        public string carBrand { get; set; }
        public string vehicleModel { get; set; }
        public string vehicleType { get; set; }
    }

    public class VehicleRepresentation : Vehicle
    {
        public string autoPilot { get; set; }

        // Class Constructor
        //public VehicleRepresentation(string reg, string brand, string model, string type, string autopilot)
        //{
        //    registrationNumber = reg;
        //    carBrand = brand;
        //    vehicleModel = model;
        //    vehicleType = type;
        //    autoPilot = autopilot;
        //}
    }

    public class TruckRepresentation : Vehicle
    {
        public string capacityCubic { get; set; }
        public string liftAvailability { get; set; }
    }
}
