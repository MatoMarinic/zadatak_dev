using Microsoft.EntityFrameworkCore;
using zadatak_dev.Models;

namespace zadatak_dev.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }
        public DbSet<Preference_Test> Preferences_Test { get; set; }
        public DbSet<User_Test> Users_Test { get; set; }
    }
}
