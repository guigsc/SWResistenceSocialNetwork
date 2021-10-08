using Microsoft.EntityFrameworkCore;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Infrastructure.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Item> GetByNameAsync(string name)
        {
            return await _context.Items.Where(item => item.Name == name).SingleOrDefaultAsync();
        }
    }
}
