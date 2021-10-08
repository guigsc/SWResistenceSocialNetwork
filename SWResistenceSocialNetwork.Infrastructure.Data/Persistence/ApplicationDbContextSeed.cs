using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            var itemRepository = serviceProvider.GetRequiredService<IItemRepository>();
            var rebelRepository = serviceProvider.GetRequiredService<IRebelRepository>();

            await AddItems(itemRepository);

            await AddRebels(rebelRepository);
        }

        private static async Task AddRebels(IRebelRepository rebelRepository)
        {
            var rebels = new List<Rebel>
            {
                new Rebel(
                name: new Name("Kodced", "Newtcur"),
                age: 18,
                gender: "Female",
                geoLocation: new GeoLocation(10.02314561, 23.15234551, name: "Uldur"),
                items: new List<InventoryItem>
                {
                    new(3, 4),
                    new(4, 3)
                }),

                new Rebel(
                name: new Name("Landtomm", "Cartdor"),
                age: 25,
                gender: "Male",
                geoLocation: new GeoLocation(23.15234551, 10.02314561, name: "Rasan"),
                items: new List<InventoryItem>
                {
                    new(1, 3),
                    new(2, 4)
                }),

                new Rebel(
                name: new Name("Janiash", "Estwas"),
                age: 18,
                gender: "Female",
                geoLocation: new GeoLocation(10.02314561, 23.15234551, name: "Ono"),
                items: new List<InventoryItem>
                {
                    new(3, 10),
                    new(4, 9),
                    new(1, 7),
                    new(2, 8)
                }),

                new Rebel(
                name: new Name("Bryanik", "Aubetit"),
                age: 25,
                gender: "Male",
                geoLocation: new GeoLocation(23.15234551, 10.02314561, name: "Poshe"),
                items: new List<InventoryItem>
                {
                    new(1, 1),
                    new(2, 1),
                    new(3, 1),
                    new(4, 1)
                })
            };

            foreach (var rebel in rebels)
                await rebelRepository.AddAsync(rebel);
        }

        private static async Task AddItems(IItemRepository itemRepository)
        {
            var items = new List<Item>
            {
                new Item("Arma", 4),
                new Item("Munição", 3),
                new Item("Água", 2),
                new Item("Comida", 1)
            };

            foreach (var item in items)
                await itemRepository.AddAsync(item);
        }
    }
}
