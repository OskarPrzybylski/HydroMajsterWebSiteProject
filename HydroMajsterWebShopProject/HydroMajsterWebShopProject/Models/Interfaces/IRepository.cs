using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Models.Interfaces
{
    public interface IRepository<TEntity> where TEntity : DbModel
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
