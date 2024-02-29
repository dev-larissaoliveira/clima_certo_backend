using ClimaTempoWebAPI.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ClimaTempoWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}