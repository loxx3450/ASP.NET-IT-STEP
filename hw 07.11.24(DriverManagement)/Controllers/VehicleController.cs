using AutoMapper;
using DriversManagement.API.Models;
using hw_07._11._24_DriverManagement_.DTOs;
using hw_07._11._24_DriverManagement_.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw_07._11._24_DriverManagement_.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetVehicles(
            [FromQuery] bool asc = true,
            [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var vehicles = await _vehicleService.GetVehicles(asc, skip, take);

            return Ok(_mapper.Map<IEnumerable<VehicleDTO>>(vehicles));
        }

        [HttpGet("search")]
        public async Task<ActionResult<VehicleDTO>> GetVehicle(
            [FromQuery] int year,
            [FromQuery] string model)
        {
            var vehicle = await _vehicleService.GetVehicle(year, model);

            if (vehicle is not null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleDTO>(vehicle));
        }
    }
}
