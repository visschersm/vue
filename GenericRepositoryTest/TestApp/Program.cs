using System;
using System.Linq.Expressions;

namespace TestApp
{
    class Program
    {
        class Entity<T>
        {
            public T Get(Expression<Func<T, bool>> where = null)
            {
                throw new NotImplementedException();
            }

            public TView Get<TView>(Expression<Func<T, TView>> selection, Expression<Func<T, bool>> where = null)
            {
                throw new NotImplementedException();
            }

            public T Get<TKey>(Expression<Func<T, TKey>> property, Expression<Func<T, bool>> where = null)
            {
                throw new NotImplementedException();
            }

            public TView Get<TView>(Expression<Func<T, bool>> where = null)
            {
                throw new NotImplementedException();
            }

            public TView Get<TKey, TView>(Expression<Func<T, bool>> where = null, Expression<Func<T, TKey>> property)
            {
                throw new NotImplementedException();
            }
        }

        class Blog
        {

        }

        static void Main(string[] args)
        {
            Entity<Blog> service = new Entity<Blog>();
            service.Get();
        }
    }
}
