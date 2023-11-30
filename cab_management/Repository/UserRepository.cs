using cab_management.Model;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace cab_management.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connection;

        public UserRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CabManagementSystem");
        }
        public List<UserModel> GetUser(String Name)
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPS_UserInfo", conn);
                cmd.Parameters.AddWithValue("@Name", Name);
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
                return users;
            }

        }
        public List<UserModel> CreateUser (string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("User.SPI_CreateUser", conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@PhNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Email_Id", EmailId);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@Wallet", Wallet);
                cmd.Parameters.AddWithValue("@Created_On", CreatedOn);
                cmd.Parameters.AddWithValue("@Created_By", CreatedBy);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserModel user = new UserModel();
                    user.Name = Convert.ToString(reader["Name"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.UserName = Convert.ToString(reader["Password"]);
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
                return users;
            }
        }
        public List<UserModel> UpdateUser (string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPU_User", conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@PhNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Email_Id", EmailId);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@Wallet", Wallet);
                cmd.Parameters.AddWithValue("@Created_On", CreatedOn);
                cmd.Parameters.AddWithValue("@Created_By", CreatedBy);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
            }
            return users;
        }
        public List<CabBookModel> BookACab (long CustId, long DriverId, long CarId, string FromAdd, string ToAdd, float TotalKms, float Price, string PaymentMode, string Status, DateTime TripDate)
        {
            List<CabBookModel> cars = new List<CabBookModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("User.SPI_Book_A_Cab", conn);
                cmd.Parameters.AddWithValue("@Cust_Id", CustId);
                cmd.Parameters.AddWithValue("@Driver_Id", DriverId);
                cmd.Parameters.AddWithValue("@Car_Id", CarId);
                cmd.Parameters.AddWithValue("@FromAdd", FromAdd);
                cmd.Parameters.AddWithValue("@ToAdd", ToAdd);
                cmd.Parameters.AddWithValue("@Total_Kms", TotalKms);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Payment_Mode", PaymentMode);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Trip_Date", TripDate);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CabBookModel cab = new CabBookModel();
                    cab.BookingId = Convert.ToInt64(reader["BookingId"]);
                    cab.CustId = Convert.ToInt64(reader["CustId"]);
                    cab.DriverId = Convert.ToInt64(reader["DriverId"]);
                    cab.CarId = Convert.ToInt64(reader["CarId"]);
                    cab.FromAdd = Convert.ToString(reader["FromAdd"]);
                    cab.ToAdd = Convert.ToString(reader["ToAdd"]);
                    cab.Price = Convert.ToInt64(reader["Price"]);
                    cab.PaymentMode = Convert.ToString(reader["PaymentMode"]);
                    cab.Status = Convert.ToString(reader["Status"]);
                    cab.TripDate = Convert.ToDateTime(reader["TripDate"]);
                    cars.Add(cab);
                }
                reader.Close();
                return cars;
            }
        }
        public List<CabBookModel> UserHistory (long CustId)
        {
            List<CabBookModel> cars = new List<CabBookModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPS_UserHistory", conn);
                cmd.Parameters.AddWithValue("@Cust_Id", CustId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CabBookModel cab = new CabBookModel();
                    cab.BookingId = Convert.ToInt64(reader["Booking_Id"]);
                    cab.CustId = Convert.ToInt64(reader["Cust_Id"]);
                    cab.DriverId = Convert.ToInt64(reader["Driver_Id"]);
                    cab.CarId = Convert.ToInt64(reader["Car_Id"]);
                    cab.FromAdd = Convert.ToString(reader["FromAdd"]);
                    cab.ToAdd = Convert.ToString(reader["ToAdd"]);
                    cab.Price = Convert.ToInt64(reader["Price"]);
                    cab.PaymentMode = Convert.ToString(reader["Payment_Mode"]);
                    cab.Status = Convert.ToString(reader["Status"]);
                    cab.TripDate = Convert.ToDateTime(reader["Trip_Date"]);
                    cars.Add(cab);
                }
                reader.Close();
                return cars;

            }

        }
        
    }
}
