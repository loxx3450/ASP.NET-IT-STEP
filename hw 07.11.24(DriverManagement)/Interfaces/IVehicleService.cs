using DriversManagement.API.Models;

namespace hw_07._11._24_DriverManagement_.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehicles(bool asc = true, int skip = 0, int take = 10);

        Task<Vehicle?> GetVehicle(int year, string model);
    }
}
