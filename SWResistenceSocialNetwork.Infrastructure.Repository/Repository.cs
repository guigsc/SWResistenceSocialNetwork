using Microsoft.EntityFrameworkCore;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<int> RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
