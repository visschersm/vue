using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbModel
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        protected readonly IContext _context;

        public IDbSet<Customer> Customers { get; set; }
        public Repository(IContext context)
        {
            _context = context;
        }

        public Task<ViewType[]> GetAsync<ViewType>(
            Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, ViewType>> selectExpression,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            MainContext context = new MainContext();
            context.Customers.AsNoTracking().Include()
            throw new NotImplementedException();
        }
    }
}
