using cab_management.Model;

namespace cab_management.Repository
{
    public interface IDriverRepository
    {
        List<DriverModel> UpdateDriver (string DriverName, byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn);
        List<CarListModel> UpdateCarList(long CarId, long DriverId, string CarName, float PricePKm);
        List<CabBookModel> DriverHistory(long DriverId); 
        List<CarListModel> GetListOfCars (long DriverId);
    }
}
