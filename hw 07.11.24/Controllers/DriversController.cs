using AutoMapper;
using hw_07._11._24.DTOs;
using hw_07._11._24.Interfaces;
using hw_07._11._24.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hw_07._11._24.Controllers
{
    [ApiController]
    [Route("drivers")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriversController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            return Ok(await _driverService.GetAllDrivers(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriverById([FromRoute] int id)
        {
            var driver = await _driverService.GetDriverById(id);

            if (driver is null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpGet("search")]
        public async Task<ActionResult<Driver>> GetDriverByLicenseNumber([FromQuery] string licenseNumber)
        {
            var driver = await _driverService.GetDriverByLicenseNumber(licenseNumber);

            if (driver is null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> CreateDriver([FromBody] DriverDTO driverDTO)
        {
            var driver = _mapper.Map<Driver>(driverDTO);

            var createdDriver = await _driverService.CreateDriver(driver);

            return Created(Url.Action(nameof(GetDriverById), new { id = createdDriver.Id }), createdDriver);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Driver>> UpdateDriver([FromRoute] int id, [FromBody] DriverDTO driverDTO)
        {
            var driver = _mapper.Map<Driver>(driverDTO);

            var updatedDriver = await _driverService.UpdateDriver(id, driver);

            if (updatedDriver is null)
            {
                return BadRequest();
            }

            return Ok(updatedDriver);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Driver>> UpdateDriverName([FromRoute] int id, [FromBody] string licenseNumber)
        {
            if (string.IsNullOrEmpty(licenseNumber))
            {
                return BadRequest("License number cannot be null or empty");
            }

            var updatedDriver = await _driverService.UpdateDriverName(id, licenseNumber);

            if (updatedDriver is null)
            {
                return BadRequest();
            }

            return Ok(updatedDriver);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriver([FromRoute] int id)
        {
            await _driverService.DeleteDriver(id);

            return NoContent();
        }
    }
}
