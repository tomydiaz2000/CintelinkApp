namespace CintelinkApp.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Description { get; set; }
        public string LastSync { get; set; }
        public string LastDate { get; set; }
        public string LastConnection { get; set; }
        public bool Online { get; set; }
        public string Sync { get; set; }
        public int IPAdress { get; set; }
    }
}
