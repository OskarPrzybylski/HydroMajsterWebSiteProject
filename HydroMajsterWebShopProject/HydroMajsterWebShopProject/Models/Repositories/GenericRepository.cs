using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.Interfaces;

namespace HydroMajsterWebShopProject.Models.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : DbModel
    {
        protected readonly DatabaseContext DatabaseContext;

        protected GenericRepository(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        public virtual void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DatabaseContext.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual TEntity Get(int id)
        {
            return DatabaseContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DatabaseContext.Set<TEntity>().ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Update(entity);
        }
    }
}
