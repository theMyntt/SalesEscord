using Microsoft.EntityFrameworkCore;
using SalesEscord.Models.Persistance;

namespace SalesEscord.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options) { }
    }
}
