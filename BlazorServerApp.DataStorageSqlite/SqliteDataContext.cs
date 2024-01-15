using BlazorServerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.DataStorageSqlite
{
    public class SqliteDataContext : DbContext
    {
        public SqliteDataContext(DbContextOptions<SqliteDataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
