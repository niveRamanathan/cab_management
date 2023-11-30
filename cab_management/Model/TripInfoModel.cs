namespace cab_management.Model
{
    public class TripInfoModel
    {
        public long BookingId { get; set; } 
        public long CustId { get; set; }
        public string DriverName { get; set; }
        public string PickUp {  get; set; }
        public string DropAt { get; set; }
        public float TotalKms { get; set; }
        public float Price { get; set; }
        public string PaymentMode {  get; set; }
        public string Status { get; set; }
        public DateTime TripDate { get; set; }

    }
}
