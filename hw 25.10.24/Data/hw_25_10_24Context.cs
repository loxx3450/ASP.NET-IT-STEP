using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hw_25._10._24.Models;

namespace hw_25._10._24.Data
{
    public class hw_25_10_24Context : DbContext
    {
        public hw_25_10_24Context (DbContextOptions<hw_25_10_24Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<hw_25._10._24.Models.Worker> Worker { get; set; } = default!;
    }
}
