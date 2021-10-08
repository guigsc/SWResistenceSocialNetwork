using Microsoft.EntityFrameworkCore;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Infrastructure.Data.Configurations;

namespace SWResistenceSocialNetwork.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Resistance");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Rebel>().Ignore(rebel => rebel.Inventory);

            builder.ApplyConfiguration(new RebelConfiguration());
            //builder.ApplyConfiguration(new InventoryItemConfiguration());
        }

        public DbSet<Rebel> Rebels { get; set; }
        public DbSet<InventoryItem> RebelInventoryItems { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
