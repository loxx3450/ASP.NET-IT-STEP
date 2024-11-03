namespace DriversManagement.API.Interfaces;

public interface IRepository
{
    IQueryable<T> GetAll<T>() where T : class;
}