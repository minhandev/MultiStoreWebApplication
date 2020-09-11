using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories.EFCore
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly MultiStoreContext db;

        public GenericRepository(MultiStoreContext _db)
        {
            db = _db;
        }

        public IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await db.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await db.Set<TEntity>().FindAsync(id);
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
