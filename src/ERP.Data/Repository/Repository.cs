using ERP.Business.Interfaces;
using ERP.Business.Models;
using ERP.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ERP.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public async Task<bool> CheckExist(Guid id)
        {
            return await DbSet.AnyAsync(c => c.Id == id);
        }
        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
