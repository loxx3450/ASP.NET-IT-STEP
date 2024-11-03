using DriversManagement.API.Interfaces;

namespace DriversManagement.API.Data;

public class Repository : IRepository
{
    private readonly DriversContext _context;

    public Repository(DriversContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }
}