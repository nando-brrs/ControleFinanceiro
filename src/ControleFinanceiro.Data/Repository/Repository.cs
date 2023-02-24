using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using ControleFinanceiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ControleFinanceiroContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected IQueryable<TEntity> EntitySet;

        protected Repository(ControleFinanceiroContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
            EntitySet = DbSet.AsQueryable<TEntity>();
        }
        public Tuple<int, IEnumerable<TEntity>> GetPaged(int pageIndex, int pageSize, IList<Expression<Func<TEntity, bool>>> wheres = null, Expression<Func<TEntity, object>> orderBy = null, bool ascending = true)
        {
            var result = EntitySet;

            if (wheres != null)
            {
                result = wheres.Aggregate(result, (current, where) => current.Where(where));
            }

            if (orderBy != null)
            {
                result = ascending ? result.OrderBy(orderBy) : result.OrderByDescending(orderBy);
            }

            var intTotalRegisters = result.Count();

            if (pageSize <= 0 || pageIndex <= 0)
            {
                return new Tuple<int, IEnumerable<TEntity>>(intTotalRegisters, result.ToList());
            }


            var take = pageSize;
            var skip = pageSize * (pageIndex - 1);

            result = result.Skip(skip).Take(take);

            return new Tuple<int, IEnumerable<TEntity>>(intTotalRegisters, result.ToList());
        }
        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            var ent = DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
