using SWResistenceSocialNetwork.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task<int> RemoveAsync(T entity);
        Task<int> UpdateAsync(T entity);
    }
}
