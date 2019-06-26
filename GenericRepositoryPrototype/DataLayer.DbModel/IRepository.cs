using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbModel
{
    public interface IRepository<TEntity>
    {
        Task<ViewType[]> GetAsync<ViewType>(Expression<Func<TEntity, bool>> filterExpression, 
            Expression<Func<TEntity, ViewType>> selectExpression);
    }
}
