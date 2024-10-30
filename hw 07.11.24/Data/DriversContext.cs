using hw_07._11._24.Models;
using Microsoft.EntityFrameworkCore;

namespace hw_07._11._24.Data
{
    public class DriversContext : DbContext
    {
        public DriversContext(DbContextOptions<DriversContext> options) 
            : base(options)
        { }

        public DbSet<Driver> Drivers { get; set; }
    }
}
