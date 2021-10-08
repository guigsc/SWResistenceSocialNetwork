using Microsoft.EntityFrameworkCore;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Infrastructure.Repository
{
    public class RebelRepository : Repository<Rebel>, IRebelRepository
    {
        public RebelRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> GetTraitorsCountAsync()
        {
            return await _context.Rebels.CountAsync(rebel => rebel.IsTraitor);
        }

        public async Task<int> GetNonTraitorsCountAsync()
        {
            return await _context.Rebels.CountAsync(rebel => !rebel.IsTraitor);
        }

        public async Task<int> GetRebelsCountAsync()
        {
            return await _context.Rebels.CountAsync();
        }

        public async Task<IEnumerable<Rebel>> ListTraitorsAsync()
        {
            return await _context.Rebels
                .Where(rebel => rebel.IsTraitor)
                .Include(rebel => rebel.Inventory)
                .ThenInclude(inventory => inventory.Items)
                .ThenInclude(items => items.Item)
                .ToListAsync();
        }

        public override async Task<List<Rebel>> ListAsync()
        {
            return await _context.Rebels
                .Include(rebel => rebel.Inventory)
                .ThenInclude(inventory => inventory.Items)
                .ThenInclude(items => items.Item)
                .ToListAsync();
        }
    }
}
