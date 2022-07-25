using Microsoft.EntityFrameworkCore;

namespace Beginners_CRUD_EvtApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
