using DriversManagement.API.DTOs;
using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IDriverService
{
    Task<ICollection<Driver>> GetAllDrivers(DriverFilter filter, int skip, int take);

    Task<ICollection<Vehicle>> FilterVehicles(string? model, int? year, string? driverFirstName, int skip = 0, int take = 20);
}