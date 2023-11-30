using cab_management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cab_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : Controller
    {
        private readonly IAdminRepository _IAdminRepository;
        private readonly ILogger<AdminController> _Logger;
        private readonly IDriverRepository _DriverRepository;
        private readonly IUserRepository _UserRepository;

        public AdminController(IAdminRepository iAdminRepository, ILogger<AdminController> logger, IDriverRepository driverRepository, IUserRepository userRepository)
        {
            _IAdminRepository = iAdminRepository;
            _Logger = logger;
            _DriverRepository = driverRepository;
            _UserRepository = userRepository;
        }
        [HttpGet("ListOfUsers")]
        public IActionResult ListAllUsers()
        {
            var result = _IAdminRepository.ListAllUsers();
            return Ok(result);
        }

        [HttpGet("DriverHistory")]
        public IActionResult DriverHistory(long DriverId)
        {
            var result = _DriverRepository.DriverHistory(DriverId);
            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            var result = _UserRepository.CreateUser(Name, UserName, Password, PhoneNo, EmailId, City, State, Wallet, CreatedOn, CreatedBy);
            return Ok(result);
        }

        [HttpPost("CreateDriver")]
        public IActionResult CreateDriver(string DriverName, byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn)
        {
            _IAdminRepository.CreateDriver(DriverName,DriverPhoto, DriverUserName,DriverPassword,PhoneNo, JoinedOn,UpdatedOn);
            return Ok();
        }

        [HttpGet("UserHistory")]
        public IActionResult UserHistory(long CustId)
        {
            var test = _UserRepository.UserHistory(CustId);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }

        [HttpGet("GetAllDrivers'History")]
        public IActionResult AllDriverHistory()
        {
            var result = _IAdminRepository.AllDriverHistory();
            return Ok(result);
        }

        [HttpGet("ListOfDrivers")]
        public IActionResult ListOfDrivers()
        {
            var result = _IAdminRepository.ListOfDrivers();
            return Ok(result);
        }

        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(string Name)
        {
            var test = _UserRepository.GetUser(Name);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(string Name, string UserName, string Password, string PhoneNo, string EmailId, string City, string State, float Wallet, DateTime CreatedOn, string CreatedBy)
        {
            var test = _UserRepository.UpdateUser(Name, UserName, Password, PhoneNo, EmailId, City, State, Wallet, CreatedOn, CreatedBy);
            return Ok("User Info Updated");
        }
    }
}