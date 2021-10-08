using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWResistenceSocialNetwork.Domain.Entities;

namespace SWResistenceSocialNetwork.Infrastructure.Data.Configurations
{
    public class RebelConfiguration : IEntityTypeConfiguration<Rebel>
    {
        public void Configure(EntityTypeBuilder<Rebel> builder)
        {
            builder.OwnsOne(rebel => rebel.Name);
            builder.OwnsOne(rebel => rebel.GeoLocation);
            builder.OwnsOne(rebel => rebel.Inventory).OwnsMany(inventory => inventory.Items, (items) => 
            {
                items.HasOne(e => e.Item).WithMany().HasForeignKey("ItemId");
            });
            //builder.OwnsMany(rebel => rebel.Inventory, (inventory) =>
            //{
            //    inventory.HasOne(e => e.Item).WithMany().HasForeignKey("ItemId");
            //});

            var navigation = builder.Metadata.FindNavigation(nameof(Rebel.Inventory));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
