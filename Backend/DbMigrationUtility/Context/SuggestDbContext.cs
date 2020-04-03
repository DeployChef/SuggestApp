using Microsoft.EntityFrameworkCore;
using SuggestService.Entities;

namespace DbMigrationUtility.Context
{
    public class SuggestDbContext : DbContext
    {
        public SuggestDbContext(DbContextOptions<SuggestDbContext> options)
            : base(options)
        {
        }

        public DbSet<SuggestEntity> Suggests { get; set; }
    }
}
