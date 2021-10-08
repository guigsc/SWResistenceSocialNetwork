using SWResistenceSocialNetwork.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Domain.Interfaces.Repositories
{
    public interface IRebelRepository : IRepository<Rebel>
    {
        Task<int> GetTraitorsCountAsync();
        Task<int> GetNonTraitorsCountAsync();
        Task<int> GetRebelsCountAsync();
        Task<IEnumerable<Rebel>> ListTraitorsAsync();
    }
}
