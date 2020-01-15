using Arcana.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arcana.Infrastructure.Database.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ArcanaContext _db = new ArcanaContext();

        public async Task AddAsync(TEntity obj)
        {
            await Task.Run(() => _db.Set<TEntity>().Add(obj));
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _db.Set<TEntity>());
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _db.Set<TEntity>().Where(predicate));
        }

        public async Task RemoveAsync(TEntity obj)
        {
            await Task.Run(() => _db.Set<TEntity>().Remove(obj));
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(() => _db.Entry(obj).State = EntityState.Modified);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
