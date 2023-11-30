using cab_management.Model;
using Microsoft.AspNetCore.Identity;

namespace cab_management.Repository
{
    public interface IUserRepository
    {
        List<UserModel> GetUser (string Name);
        List<UserModel> CreateUser (string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy);
        List<UserModel> UpdateUser (string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy);
        List<CabBookModel> BookACab (long CustId, long DriverId, long CarId, string FromAdd, string ToAdd, float TotalKms,  float Price, string PaymentMode, string Status, DateTime TripDate);
        List<CabBookModel> UserHistory(long CustId);
    }

}
