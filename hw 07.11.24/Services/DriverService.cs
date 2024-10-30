using hw_07._11._24.Interfaces;
using hw_07._11._24.Models;
using Microsoft.EntityFrameworkCore;

namespace hw_07._11._24.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository _repository;

        public DriverService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers(int skip = 0, int take = 20)
        {
            return await _repository.GetAll<Driver>()
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
        }

        public async Task<Driver?> GetDriverById(int id)
        {
            return await _repository.GetAll<Driver>()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Driver?> GetDriverByLicenseNumber(string licenseNumber)
        {
            return await _repository.GetAll<Driver>()
                .FirstOrDefaultAsync(d => d.LicenseNumber == licenseNumber);
        }

        public async Task<Driver> CreateDriver(Driver driver)
        {
            return await _repository.Add(driver);
        }

        public async Task<Driver?> UpdateDriver(int id, Driver driver)
        {
            if (await GetDriverById(id) is null)
                return null;

            driver.Id = id;

            return await _repository.Update(driver);
        }

        public async Task<Driver?> UpdateDriverName(int id, string driverName)
        {
            var driver = await GetDriverById(id);

            if (driver is null)
                return null;

            driver.Name = driverName;

            await _repository.Update(driver);

            return driver;
        }

        public async Task DeleteDriver(int id)
        {
            var driver = await GetDriverById(id);

            if (driver is not null)
            {
                await _repository.Delete(driver);
            }
        }
    }
}
