using System.Collections.Generic;

namespace VV.DataObjects
{
    public class DealerDataObject
    {
        public int Id { get; set; }
        public string CompanyID { get; set; }
        public string DealerName { get; set; }
        public string VehicleBrands { get; set; }
        public List<LocationDataObject> Locations { get; set; }
        public List<User> Employees { get; set; }

        public List<InventoryVehicleDataObject> Inventory { get; set; }
        public List<ServiceAppointmentDataObject> ServiceAppointments { get; set; }
        public List<VehicleStatusDataObject> VehicleStatus { get; set; }
    }
}