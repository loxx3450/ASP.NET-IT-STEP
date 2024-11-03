using DriversManagement.API.DTOs;
using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IDriverService
{
    Task<ICollection<Driver>> GetAllDrivers(DriverFilter filter, int skip, int take);
}