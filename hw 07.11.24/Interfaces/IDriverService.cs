using DriversManagement.API.Data;
using hw_07._11._24.Models;

namespace hw_07._11._24.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDrivers(int skip = 0, int take = 20);

        Task<Driver?> GetDriverById(int id);

        Task<Driver?> GetDriverByLicenseNumber(string licenseNumber);

        Task<Driver> CreateDriver(Driver driver);

        Task<Driver?> UpdateDriver(int id, Driver driver);

        Task<Driver?> UpdateDriverName(int id, string driverName);

        Task DeleteDriver(int id);
    }
}
