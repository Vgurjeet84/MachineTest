using Microsoft.EntityFrameworkCore;
using NudeSolutionMachineTest.Models;

namespace NudeSolutionMachineTest.Data
{
    public class MachineTestDbContext:DbContext
    {
        public MachineTestDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
