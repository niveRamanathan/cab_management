namespace cab_management.Model
{
    public class CabBookModel
    {
        public long BookingId { get; set; }
        public long CustId { get; set; }
        public long DriverId { get; set; }
        public long CarId { get; set; }
        public string FromAdd { get; set; }
        public string ToAdd { get; set; }
        public float TotalKms { get; set; }
        public float Price { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }
        public DateTime TripDate { get; set; }
    }
}
