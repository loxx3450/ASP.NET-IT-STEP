using Microsoft.EntityFrameworkCore;

namespace hw_07._11._24.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() 
            where T : class;

        Task<T> Add<T>(T obj) 
            where T : class;

        Task<T> Update<T>(T obj) 
            where T : class;

        Task Delete<T>(T obj) 
            where T : class;
    }
}
