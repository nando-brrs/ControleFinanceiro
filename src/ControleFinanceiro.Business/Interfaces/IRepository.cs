using ControleFinanceiro.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Tuple<int, IEnumerable<TEntity>> GetPaged(int pageIndex, int pageSize, IList<Expression<Func<TEntity, bool>>> wheres = null, Expression<Func<TEntity, object>> orderBy = null, bool ascending = true);
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
