using Microsoft.EntityFrameworkCore;
using MotivWebApp.Models;

namespace MotivWebApp.Data
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connects to SQLite DB
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("LocalDB"));
        }

        public DbSet<TableApplication> TableApplication { get; set; }
        public DbSet<TableMaritalStatus> TableMaritalStatus { get; set; }
        public DbSet<TableDrivingLicense> TableDrivingLicense { get; set; }
        public DbSet<TableAppInputRelations> TableAppInputRelations { get; set; }
        public DbSet<TableFinanceOptions> TableFinanceOptions { get; set; }
    }
}
