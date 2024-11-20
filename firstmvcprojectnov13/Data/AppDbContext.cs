using firstmvcprojectnov13.Models;
using Microsoft.EntityFrameworkCore;

namespace firstmvcprojectnov13.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)

        {
            // this is  kept empty .does need any code here
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
