﻿using AutoMapper;
using DriversManagement.API.DTOs;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriversManagement.API.Controllers;

[ApiController]
[Route("drivers")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;
    private readonly IMapper _mapper;

    public DriverController(IDriverService driverService, IMapper mapper)
    {
        _driverService = driverService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<DriverDTO>>> GetDrivers(
        [FromQuery] string? firstName,
        [FromQuery] string? lastName,
        [FromQuery] string? licenseNumber,
        [FromQuery] string? searchContext,
        [FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var filter = new DriverFilter
        {
            FirstName = firstName,
            LastName = lastName,
            LicenseNumber = licenseNumber,
            SearchContext = searchContext,
        };

        return Ok((await _driverService.GetAllDrivers(filter, skip, take)).Select(x => new DriverDTO()
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
        }));
    }

    [HttpPost]
    public ActionResult<Driver> AddDriver(DriverDTO driver)
    {
        var driv = _mapper.Map<Driver>(driver);

        return Ok();
    }

    [HttpGet("vehicles")]
    public async Task<ActionResult<ICollection<Vehicle>>> GetVehicles(
        [FromQuery] string? model,
        [FromQuery] int? year,
        [FromQuery] string? driverFirstName,
        [FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return Ok((await _driverService.FilterVehicles(model, year, driverFirstName, skip, take)));
    }
}