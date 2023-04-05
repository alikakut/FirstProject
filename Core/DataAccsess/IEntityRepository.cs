using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccsess 
{
    public interface IEntityRepository<T> where T : class ,IEntity,new()
    {
        List<T> Getall(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);

        void add(T entity);
        void delete(T entity);
        void update(T entity);
    }
}
