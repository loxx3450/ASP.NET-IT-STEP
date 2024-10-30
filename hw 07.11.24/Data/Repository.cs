using hw_07._11._24.Data;
using hw_07._11._24.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DriversManagement.API.Data
{
    public class Repository : IRepository
    {
        private readonly DriversContext _context;

        public Repository(DriversContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>()
                .AsNoTracking();
        }

        public async Task<T> Add<T>(T obj) where T : class
        {
            await _context.Set<T>()
                .AddAsync(obj);

            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<T> Update<T>(T obj) where T : class
        {
            _context.Set<T>().Update(obj);

            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task Delete<T>(T obj) where T : class
        {
            _context.Set<T>().Remove(obj);

            await _context.SaveChangesAsync();
        }
    }
}