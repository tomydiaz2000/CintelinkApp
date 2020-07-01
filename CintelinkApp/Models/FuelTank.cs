using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.Models
{
    public class FuelTank
    {
        public string TankId { get; set; }
        public string EquipmentId { get; set; }
        public string Tank { get; set; }
        public string Product{ get; set; }
        public double Cant { get; set; }
        public double Quantity { get; set; }
        public double Capacity { get; set; }
        public string Description{ get; set; }
        public string ProductName { get; set; }
        public string DescriptionTank { get; set; }
        public string Equipment { get; set; }
        public string Last_Quantity { get; set; }
        public string Last_Date { get; set; }
    }
}
