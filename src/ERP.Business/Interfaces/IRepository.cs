using ERP.Business.Models;
using System.Linq.Expressions;

namespace ERP.Business.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);    
        Task<bool> CheckExist(Guid id);
        Task<int> SaveChanges();
    }
}
