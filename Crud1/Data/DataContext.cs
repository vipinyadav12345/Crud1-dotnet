using Microsoft.EntityFrameworkCore;

namespace Crud1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<Client> Clientss { get; set; }
    }
}
