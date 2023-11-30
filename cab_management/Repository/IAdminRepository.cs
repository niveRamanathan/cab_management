using cab_management.Model;

namespace cab_management.Repository
{
    public interface IAdminRepository
    {
        List<UserModel> ListAllUsers();
        void CreateDriver(string DriverName, byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn);
        List<TripInfoModel> AllDriverHistory ();
        List<DriverModel> ListOfDrivers();
    }
}
