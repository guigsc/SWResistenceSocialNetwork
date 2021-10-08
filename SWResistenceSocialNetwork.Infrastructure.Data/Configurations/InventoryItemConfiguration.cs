using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWResistenceSocialNetwork.Domain.Entities;

namespace SWResistenceSocialNetwork.Infrastructure.Data.Configurations
{
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasOne(inventoryItem => inventoryItem.Item).WithOne();
        }
    }
}
