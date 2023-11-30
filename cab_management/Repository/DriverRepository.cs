using cab_management.Model;
using System.Data.SqlClient;

namespace cab_management.Repository
{
    public class DriverRepository : IDriverRepository 
    {
        private readonly string connection;
        public DriverRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CabManagementSystem");
        }
        public List<DriverModel> UpdateDriver (string DriverName, byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn)
        {
            List<DriverModel> driver = new List<DriverModel> ();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open ();
                SqlCommand cmd = new SqlCommand("Driver.SPU_Driver", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DriverName", DriverName);
                cmd.Parameters.AddWithValue("@DriverPhoto", DriverPhoto);
                cmd.Parameters.AddWithValue("@DriverUserName", DriverUserName);
                cmd.Parameters.AddWithValue("@DriverPassword", DriverPassword);
                cmd.Parameters.AddWithValue("@PhNo", PhoneNo);
                cmd.Parameters.AddWithValue("@JoinedOn", JoinedOn);
                cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
                SqlDataReader reader = cmd.ExecuteReader();
            }
            return driver;
        }
        public List<CarListModel> UpdateCarList (long CarId, long DriverId, string CarName, float PricePKm)
        {
            List<CarListModel> carList = new List<CarListModel> ();
            using (SqlConnection conn = new SqlConnection (connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Driver.SPU_CarList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_Id", CarId);
                cmd.Parameters.AddWithValue("@Driver_Id", DriverId);
                cmd.Parameters.AddWithValue("@Car_Name", CarName);
                cmd.Parameters.AddWithValue("@PricePKm", PricePKm);
                SqlDataReader reader = cmd.ExecuteReader();
            }
            return carList;
        }
        public List<CabBookModel> DriverHistory (long DriverId)
        {
            List<CabBookModel> driver = new List<CabBookModel> ();
            using (SqlConnection conn = new SqlConnection (connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Driver.SPS_DriverHistory", conn);
                cmd.Parameters.AddWithValue("@Driver_Id", DriverId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CabBookModel cabs = new CabBookModel ();
                    cabs.BookingId = Convert.ToInt64(reader["Booking_Id"]);
                    cabs.CustId = Convert.ToInt64(reader["Cust_Id"]);
                    cabs.DriverId = Convert.ToInt64(reader["Driver_Id"]);
                    cabs.CarId = Convert.ToInt64(reader["Car_Id"]);
                    cabs.FromAdd = Convert.ToString(reader["FromAdd"]);
                    cabs.ToAdd = Convert.ToString(reader["ToAdd"]);
                    cabs.TotalKms = (float)Convert.ToDouble(reader["Total_Kms"]);
                    cabs.Price = (float)Convert.ToDouble(reader["Price"]);
                    cabs.PaymentMode = Convert.ToString(reader["Payment_Mode"]);
                    cabs.Status = Convert.ToString(reader["Status"]);
                    cabs.TripDate = Convert.ToDateTime(reader["Trip_Date"]);
                    driver.Add(cabs);
                }
                reader.Close();
                return driver;
            }
        }
        public List<CarListModel> GetListOfCars (long DriverId)
        {
            List<CarListModel> cars = new List<CarListModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPS_ListOfCars", conn);
                cmd.Parameters.AddWithValue("@Driver_Id", DriverId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CarListModel car = new CarListModel();
                    car.CarId = Convert.ToInt64(reader["Car_Id"]);
                    car.CarName = Convert.ToString(reader["Car_Name"]);
                    car.PricePerKm = (float)Convert.ToDouble(reader["PricePKm"]);
                    cars.Add(car);
                }
                reader.Close();
                return cars;
            }

        }

    }
}
