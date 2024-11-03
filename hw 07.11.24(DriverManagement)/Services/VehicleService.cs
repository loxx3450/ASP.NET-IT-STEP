using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using hw_07._11._24_DriverManagement_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hw_07._11._24_DriverManagement_.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository _repository;

        public VehicleService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Vehicle>> GetVehicles(bool asc = true, int skip = 0, int take = 10)
        {
            var vehicles = _repository.GetAll<Vehicle>()
                .AsNoTracking();

            if (asc)
            {
                vehicles = vehicles.OrderBy(x => x.Id);
            }
            else
            {
                vehicles = vehicles.OrderByDescending(x => x.Id);
            }

            return await vehicles
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
        }

        public async Task<Vehicle?> GetVehicle(int year, string model)
        {
            var vehicles = _repository.GetAll<Vehicle>()
                .AsNoTracking();

            Vehicle? vehicle = await vehicles.Where(v => v.Year == year && v.Model == model).FirstOrDefaultAsync();

            return vehicle;
        }
    }
}
