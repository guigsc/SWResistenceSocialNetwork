using SWResistenceSocialNetwork.Domain.Entities;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> GetByNameAsync(string name);
    }
}
