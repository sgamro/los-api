using Microsoft.EntityFrameworkCore;

namespace los_api.DataAccess.LosDB
{
    public class LosDbContext : DbContext
    {
        public LosDbContext(DbContextOptions<LosDbContext> options): base(options)
        {
                
        }
        
        public DbSet<ProductEntity> Product { set; get; }
        public DbSet<StockEntity> Stock { set; get; }
    }
}