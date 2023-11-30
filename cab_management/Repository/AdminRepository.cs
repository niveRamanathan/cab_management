using cab_management.Model;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace cab_management.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string connection;

        public AdminRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CabManagementSystem");
        }
        List<UserModel> IAdminRepository.ListAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Admin.SPS_List_Of_Users", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserModel user = new UserModel();
                    user.Name = Convert.ToString(reader["Name"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.PhoneNo = Convert.ToString(reader["PhNo"]);
                    user.EmailId = Convert.ToString(reader["Email_Id"]);
                    user.City = Convert.ToString(reader["City"]);
                    user.State = Convert.ToString(reader["State"]);
                    user.Wallet = Convert.ToInt64(reader["Wallet"]);
                    user.CreatedOn = Convert.ToDateTime(reader["Created_On"]);
                    user.CreatedBy = Convert.ToString(reader["Created_By"]);
                    users.Add(user);
                }
                reader.Close();
            }
            return users;
        }
        public void CreateDriver(string DriverName,byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Admin.SPI_CreateDriver", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DriverName", DriverName);
                cmd.Parameters.AddWithValue("@DriverPhoto", DriverPhoto);
                cmd.Parameters.AddWithValue("@DriverUserName", DriverUserName);
                cmd.Parameters.AddWithValue("@DriverPassword", DriverPassword);
                cmd.Parameters.AddWithValue("@PhNo", PhoneNo);
                cmd.Parameters.AddWithValue("@JoinedOn", JoinedOn);
                cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DriverModel driver = new DriverModel();
                    driver.DriverName = Convert.ToString(reader["DriverName"]);
                    driver.DriverPhoto = (byte[])reader["DriverPhoto"];
                    driver.DriverUserName = Convert.ToString(reader["DriverUserName"]);
                    driver.DriverPassword = Convert.ToString(reader["DriverPassword"]);
                    driver.PhoneNo = Convert.ToString(reader["PhNo"]);
                    driver.JoinedOn = Convert.ToDateTime(reader["JoinedOn"]);
                    driver.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                }
                reader.Close();
            }
        }
        public List<TripInfoModel> AllDriverHistory()
        {
            List<TripInfoModel> drivers = new List<TripInfoModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Admin.SPS_TripInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TripInfoModel cabs = new TripInfoModel();
                    cabs.BookingId = Convert.ToInt64(reader["Booking_Id"]);
                    cabs.CustId = Convert.ToInt64(reader["Cust_Id"]);
                    cabs.DriverName = Convert.ToString(reader["DriverName"]);
                    cabs.PickUp = Convert.ToString(reader["PickUp"]);
                    cabs.DropAt = Convert.ToString(reader["DropAt"]);
                    cabs.TotalKms = (float)Convert.ToDouble(reader["Total_Kms"]);
                    cabs.Price = (float)Convert.ToDouble(reader["Price"]);
                    cabs.PaymentMode = Convert.ToString(reader["Payment_Mode"]);
                    cabs.Status = Convert.ToString(reader["Status"]);
                    cabs.TripDate = Convert.ToDateTime(reader["Trip_Date"]);
                    drivers.Add(cabs);
                }
                reader.Close();
                return drivers;
            }
        }
        public List<DriverModel> ListOfDrivers()
        {
            List<DriverModel> drivers = new List<DriverModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPS_List_Of_Driver", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DriverModel driver = new DriverModel();
                    driver.DriverId = Convert.ToInt64(reader["DriverID"]);
                    driver.DriverName = Convert.ToString(reader["DriverName"]);
                    driver.DriverUserName = Convert.ToString(reader["DriverUserName"]);
                    driver.DriverPassword = Convert.ToString(reader["DriverPassword"]);
                    driver.PhoneNo = Convert.ToString(reader["PhNo"]);
                    driver.JoinedOn = Convert.ToDateTime(reader["JoinedOn"]);
                    driver.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                    drivers.Add(driver);
                }
                reader.Close();
                return drivers;
            }
        }

    }
}
