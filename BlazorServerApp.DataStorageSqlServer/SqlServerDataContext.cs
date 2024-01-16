using BlazorServerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.DataStorageSqlServer
{
    public class SqlServerDataContext : DbContext
    {
        public SqlServerDataContext(DbContextOptions<SqlServerDataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
