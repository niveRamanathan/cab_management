using cab_management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cab_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverRepository _IDriverRepository;
        private readonly ILogger<DriverController> _Logger;

        public DriverController(IDriverRepository iDriverRepository, ILogger<DriverController> logger)
        {
            _IDriverRepository = iDriverRepository;
            _Logger = logger;
        }
        [HttpPut("UpdateDriver")]
        public IActionResult UpdateDriver(string DriverName, byte[] DriverPhoto, string DriverUserName, string DriverPassword, string PhoneNo, DateTime JoinedOn, DateTime UpdatedOn)
        {
            var test = _IDriverRepository.UpdateDriver(DriverName,DriverPhoto, DriverUserName, DriverPassword,PhoneNo,JoinedOn,UpdatedOn);
            return Ok("Driver info updated");
        }

        [HttpPut("UpdateDriver's_CarList")]
        public IActionResult UpdateCarList(long CarId, long DriverId, string CarName, float PricePKm)
        {
            var test = _IDriverRepository.UpdateCarList(CarId, DriverId, CarName, PricePKm);
            return Ok("Driver's Car list updated");
        }

        [HttpGet ("DriverHistory")]
        public IActionResult DriverHistory(long DriverId) 
        {
            var test = _IDriverRepository.DriverHistory(DriverId);
            if (test.Any())
            {
                _Logger.LogInformation("Items are fetched");
                return Ok(test);
            }
            _Logger.LogError("No items");
            return NoContent();
        }
        [HttpGet ("ListOfCars")]
        public IActionResult GetListOfCars(long DriverId)
        {
            var test = _IDriverRepository.GetListOfCars(DriverId);
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
