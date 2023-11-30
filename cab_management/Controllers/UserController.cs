using cab_management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cab_management.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository _IUserRepository;
        private readonly ILogger<UserController> _Logger;
        private readonly IAdminRepository _AdminRepository;
        private readonly IDriverRepository _DriverRepository;

        public UserController(IUserRepository iUserRepository, ILogger<UserController> logger, IAdminRepository adminRepository, IDriverRepository driverRepository)
        {
            _IUserRepository = iUserRepository;
            _Logger = logger;
            _AdminRepository = adminRepository;
            _DriverRepository = driverRepository;
        }

        [HttpGet("GetUserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetUser(String Name)
        {
            var test = _IUserRepository.GetUser(Name);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            var test = _IUserRepository.CreateUser(Name, UserName, Password, PhoneNo, EmailId, City, State, Wallet, CreatedOn, CreatedBy);
            return Ok("User Created");
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            var test = _IUserRepository.UpdateUser(Name, UserName, Password, PhoneNo, EmailId, City, State, Wallet, CreatedOn, CreatedBy);
            return Ok("User Info Updated");
        }

        [HttpPost("BookACab")]
        public IActionResult BookACab(long CustId, long DriverId, long CarId, string FromAdd, string ToAdd, float TotalKms, float Price, string PaymentMode, string Status, DateTime TripDate)
        {
            var test = _IUserRepository.BookACab(CustId, DriverId, CarId, FromAdd, ToAdd, TotalKms, Price, PaymentMode, Status, TripDate);
            return Ok("Cab is Booked");
        }
        [HttpGet("UserHistory")]
        public IActionResult UserHistory(long CustId)
        {
            var test = _IUserRepository.UserHistory(CustId);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }
        [HttpGet("ListOfDrivers")]
        public IActionResult ListOfDrivers()
        {
            var result = _AdminRepository.ListOfDrivers();
            return Ok(result);
        }
        [HttpGet("ListOfCars")]
        public IActionResult GetListOfCars(long DriverId)
        {
            var test = _DriverRepository.GetListOfCars(DriverId);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }

    }
}
