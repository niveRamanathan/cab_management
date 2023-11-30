namespace cab_management.Model
{
    public class DriverModel
    {
        public long DriverId { get; set; }
        public string DriverName { get; set; }
        public byte[] DriverPhoto { get; set; }
        public string DriverUserName { get; set; }
        public string DriverPassword { get; set; }
        public string PhoneNo { get; set; }
        public DateTime JoinedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
